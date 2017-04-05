Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel
Imports Service

Public Class fmExcelConnect
    Private WithEvents _connObj As ExcelConnect
    'Private WithEvents backgroundWorker1 As BackgroundWorker
    Delegate Sub AddColumnDelegate(ByVal name As Integer)
    Delegate Sub AddRowDelegate(ByVal values As List(Of String))
    Delegate Sub ClearGridDelegate()

    Public Enum emOperations
        SeveralColumsFromSplitter = 0
    End Enum
    Public Sub ExcelHandles(ByVal sender As Object, ByVal columncount As Integer, ByVal rowcount As Integer, ByVal data As List(Of List(Of String))) Handles _connObj.DataLoaded
        Dim _d As New ClearGridDelegate(AddressOf ClearGrid)
        Me.Invoke(_d)
        Me.SetData(data)
        Uc_Sample_data1.ColumnsCount = DataGridView1.ColumnCount
        'Me.Focus()
    End Sub
    Public Function SetData(ByVal _data As List(Of List(Of String))) As Boolean
        If _data.Count = 0 Then Return False
        Me.DataGridView1.AutoGenerateColumns = False
        For i = 1 To _data.Item(0).Count
            If Me.DataGridView1.InvokeRequired Then
                Dim _d As New AddColumnDelegate(AddressOf AddColumn)
                Me.Invoke(_d, New Object() {i})
            Else
                Me.DataGridView1.Columns.Add(i, i)
            End If

        Next
        For Each _row As List(Of String) In _data
            Dim _d As New AddRowDelegate(AddressOf AddRow)
            Me.Invoke(_d, New Object() {_row})
        Next
        Return True
    End Function

    Private Sub ClearGrid()
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
    End Sub
    Private Sub AddColumn(ByVal name As Integer)
        Me.DataGridView1.Columns.Add(name, name)
    End Sub
    Private Sub AddRow(ByVal values As List(Of String))
        Dim _tmp(values.Count - 1) As String
        values.CopyTo(_tmp)
        Me.DataGridView1.Rows.Add(_tmp)
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        Me.Visible = True
        Me.Uc_Sample_data1.Enabled = False
    End Sub

    Private Sub Uc_Sample_data1_DataSavedToDB(ByVal result As Integer) Handles Uc_Sample_data1.DataSavedToDB
        'данные сохранены
        Select Case result
            Case Is >= 1
                Me.DataGridView1.Focus()
            Case -2
                Me.DataGridView1.Focus()
        End Select
    End Sub


    
    Private Sub UC_RefreshDataHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles Uc_Sample_data1.RefreshData


        If Not Me.DataGridView1.CurrentRow Is Nothing Then
            Dim _arr(Me.DataGridView1.CurrentRow.Cells.Count - 1) As String
            For i = 0 To Me.DataGridView1.CurrentRow.Cells.Count - 1
                If Not Me.DataGridView1.CurrentRow.Cells(i).Value Is Nothing Then
                    _arr(i) = Me.DataGridView1.CurrentRow.Cells(i).Value
                Else
                    _arr(i) = ""
                End If

            Next
            Uc_Sample_data1.Data = _arr
        End If

    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        'Me.Uc_Sample_data1.lbResult.Text = "Result?"
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        Dim _arr(Me.DataGridView1.Rows(e.RowIndex).Cells.Count - 1) As String
        For i = 0 To Me.DataGridView1.Rows(e.RowIndex).Cells.Count - 1
            If Not Me.DataGridView1.Rows(e.RowIndex).Cells(i).Value Is Nothing Then
                _arr(i) = Me.DataGridView1.Rows(e.RowIndex).Cells(i).Value
            Else
                _arr(i) = ""
            End If

        Next
        Uc_Sample_data1.Data = _arr
    End Sub



    Private Sub btOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpenFile.Click
        Dim _fbd As New OpenFileDialog
        With _fbd
            .CheckFileExists = True
            .CheckPathExists = True
            .InitialDirectory = clsApplicationTypes.ExcelBookPath
            .Multiselect = False
            .RestoreDirectory = True
            .ShowHelp = False
            .Title = "select excel file.."
            .Filter = "Excel 2003 (*.xls)|*.xls|Excel 2007 (*.xlsm)| *.xlsm|Excel 2007 (*.xlsx)| *.xlsx|Any files(*.*)|*.*"
        End With
        Dim _res As DialogResult
        _res = _fbd.ShowDialog(Me)
        Select Case _res
            Case System.Windows.Forms.DialogResult.OK
                _connObj = New ExcelConnect(_fbd.FileName)
                _connObj.ShowExcell()
                Me.Uc_Sample_data1.Enabled = True
                clsApplicationTypes.ExcelBookPath = _fbd.FileName

        End Select
    End Sub

    Private Sub fmExcelConnect_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'закрыть приложение excel
        If Not _connObj Is Nothing Then _connObj.CloseExcell()

    End Sub

   

    Private Sub btCloseBook_Click(sender As System.Object, e As System.EventArgs) Handles btCloseBook.Click
        'закрыть текущую книгу
        'закрыть приложение excel
        If _connObj Is Nothing Then Exit Sub

        Me.ClearGrid()
        Uc_Sample_data1.ClearValues()
        _connObj.CloseExcell()
        _connObj = Nothing
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

''' <summary>
''' класс привязки данных к форме из листа книги
''' </summary>
''' <remarks></remarks>
Public Class ExcelConnect
    Dim _rowCount As Integer
    Dim _columnCount As Integer
    Dim _dataTable As List(Of List(Of String))


    Private WithEvents ExcelBook As Microsoft.Office.Interop.Excel.Application
    Private WithEvents ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet

    Public Event DataLoaded(ByVal sender As Object, ByVal ColumnCount As Integer, ByVal RowCount As Integer, ByVal data As List(Of List(Of String)))


    Public Sub New(ByVal BookPath As String)
        ExcelBook = New Microsoft.Office.Interop.Excel.Application
        ExcelBook.Workbooks.Open(BookPath)
        ExcelSheet = ExcelBook.ActiveWorkbook.ActiveSheet
    End Sub
    Public Sub ShowExcell()
        ExcelBook.Visible = True
    End Sub

    Public Sub CloseExcell()
        If Not _dataTable Is Nothing Then
            _dataTable.Clear()
        End If

        ExcelSheet = Nothing
        ExcelBook.Workbooks.Close()
        ExcelBook.Quit()
        ExcelBook = Nothing
    End Sub
    Private Sub e(ByVal target As Microsoft.Office.Interop.Excel.Range) Handles ExcelSheet.SelectionChange
        'load data from sheet
        _rowCount = target.Rows.Count
        _columnCount = target.Columns.Count

        'create row
        Dim _table As New List(Of List(Of String))
        Dim _row As List(Of String)
        For j = 0 To _rowCount - 1
            _row = New List(Of String)
            For i As Integer = 0 To _columnCount - 1
                If Not target.Cells(j + 1, i + 1).value Is Nothing Then
                    _row.Add(target.Cells(j + 1, i + 1).value.ToString)
                Else
                    _row.Add("")
                End If

            Next
            _table.Add(_row)
        Next

        _dataTable = _table


        RaiseEvent DataLoaded(Me, _columnCount, _rowCount, _dataTable)
    End Sub

    Private Sub ExcelBook_SheetSelectionChange(ByVal Sh As Object, ByVal Target As Microsoft.Office.Interop.Excel.Range) Handles ExcelBook.SheetSelectionChange
        Call e(Target)
    End Sub
End Class
