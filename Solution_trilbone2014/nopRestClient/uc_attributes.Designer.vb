<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_attributes
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Uc_langObjectAttributes = New nopRestClient.uc_langObject()
        Me.flp_center = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAttributeType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAttributeCustomValue = New System.Windows.Forms.TextBox()
        Me.cbx_ShowOnPage = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Uc_langObjectAttributesValues = New nopRestClient.uc_langObject()
        Me.ClsSpecificAttributesObject_emAttributeTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.bs_attribute = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemLangObjBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmAttributeTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.flp_center.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClsSpecificAttributesObject_emAttributeTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bs_attribute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemLangObjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmAttributeTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectAttributes)
        Me.FlowLayoutPanel1.Controls.Add(Me.flp_center)
        Me.FlowLayoutPanel1.Controls.Add(Me.Uc_langObjectAttributesValues)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1105, 159)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Uc_langObjectAttributes
        '
        Me.Uc_langObjectAttributes.EnabledNew = False
        Me.Uc_langObjectAttributes.Location = New System.Drawing.Point(3, 3)
        Me.Uc_langObjectAttributes.Name = "Uc_langObjectAttributes"
        Me.Uc_langObjectAttributes.SingleSelect = False
        Me.Uc_langObjectAttributes.Size = New System.Drawing.Size(381, 140)
        Me.Uc_langObjectAttributes.TabIndex = 0
        Me.Uc_langObjectAttributes.UcCaption = "Характеристики"
        '
        'flp_center
        '
        Me.flp_center.Controls.Add(Me.Label1)
        Me.flp_center.Controls.Add(Me.cbAttributeType)
        Me.flp_center.Controls.Add(Me.Label2)
        Me.flp_center.Controls.Add(Me.tbAttributeCustomValue)
        Me.flp_center.Controls.Add(Me.cbx_ShowOnPage)
        Me.flp_center.Controls.Add(Me.NumericUpDown1)
        Me.flp_center.Location = New System.Drawing.Point(390, 3)
        Me.flp_center.Name = "flp_center"
        Me.flp_center.Size = New System.Drawing.Size(200, 125)
        Me.flp_center.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Тип значения"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbAttributeType
        '
        Me.cbAttributeType.FormattingEnabled = True
        Me.cbAttributeType.Location = New System.Drawing.Point(3, 21)
        Me.cbAttributeType.Name = "cbAttributeType"
        Me.cbAttributeType.Size = New System.Drawing.Size(189, 21)
        Me.cbAttributeType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Перекрывающее знач."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbAttributeCustomValue
        '
        Me.tbAttributeCustomValue.Location = New System.Drawing.Point(3, 71)
        Me.tbAttributeCustomValue.Name = "tbAttributeCustomValue"
        Me.tbAttributeCustomValue.Size = New System.Drawing.Size(189, 20)
        Me.tbAttributeCustomValue.TabIndex = 3
        '
        'cbx_ShowOnPage
        '
        Me.cbx_ShowOnPage.AutoSize = True
        Me.cbx_ShowOnPage.Location = New System.Drawing.Point(3, 97)
        Me.cbx_ShowOnPage.Name = "cbx_ShowOnPage"
        Me.cbx_ShowOnPage.Size = New System.Drawing.Size(140, 17)
        Me.cbx_ShowOnPage.TabIndex = 5
        Me.cbx_ShowOnPage.Text = "Показать на странице"
        Me.cbx_ShowOnPage.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(149, 97)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(33, 20)
        Me.NumericUpDown1.TabIndex = 6
        '
        'Uc_langObjectAttributesValues
        '
        Me.Uc_langObjectAttributesValues.EnabledNew = True
        Me.Uc_langObjectAttributesValues.Location = New System.Drawing.Point(596, 3)
        Me.Uc_langObjectAttributesValues.Name = "Uc_langObjectAttributesValues"
        Me.Uc_langObjectAttributesValues.SingleSelect = True
        Me.Uc_langObjectAttributesValues.Size = New System.Drawing.Size(406, 149)
        Me.Uc_langObjectAttributesValues.TabIndex = 1
        Me.Uc_langObjectAttributesValues.UcCaption = "Значения"
        '
        'bs_attribute
        '
        Me.bs_attribute.DataSource = GetType(nopRestClient.clsSAObjectCollection)
        '
        'ItemLangObjBindingSource
        '
        Me.ItemLangObjBindingSource.DataMember = "ItemLangObj"
        Me.ItemLangObjBindingSource.DataSource = Me.bs_attribute
        '
        'uc_attributes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "uc_attributes"
        Me.Size = New System.Drawing.Size(1105, 159)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.flp_center.ResumeLayout(False)
        Me.flp_center.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClsSpecificAttributesObject_emAttributeTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bs_attribute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemLangObjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmAttributeTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Uc_langObjectAttributes As nopRestClient.uc_langObject
    Friend WithEvents flp_center As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAttributeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbAttributeCustomValue As System.Windows.Forms.TextBox
    Friend WithEvents cbx_ShowOnPage As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Uc_langObjectAttributesValues As nopRestClient.uc_langObject
    Friend WithEvents bs_attribute As System.Windows.Forms.BindingSource
    Friend WithEvents ClsSpecificAttributesObject_emAttributeTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemLangObjBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmAttributeTypeBindingSource As System.Windows.Forms.BindingSource

End Class
