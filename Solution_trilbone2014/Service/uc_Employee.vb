Imports System.Linq
Imports Service
Imports Service.clsApplicationTypes
Public Class uc_Employee
    Dim _contex As Service.DBOPHOTOEntities


    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        ' Me.btSave.Enabled = False
    End Sub

    Private Sub btLoadEmployee_Click(sender As Object, e As EventArgs) Handles btLoadEmployee.Click
        If Not Me.TbEmployeeBindingSource.DataSource Is Nothing Then
            Service.clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext.Refresh(Objects.RefreshMode.StoreWins, SampleDataObject.GetdbPhotoObjectContext.tbEmployee)
        End If
        _contex = Service.clsApplicationTypes.SampleDataObject.GetdbPhotoObjectContext
        Me.TbEmployeeBindingSource.DataSource = _contex.tbEmployee

    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        'добавить нового сотрудника
        Select Case MsgBox("Добавить нового сотрудника? Сохранить изменения - нажмите нет", vbYesNo)
            Case MsgBoxResult.Yes
                'последний добавленный обьект
                Me.TbEmployeeBindingSource.MoveLast()
                Dim _new As tbEmployee = Me.TbEmployeeBindingSource.Current
                _contex.tbEmployee.AddObject(_new)
                Dim _result = _contex.SaveChanges()
                If _result > 0 Then
                    Dim _emploee = _contex.tbEmployee.Where(Function(x) x.Name.Equals(_new.Name) And x.pin.Equals(_new.pin)).FirstOrDefault
                    If _emploee Is Nothing Then
                        MsgBox("Не удалось добавить сотрудника в БД!", vbCritical)
                        Return
                    End If
                    If Not clsApplicationTypes.CreateUser(_emploee.ID, _emploee.Name, _emploee.pin) Is Nothing Then
                        MsgBox("Сотрудник добавлен, нужно скорректировать запись в файле UserPermission в папке Trilbone Templates на GDRIVE, добавить права пользователя.", vbInformation)
                        Me.btSave.Enabled = False
                    Else
                        MsgBox("Не удалось добавить сотрудника в в файл UserPermission в папке Trilbone Templates!", vbCritical)
                        Return
                    End If
                Else
                    MsgBox("Не удалось добавить сотрудника в БД!", vbCritical)
                    Return
                End If
            Case Else
                Dim _result = _contex.SaveChanges()
                If _result > 0 Then
                    clsApplicationTypes.BeepYES()
                Else
                    MsgBox("Изменения не сохранены!", vbCritical)
                End If
        End Select
    End Sub

    'Private Sub DataGridView1_CellValueChanged(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

    'End Sub

    'Private Sub DataGridView1_UserAddedRow(sender As Object, e As Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
    '    Me.btSave.Enabled = True
    'End Sub
End Class
