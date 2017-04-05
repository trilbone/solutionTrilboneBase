<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmListManager
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
        Me.btClearListCollection = New System.Windows.Forms.Button()
        Me.btRemoveFromList = New System.Windows.Forms.Button()
        Me.btSaveSelectedListToCSV = New System.Windows.Forms.Button()
        Me.btSaveLists = New System.Windows.Forms.Button()
        Me.btCreateList = New System.Windows.Forms.Button()
        Me.btAddInList = New System.Windows.Forms.Button()
        Me.lbSamplesList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btClearActiveList = New System.Windows.Forms.Button()
        Me.lbSamplesInList = New System.Windows.Forms.ListBox()
        Me.ClsSampleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ClsSampleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btClearListCollection
        '
        Me.btClearListCollection.Location = New System.Drawing.Point(387, 165)
        Me.btClearListCollection.Name = "btClearListCollection"
        Me.btClearListCollection.Size = New System.Drawing.Size(92, 23)
        Me.btClearListCollection.TabIndex = 81
        Me.btClearListCollection.Text = "Очистить все"
        Me.btClearListCollection.UseVisualStyleBackColor = True
        '
        'btRemoveFromList
        '
        Me.btRemoveFromList.Enabled = False
        Me.btRemoveFromList.Location = New System.Drawing.Point(12, 84)
        Me.btRemoveFromList.Name = "btRemoveFromList"
        Me.btRemoveFromList.Size = New System.Drawing.Size(91, 23)
        Me.btRemoveFromList.TabIndex = 80
        Me.btRemoveFromList.Text = "Из списка"
        Me.btRemoveFromList.UseVisualStyleBackColor = True
        '
        'btSaveSelectedListToCSV
        '
        Me.btSaveSelectedListToCSV.Enabled = False
        Me.btSaveSelectedListToCSV.Location = New System.Drawing.Point(412, 45)
        Me.btSaveSelectedListToCSV.Name = "btSaveSelectedListToCSV"
        Me.btSaveSelectedListToCSV.Size = New System.Drawing.Size(67, 23)
        Me.btSaveSelectedListToCSV.TabIndex = 79
        Me.btSaveSelectedListToCSV.Text = "в CSV.."
        Me.btSaveSelectedListToCSV.UseVisualStyleBackColor = True
        '
        'btSaveLists
        '
        Me.btSaveLists.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btSaveLists.Location = New System.Drawing.Point(387, 3)
        Me.btSaveLists.Name = "btSaveLists"
        Me.btSaveLists.Size = New System.Drawing.Size(93, 21)
        Me.btSaveLists.TabIndex = 78
        Me.btSaveLists.Text = "Сохранить"
        Me.btSaveLists.UseVisualStyleBackColor = True
        '
        'btCreateList
        '
        Me.btCreateList.Enabled = False
        Me.btCreateList.Location = New System.Drawing.Point(285, 45)
        Me.btCreateList.Name = "btCreateList"
        Me.btCreateList.Size = New System.Drawing.Size(103, 23)
        Me.btCreateList.TabIndex = 76
        Me.btCreateList.Text = "Новый список"
        Me.btCreateList.UseVisualStyleBackColor = True
        '
        'btAddInList
        '
        Me.btAddInList.Enabled = False
        Me.btAddInList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btAddInList.Location = New System.Drawing.Point(12, 124)
        Me.btAddInList.Name = "btAddInList"
        Me.btAddInList.Size = New System.Drawing.Size(91, 64)
        Me.btAddInList.TabIndex = 75
        Me.btAddInList.Text = "В список"
        Me.btAddInList.UseVisualStyleBackColor = True
        '
        'lbSamplesList
        '
        Me.lbSamplesList.FormattingEnabled = True
        Me.lbSamplesList.Location = New System.Drawing.Point(285, 74)
        Me.lbSamplesList.Name = "lbSamplesList"
        Me.lbSamplesList.Size = New System.Drawing.Size(194, 82)
        Me.lbSamplesList.TabIndex = 74
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "номер"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(285, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 20)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "список"
        '
        'btClearActiveList
        '
        Me.btClearActiveList.Location = New System.Drawing.Point(285, 165)
        Me.btClearActiveList.Name = "btClearActiveList"
        Me.btClearActiveList.Size = New System.Drawing.Size(96, 23)
        Me.btClearActiveList.TabIndex = 85
        Me.btClearActiveList.Text = "Очистить тек."
        Me.btClearActiveList.UseVisualStyleBackColor = True
        '
        'lbSamplesInList
        '
        Me.lbSamplesInList.ColumnWidth = 85
        Me.lbSamplesInList.FormattingEnabled = True
        Me.lbSamplesInList.HorizontalScrollbar = True
        Me.lbSamplesInList.Location = New System.Drawing.Point(119, 28)
        Me.lbSamplesInList.Name = "lbSamplesInList"
        Me.lbSamplesInList.ScrollAlwaysVisible = True
        Me.lbSamplesInList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbSamplesInList.Size = New System.Drawing.Size(160, 160)
        Me.lbSamplesInList.TabIndex = 88
        '
        'ClsSampleListBindingSource
        '
        Me.ClsSampleListBindingSource.DataSource = GetType(Service.clsSampleList)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Label3"
        '
        'fmListManager
        '
        Me.AcceptButton = Me.btAddInList
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 193)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbSamplesInList)
        Me.Controls.Add(Me.btClearActiveList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btClearListCollection)
        Me.Controls.Add(Me.btRemoveFromList)
        Me.Controls.Add(Me.btSaveSelectedListToCSV)
        Me.Controls.Add(Me.btSaveLists)
        Me.Controls.Add(Me.btCreateList)
        Me.Controls.Add(Me.btAddInList)
        Me.Controls.Add(Me.lbSamplesList)
        Me.Name = "fmListManager"
        Me.Text = "List Manager 1.0"
        CType(Me.ClsSampleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btClearListCollection As System.Windows.Forms.Button
    Friend WithEvents btRemoveFromList As System.Windows.Forms.Button
    Friend WithEvents btSaveSelectedListToCSV As System.Windows.Forms.Button
    Friend WithEvents btSaveLists As System.Windows.Forms.Button
    Friend WithEvents btCreateList As System.Windows.Forms.Button
    Friend WithEvents btAddInList As System.Windows.Forms.Button
    Friend WithEvents lbSamplesList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btClearActiveList As System.Windows.Forms.Button
    Friend WithEvents lbSamplesInList As System.Windows.Forms.ListBox
    Friend WithEvents ClsSampleListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
