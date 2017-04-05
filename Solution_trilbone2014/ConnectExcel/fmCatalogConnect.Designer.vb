<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmCatalogConnect
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Me.btOpenCatalog = New System.Windows.Forms.Button()
        Me.btOpenFiles = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbGroupingName = New System.Windows.Forms.Label()
        Me.bdsSample = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbSamplesList = New System.Windows.Forms.ListBox()
        Me.lbGroupSampleList = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbSamplesSelectedList = New System.Windows.Forms.ListBox()
        Me.btSampleAddToSelected = New System.Windows.Forms.Button()
        Me.btSampleRemoveFromSelected = New System.Windows.Forms.Button()
        Me.btSampleMoveAll = New System.Windows.Forms.Button()
        Me.gbSamples = New System.Windows.Forms.GroupBox()
        Me.btEditSample = New System.Windows.Forms.Button()
        Me.btSampleViewInfoFromDB = New System.Windows.Forms.Button()
        Me.lbSamplePresentIntoDB = New System.Windows.Forms.Label()
        Me.btSampleSaveInDB = New System.Windows.Forms.Button()
        Me.btSampleSelectedNumber = New System.Windows.Forms.Label()
        Me.gbSamplesParameters = New System.Windows.Forms.GroupBox()
        Me.btWritePrices = New System.Windows.Forms.Button()
        Me.tbSampleHeight = New System.Windows.Forms.TextBox()
        Me.tbWeight = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbFossilSizeB = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbFossilSizeA = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbSampleSizeA = New System.Windows.Forms.TextBox()
        Me.tbSampleSizeB = New System.Windows.Forms.TextBox()
        Me.tbSampleDescription = New System.Windows.Forms.RichTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbSamplePrice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btSampleRestoryInfo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btSaveSampleInfoInBuffer = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbSampleName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbCatalogSampleSize = New System.Windows.Forms.TextBox()
        Me.lbCatalogName = New System.Windows.Forms.Label()
        Me.gbImages = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbImageSelectedList = New System.Windows.Forms.ListBox()
        Me.btImageMoveAll = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btImageRemoveFromSelected = New System.Windows.Forms.Button()
        Me.btImageAddToSelected = New System.Windows.Forms.Button()
        Me.lbImageList = New System.Windows.Forms.ListBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btImageSaveInDB = New System.Windows.Forms.Button()
        Me.lbImageSelectedNumber = New System.Windows.Forms.Label()
        Me.bdsImage = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxOrderActive = New System.Windows.Forms.CheckBox()
        Me.tbOrderName = New System.Windows.Forms.TextBox()
        Me.fbdSelectCatalogFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.ofdOpenSamplesFiles = New System.Windows.Forms.OpenFileDialog()
        Me.btOpenManager = New System.Windows.Forms.Button()
        Me.UcPhotoList1 = New Service.ucPhotoList()
        CType(Me.bdsSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSamples.SuspendLayout()
        Me.gbSamplesParameters.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbImages.SuspendLayout()
        CType(Me.bdsImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btOpenCatalog
        '
        Me.btOpenCatalog.Location = New System.Drawing.Point(22, 12)
        Me.btOpenCatalog.Name = "btOpenCatalog"
        Me.btOpenCatalog.Size = New System.Drawing.Size(123, 23)
        Me.btOpenCatalog.TabIndex = 0
        Me.btOpenCatalog.Text = "открыть каталог"
        Me.btOpenCatalog.UseVisualStyleBackColor = True
        '
        'btOpenFiles
        '
        Me.btOpenFiles.Location = New System.Drawing.Point(330, 7)
        Me.btOpenFiles.Name = "btOpenFiles"
        Me.btOpenFiles.Size = New System.Drawing.Size(174, 23)
        Me.btOpenFiles.TabIndex = 1
        Me.btOpenFiles.Text = "открыть папки изображений"
        Me.btOpenFiles.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "список"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(84, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "*красные отсутствуют в БД"
        '
        'lbGroupingName
        '
        Me.lbGroupingName.AutoSize = True
        Me.lbGroupingName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "GROUP", True))
        Me.lbGroupingName.Location = New System.Drawing.Point(21, 273)
        Me.lbGroupingName.Name = "lbGroupingName"
        Me.lbGroupingName.Size = New System.Drawing.Size(100, 13)
        Me.lbGroupingName.TabIndex = 6
        Me.lbGroupingName.Text = "(название группы)"
        '
        'bdsSample
        '
        Me.bdsSample.DataSource = GetType(ConnectExcel.strSample)
        '
        'lbSamplesList
        '
        Me.lbSamplesList.FormattingEnabled = True
        Me.lbSamplesList.Location = New System.Drawing.Point(25, 49)
        Me.lbSamplesList.Name = "lbSamplesList"
        Me.lbSamplesList.Size = New System.Drawing.Size(120, 186)
        Me.lbSamplesList.TabIndex = 7
        '
        'lbGroupSampleList
        '
        Me.lbGroupSampleList.Enabled = False
        Me.lbGroupSampleList.FormattingEnabled = True
        Me.lbGroupSampleList.Location = New System.Drawing.Point(6, 298)
        Me.lbGroupSampleList.Name = "lbGroupSampleList"
        Me.lbGroupSampleList.Size = New System.Drawing.Size(120, 95)
        Me.lbGroupSampleList.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(235, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "выбраны для занесения"
        '
        'lbSamplesSelectedList
        '
        Me.lbSamplesSelectedList.FormattingEnabled = True
        Me.lbSamplesSelectedList.Location = New System.Drawing.Point(238, 49)
        Me.lbSamplesSelectedList.Name = "lbSamplesSelectedList"
        Me.lbSamplesSelectedList.Size = New System.Drawing.Size(120, 186)
        Me.lbSamplesSelectedList.TabIndex = 11
        '
        'btSampleAddToSelected
        '
        Me.btSampleAddToSelected.Location = New System.Drawing.Point(167, 49)
        Me.btSampleAddToSelected.Name = "btSampleAddToSelected"
        Me.btSampleAddToSelected.Size = New System.Drawing.Size(43, 23)
        Me.btSampleAddToSelected.TabIndex = 12
        Me.btSampleAddToSelected.Text = ">>"
        Me.btSampleAddToSelected.UseVisualStyleBackColor = True
        '
        'btSampleRemoveFromSelected
        '
        Me.btSampleRemoveFromSelected.Location = New System.Drawing.Point(167, 87)
        Me.btSampleRemoveFromSelected.Name = "btSampleRemoveFromSelected"
        Me.btSampleRemoveFromSelected.Size = New System.Drawing.Size(43, 23)
        Me.btSampleRemoveFromSelected.TabIndex = 13
        Me.btSampleRemoveFromSelected.Text = "<<"
        Me.btSampleRemoveFromSelected.UseVisualStyleBackColor = True
        '
        'btSampleMoveAll
        '
        Me.btSampleMoveAll.Location = New System.Drawing.Point(167, 121)
        Me.btSampleMoveAll.Name = "btSampleMoveAll"
        Me.btSampleMoveAll.Size = New System.Drawing.Size(65, 23)
        Me.btSampleMoveAll.TabIndex = 14
        Me.btSampleMoveAll.Text = "Все >>"
        Me.btSampleMoveAll.UseVisualStyleBackColor = True
        '
        'gbSamples
        '
        Me.gbSamples.Controls.Add(Me.btEditSample)
        Me.gbSamples.Controls.Add(Me.btSampleViewInfoFromDB)
        Me.gbSamples.Controls.Add(Me.lbSamplePresentIntoDB)
        Me.gbSamples.Controls.Add(Me.Label3)
        Me.gbSamples.Controls.Add(Me.btSampleSaveInDB)
        Me.gbSamples.Controls.Add(Me.lbSamplesSelectedList)
        Me.gbSamples.Controls.Add(Me.btSampleSelectedNumber)
        Me.gbSamples.Controls.Add(Me.gbSamplesParameters)
        Me.gbSamples.Controls.Add(Me.btSampleMoveAll)
        Me.gbSamples.Controls.Add(Me.Label1)
        Me.gbSamples.Controls.Add(Me.btSampleRemoveFromSelected)
        Me.gbSamples.Controls.Add(Me.btSampleAddToSelected)
        Me.gbSamples.Controls.Add(Me.lbSamplesList)
        Me.gbSamples.Controls.Add(Me.Label6)
        Me.gbSamples.Location = New System.Drawing.Point(22, 41)
        Me.gbSamples.Name = "gbSamples"
        Me.gbSamples.Size = New System.Drawing.Size(374, 733)
        Me.gbSamples.TabIndex = 15
        Me.gbSamples.TabStop = False
        Me.gbSamples.Text = "Образцы"
        '
        'btEditSample
        '
        Me.btEditSample.Location = New System.Drawing.Point(249, 696)
        Me.btEditSample.Name = "btEditSample"
        Me.btEditSample.Size = New System.Drawing.Size(117, 22)
        Me.btEditSample.TabIndex = 24
        Me.btEditSample.Text = "редактировать.."
        Me.btEditSample.UseVisualStyleBackColor = True
        '
        'btSampleViewInfoFromDB
        '
        Me.btSampleViewInfoFromDB.Location = New System.Drawing.Point(119, 695)
        Me.btSampleViewInfoFromDB.Name = "btSampleViewInfoFromDB"
        Me.btSampleViewInfoFromDB.Size = New System.Drawing.Size(124, 23)
        Me.btSampleViewInfoFromDB.TabIndex = 23
        Me.btSampleViewInfoFromDB.Text = "посмотреть в БД.."
        Me.btSampleViewInfoFromDB.UseVisualStyleBackColor = True
        '
        'lbSamplePresentIntoDB
        '
        Me.lbSamplePresentIntoDB.AutoSize = True
        Me.lbSamplePresentIntoDB.Location = New System.Drawing.Point(30, 695)
        Me.lbSamplePresentIntoDB.Name = "lbSamplePresentIntoDB"
        Me.lbSamplePresentIntoDB.Size = New System.Drawing.Size(83, 13)
        Me.lbSamplePresentIntoDB.TabIndex = 22
        Me.lbSamplePresentIntoDB.Text = "(уже занесено)"
        '
        'btSampleSaveInDB
        '
        Me.btSampleSaveInDB.Location = New System.Drawing.Point(141, 657)
        Me.btSampleSaveInDB.Name = "btSampleSaveInDB"
        Me.btSampleSaveInDB.Size = New System.Drawing.Size(97, 23)
        Me.btSampleSaveInDB.TabIndex = 21
        Me.btSampleSaveInDB.Text = "занести в БД"
        Me.btSampleSaveInDB.UseVisualStyleBackColor = True
        '
        'btSampleSelectedNumber
        '
        Me.btSampleSelectedNumber.AutoSize = True
        Me.btSampleSelectedNumber.Location = New System.Drawing.Point(22, 662)
        Me.btSampleSelectedNumber.Name = "btSampleSelectedNumber"
        Me.btSampleSelectedNumber.Size = New System.Drawing.Size(106, 13)
        Me.btSampleSelectedNumber.TabIndex = 20
        Me.btSampleSelectedNumber.Text = "(выбранный номер)"
        '
        'gbSamplesParameters
        '
        Me.gbSamplesParameters.Controls.Add(Me.btWritePrices)
        Me.gbSamplesParameters.Controls.Add(Me.tbSampleHeight)
        Me.gbSamplesParameters.Controls.Add(Me.tbWeight)
        Me.gbSamplesParameters.Controls.Add(Me.Label16)
        Me.gbSamplesParameters.Controls.Add(Me.Label14)
        Me.gbSamplesParameters.Controls.Add(Me.tbFossilSizeB)
        Me.gbSamplesParameters.Controls.Add(Me.Label12)
        Me.gbSamplesParameters.Controls.Add(Me.tbFossilSizeA)
        Me.gbSamplesParameters.Controls.Add(Me.Label11)
        Me.gbSamplesParameters.Controls.Add(Me.tbSampleSizeA)
        Me.gbSamplesParameters.Controls.Add(Me.tbSampleSizeB)
        Me.gbSamplesParameters.Controls.Add(Me.tbSampleDescription)
        Me.gbSamplesParameters.Controls.Add(Me.Label19)
        Me.gbSamplesParameters.Controls.Add(Me.Label10)
        Me.gbSamplesParameters.Controls.Add(Me.tbSamplePrice)
        Me.gbSamplesParameters.Controls.Add(Me.Label9)
        Me.gbSamplesParameters.Controls.Add(Me.Label5)
        Me.gbSamplesParameters.Controls.Add(Me.Label4)
        Me.gbSamplesParameters.Controls.Add(Me.btSampleRestoryInfo)
        Me.gbSamplesParameters.Controls.Add(Me.Label8)
        Me.gbSamplesParameters.Controls.Add(Me.btSaveSampleInfoInBuffer)
        Me.gbSamplesParameters.Controls.Add(Me.TableLayoutPanel1)
        Me.gbSamplesParameters.Controls.Add(Me.lbGroupingName)
        Me.gbSamplesParameters.Controls.Add(Me.lbGroupSampleList)
        Me.gbSamplesParameters.Location = New System.Drawing.Point(7, 252)
        Me.gbSamplesParameters.Name = "gbSamplesParameters"
        Me.gbSamplesParameters.Size = New System.Drawing.Size(351, 399)
        Me.gbSamplesParameters.TabIndex = 16
        Me.gbSamplesParameters.TabStop = False
        Me.gbSamplesParameters.Text = "Параметры выбранного образца"
        '
        'btWritePrices
        '
        Me.btWritePrices.Location = New System.Drawing.Point(236, 366)
        Me.btWritePrices.Name = "btWritePrices"
        Me.btWritePrices.Size = New System.Drawing.Size(109, 23)
        Me.btWritePrices.TabIndex = 30
        Me.btWritePrices.Text = "занести цены"
        Me.btWritePrices.UseVisualStyleBackColor = True
        '
        'tbSampleHeight
        '
        Me.tbSampleHeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "PRICE", True))
        Me.tbSampleHeight.Location = New System.Drawing.Point(93, 127)
        Me.tbSampleHeight.Name = "tbSampleHeight"
        Me.tbSampleHeight.Size = New System.Drawing.Size(63, 20)
        Me.tbSampleHeight.TabIndex = 29
        Me.tbSampleHeight.Text = "0"
        '
        'tbWeight
        '
        Me.tbWeight.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "PRICE", True))
        Me.tbWeight.Location = New System.Drawing.Point(266, 123)
        Me.tbWeight.Name = "tbWeight"
        Me.tbWeight.Size = New System.Drawing.Size(63, 20)
        Me.tbWeight.TabIndex = 27
        Me.tbWeight.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Sample height"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(199, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Weight, kg"
        '
        'tbFossilSizeB
        '
        Me.tbFossilSizeB.Location = New System.Drawing.Point(266, 99)
        Me.tbFossilSizeB.Name = "tbFossilSizeB"
        Me.tbFossilSizeB.Size = New System.Drawing.Size(63, 20)
        Me.tbFossilSizeB.TabIndex = 24
        Me.tbFossilSizeB.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(173, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Main fossil size B"
        '
        'tbFossilSizeA
        '
        Me.tbFossilSizeA.Location = New System.Drawing.Point(266, 76)
        Me.tbFossilSizeA.Name = "tbFossilSizeA"
        Me.tbFossilSizeA.Size = New System.Drawing.Size(63, 20)
        Me.tbFossilSizeA.TabIndex = 22
        Me.tbFossilSizeA.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(173, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Main fossil size A"
        '
        'tbSampleSizeA
        '
        Me.tbSampleSizeA.Location = New System.Drawing.Point(93, 77)
        Me.tbSampleSizeA.Name = "tbSampleSizeA"
        Me.tbSampleSizeA.Size = New System.Drawing.Size(63, 20)
        Me.tbSampleSizeA.TabIndex = 21
        Me.tbSampleSizeA.Text = "0"
        '
        'tbSampleSizeB
        '
        Me.tbSampleSizeB.Location = New System.Drawing.Point(93, 102)
        Me.tbSampleSizeB.Name = "tbSampleSizeB"
        Me.tbSampleSizeB.Size = New System.Drawing.Size(63, 20)
        Me.tbSampleSizeB.TabIndex = 5
        Me.tbSampleSizeB.Text = "0"
        '
        'tbSampleDescription
        '
        Me.tbSampleDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "DESCRIPTION", True))
        Me.tbSampleDescription.Location = New System.Drawing.Point(12, 170)
        Me.tbSampleDescription.Name = "tbSampleDescription"
        Me.tbSampleDescription.Size = New System.Drawing.Size(329, 90)
        Me.tbSampleDescription.TabIndex = 20
        Me.tbSampleDescription.Text = ""
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 154)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Описание"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 273)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "внутренний буфер"
        '
        'tbSamplePrice
        '
        Me.tbSamplePrice.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "PRICE", True))
        Me.tbSamplePrice.Location = New System.Drawing.Point(266, 147)
        Me.tbSamplePrice.Name = "tbSamplePrice"
        Me.tbSamplePrice.Size = New System.Drawing.Size(63, 20)
        Me.tbSamplePrice.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(229, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Price"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sample size B"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(160, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 44)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "*изменение доступно только для заносимых образцов (изменненые - синие)"
        '
        'btSampleRestoryInfo
        '
        Me.btSampleRestoryInfo.Enabled = False
        Me.btSampleRestoryInfo.Location = New System.Drawing.Point(254, 289)
        Me.btSampleRestoryInfo.Name = "btSampleRestoryInfo"
        Me.btSampleRestoryInfo.Size = New System.Drawing.Size(75, 23)
        Me.btSampleRestoryInfo.TabIndex = 16
        Me.btSampleRestoryInfo.Text = "отмена"
        Me.btSampleRestoryInfo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Sample size A"
        '
        'btSaveSampleInfoInBuffer
        '
        Me.btSaveSampleInfoInBuffer.Enabled = False
        Me.btSaveSampleInfoInBuffer.Location = New System.Drawing.Point(160, 289)
        Me.btSaveSampleInfoInBuffer.Name = "btSaveSampleInfoInBuffer"
        Me.btSaveSampleInfoInBuffer.Size = New System.Drawing.Size(75, 23)
        Me.btSaveSampleInfoInBuffer.TabIndex = 15
        Me.btSaveSampleInfoInBuffer.Text = "сохранить"
        Me.btSaveSampleInfoInBuffer.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbSampleName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbCatalogSampleSize, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(345, 54)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'tbSampleName
        '
        Me.tbSampleName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "NAME", True))
        Me.tbSampleName.Location = New System.Drawing.Point(98, 3)
        Me.tbSampleName.Name = "tbSampleName"
        Me.tbSampleName.Size = New System.Drawing.Size(239, 20)
        Me.tbSampleName.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "catalog fossil size"
        '
        'tbCatalogSampleSize
        '
        Me.tbCatalogSampleSize.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsSample, "SIZE", True))
        Me.tbCatalogSampleSize.Location = New System.Drawing.Point(98, 30)
        Me.tbCatalogSampleSize.Name = "tbCatalogSampleSize"
        Me.tbCatalogSampleSize.Size = New System.Drawing.Size(239, 20)
        Me.tbCatalogSampleSize.TabIndex = 3
        '
        'lbCatalogName
        '
        Me.lbCatalogName.Location = New System.Drawing.Point(160, 13)
        Me.lbCatalogName.Name = "lbCatalogName"
        Me.lbCatalogName.Size = New System.Drawing.Size(163, 23)
        Me.lbCatalogName.TabIndex = 16
        Me.lbCatalogName.Text = "(название каталога)"
        '
        'gbImages
        '
        Me.gbImages.Controls.Add(Me.Label13)
        Me.gbImages.Controls.Add(Me.lbImageSelectedList)
        Me.gbImages.Controls.Add(Me.btImageMoveAll)
        Me.gbImages.Controls.Add(Me.Label20)
        Me.gbImages.Controls.Add(Me.btImageRemoveFromSelected)
        Me.gbImages.Controls.Add(Me.btImageAddToSelected)
        Me.gbImages.Controls.Add(Me.lbImageList)
        Me.gbImages.Controls.Add(Me.Label21)
        Me.gbImages.Location = New System.Drawing.Point(413, 41)
        Me.gbImages.Name = "gbImages"
        Me.gbImages.Size = New System.Drawing.Size(374, 250)
        Me.gbImages.TabIndex = 19
        Me.gbImages.TabStop = False
        Me.gbImages.Text = "Фотографии в каталоге"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(84, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "*красные отсутствуют в БД"
        '
        'lbImageSelectedList
        '
        Me.lbImageSelectedList.FormattingEnabled = True
        Me.lbImageSelectedList.Location = New System.Drawing.Point(238, 49)
        Me.lbImageSelectedList.Name = "lbImageSelectedList"
        Me.lbImageSelectedList.Size = New System.Drawing.Size(120, 186)
        Me.lbImageSelectedList.TabIndex = 11
        '
        'btImageMoveAll
        '
        Me.btImageMoveAll.Location = New System.Drawing.Point(167, 121)
        Me.btImageMoveAll.Name = "btImageMoveAll"
        Me.btImageMoveAll.Size = New System.Drawing.Size(65, 23)
        Me.btImageMoveAll.TabIndex = 14
        Me.btImageMoveAll.Text = "Все >>"
        Me.btImageMoveAll.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(22, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "список"
        '
        'btImageRemoveFromSelected
        '
        Me.btImageRemoveFromSelected.Location = New System.Drawing.Point(167, 87)
        Me.btImageRemoveFromSelected.Name = "btImageRemoveFromSelected"
        Me.btImageRemoveFromSelected.Size = New System.Drawing.Size(43, 23)
        Me.btImageRemoveFromSelected.TabIndex = 13
        Me.btImageRemoveFromSelected.Text = "<<"
        Me.btImageRemoveFromSelected.UseVisualStyleBackColor = True
        '
        'btImageAddToSelected
        '
        Me.btImageAddToSelected.Location = New System.Drawing.Point(167, 49)
        Me.btImageAddToSelected.Name = "btImageAddToSelected"
        Me.btImageAddToSelected.Size = New System.Drawing.Size(43, 23)
        Me.btImageAddToSelected.TabIndex = 12
        Me.btImageAddToSelected.Text = ">>"
        Me.btImageAddToSelected.UseVisualStyleBackColor = True
        '
        'lbImageList
        '
        Me.lbImageList.FormattingEnabled = True
        Me.lbImageList.Location = New System.Drawing.Point(25, 49)
        Me.lbImageList.Name = "lbImageList"
        Me.lbImageList.Size = New System.Drawing.Size(120, 186)
        Me.lbImageList.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(235, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(131, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "выбраны для занесения"
        '
        'btImageSaveInDB
        '
        Me.btImageSaveInDB.Location = New System.Drawing.Point(531, 296)
        Me.btImageSaveInDB.Name = "btImageSaveInDB"
        Me.btImageSaveInDB.Size = New System.Drawing.Size(97, 23)
        Me.btImageSaveInDB.TabIndex = 25
        Me.btImageSaveInDB.Text = "занести в БД"
        Me.btImageSaveInDB.UseVisualStyleBackColor = True
        '
        'lbImageSelectedNumber
        '
        Me.lbImageSelectedNumber.AutoSize = True
        Me.lbImageSelectedNumber.Location = New System.Drawing.Point(410, 296)
        Me.lbImageSelectedNumber.Name = "lbImageSelectedNumber"
        Me.lbImageSelectedNumber.Size = New System.Drawing.Size(106, 13)
        Me.lbImageSelectedNumber.TabIndex = 24
        Me.lbImageSelectedNumber.Text = "(выбранный номер)"
        '
        'bdsImage
        '
        '
        'cbxOrderActive
        '
        Me.cbxOrderActive.AutoSize = True
        Me.cbxOrderActive.Location = New System.Drawing.Point(531, 10)
        Me.cbxOrderActive.Name = "cbxOrderActive"
        Me.cbxOrderActive.Size = New System.Drawing.Size(154, 17)
        Me.cbxOrderActive.TabIndex = 20
        Me.cbxOrderActive.Text = "все в заказ (8 символов)"
        Me.cbxOrderActive.UseVisualStyleBackColor = True
        '
        'tbOrderName
        '
        Me.tbOrderName.Enabled = False
        Me.tbOrderName.Location = New System.Drawing.Point(691, 10)
        Me.tbOrderName.Name = "tbOrderName"
        Me.tbOrderName.Size = New System.Drawing.Size(93, 20)
        Me.tbOrderName.TabIndex = 21
        '
        'fbdSelectCatalogFolder
        '
        Me.fbdSelectCatalogFolder.RootFolder = System.Environment.SpecialFolder.CommonDocuments
        Me.fbdSelectCatalogFolder.ShowNewFolderButton = False
        '
        'ofdOpenSamplesFiles
        '
        Me.ofdOpenSamplesFiles.DefaultExt = "xml"
        Me.ofdOpenSamplesFiles.FileName = "OpenFileDialog1"
        Me.ofdOpenSamplesFiles.Filter = """файлы образцов|*.xml"""
        Me.ofdOpenSamplesFiles.Multiselect = True
        Me.ofdOpenSamplesFiles.RestoreDirectory = True
        Me.ofdOpenSamplesFiles.Title = "выбор файлов образцов"
        '
        'btOpenManager
        '
        Me.btOpenManager.Location = New System.Drawing.Point(674, 297)
        Me.btOpenManager.Name = "btOpenManager"
        Me.btOpenManager.Size = New System.Drawing.Size(110, 23)
        Me.btOpenManager.TabIndex = 27
        Me.btOpenManager.Text = "менеджер.."
        Me.btOpenManager.UseVisualStyleBackColor = True
        '
        'UcPhotoList1
        '
        Me.UcPhotoList1.FreeSource = Nothing
        Me.UcPhotoList1.Location = New System.Drawing.Point(412, 340)
        Me.UcPhotoList1.Name = "UcPhotoList1"
        Me.UcPhotoList1.SampleNumber = Nothing
        Me.UcPhotoList1.ShowPhoto = False
        Me.UcPhotoList1.ShowPopUp = False
        Me.UcPhotoList1.Size = New System.Drawing.Size(428, 430)
        Me.UcPhotoList1.Source = Nothing
        Me.UcPhotoList1.TabIndex = 26
        '
        'fmCatalogConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 782)
        Me.Controls.Add(Me.btOpenManager)
        Me.Controls.Add(Me.UcPhotoList1)
        Me.Controls.Add(Me.btImageSaveInDB)
        Me.Controls.Add(Me.tbOrderName)
        Me.Controls.Add(Me.lbImageSelectedNumber)
        Me.Controls.Add(Me.cbxOrderActive)
        Me.Controls.Add(Me.gbImages)
        Me.Controls.Add(Me.lbCatalogName)
        Me.Controls.Add(Me.gbSamples)
        Me.Controls.Add(Me.btOpenFiles)
        Me.Controls.Add(Me.btOpenCatalog)
        Me.Name = "fmCatalogConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Обработка каталога"
        CType(Me.bdsSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSamples.ResumeLayout(False)
        Me.gbSamples.PerformLayout()
        Me.gbSamplesParameters.ResumeLayout(False)
        Me.gbSamplesParameters.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbImages.ResumeLayout(False)
        Me.gbImages.PerformLayout()
        CType(Me.bdsImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btOpenCatalog As System.Windows.Forms.Button
    Friend WithEvents btOpenFiles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbGroupingName As System.Windows.Forms.Label
    Friend WithEvents lbSamplesList As System.Windows.Forms.ListBox
    Friend WithEvents lbGroupSampleList As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbSamplesSelectedList As System.Windows.Forms.ListBox
    Friend WithEvents btSampleAddToSelected As System.Windows.Forms.Button
    Friend WithEvents btSampleRemoveFromSelected As System.Windows.Forms.Button
    Friend WithEvents btSampleMoveAll As System.Windows.Forms.Button
    Friend WithEvents gbSamples As System.Windows.Forms.GroupBox
    Friend WithEvents btSaveSampleInfoInBuffer As System.Windows.Forms.Button
    Friend WithEvents gbSamplesParameters As System.Windows.Forms.GroupBox
    Friend WithEvents btSampleViewInfoFromDB As System.Windows.Forms.Button
    Friend WithEvents lbSamplePresentIntoDB As System.Windows.Forms.Label
    Friend WithEvents btSampleSaveInDB As System.Windows.Forms.Button
    Friend WithEvents btSampleSelectedNumber As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btSampleRestoryInfo As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbSamplePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbSampleSizeB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbSampleName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbCatalogSampleSize As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbCatalogName As System.Windows.Forms.Label
    Friend WithEvents gbImages As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbImageSelectedList As System.Windows.Forms.ListBox
    Friend WithEvents btImageMoveAll As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btImageRemoveFromSelected As System.Windows.Forms.Button
    Friend WithEvents btImageAddToSelected As System.Windows.Forms.Button
    Friend WithEvents lbImageList As System.Windows.Forms.ListBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btImageSaveInDB As System.Windows.Forms.Button
    Friend WithEvents lbImageSelectedNumber As System.Windows.Forms.Label
    Friend WithEvents tbSampleDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbxOrderActive As System.Windows.Forms.CheckBox
    Friend WithEvents tbOrderName As System.Windows.Forms.TextBox
    Friend WithEvents fbdSelectCatalogFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ofdOpenSamplesFiles As System.Windows.Forms.OpenFileDialog
    Friend WithEvents bdsSample As System.Windows.Forms.BindingSource
    Friend WithEvents bdsImage As System.Windows.Forms.BindingSource
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbFossilSizeB As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbFossilSizeA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbSampleSizeA As System.Windows.Forms.TextBox
    Friend WithEvents tbWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbSampleHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btWritePrices As System.Windows.Forms.Button
    Friend WithEvents UcPhotoList1 As Service.ucPhotoList
    Friend WithEvents btOpenManager As System.Windows.Forms.Button
    Friend WithEvents btEditSample As System.Windows.Forms.Button
End Class
