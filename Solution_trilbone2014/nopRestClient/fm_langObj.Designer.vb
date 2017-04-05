<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_langObj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_langObj))
        Me.Uc_langObject1 = New nopRestClient.uc_langObject()
        Me.SuspendLayout()
        '
        'Uc_langObject1
        '
        Me.Uc_langObject1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Uc_langObject1.Location = New System.Drawing.Point(0, 0)
        Me.Uc_langObject1.Name = "Uc_langObject1"
        Me.Uc_langObject1.SingleSelect = False
        Me.Uc_langObject1.Size = New System.Drawing.Size(514, 261)
        Me.Uc_langObject1.TabIndex = 0
        Me.Uc_langObject1.UcCaption = "Name"
        '
        'fm_langObj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 261)
        Me.Controls.Add(Me.Uc_langObject1)
        Me.Name = "fm_langObj"
        Me.Text = "fm_langObj"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Uc_langObject1 As nopRestClient.uc_langObject
End Class
