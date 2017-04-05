Imports System.Linq
''' <summary>
''' размещает имаджи на странице определенного размера. В пикселах.
''' </summary>
''' <remarks></remarks>
Public Class clsPage
    ''' <summary>
    ''' размер поверхности устройства - ширина в пикселах
    ''' </summary>
    ''' <remarks></remarks>
    Private oDeviceMaxWidth As Single
    ''' <summary>
    ''' размер поверхности устройства - высота в пикселах
    ''' </summary>
    ''' <remarks></remarks>
    Private oDeviceMaxHeigh As Single
    ''' <summary>
    ''' означает, что страница заполнена
    ''' </summary>
    ''' <remarks></remarks>
    Private oFlagFull As Boolean
    ''' <summary>
    ''' коллекция строк этикеток на странице
    ''' </summary>
    ''' <remarks></remarks>
    Private oRowCollection As List(Of Row)

    ''' <summary>
    ''' координаты следующей строки
    ''' </summary>
    ''' <remarks></remarks>
    Private oStartPositionOfNewRowByPage As PointF

    Private Sub AddNewRow()
        'новая строка добавляется всегда нулевой высоты. Далее при добавлении этикетки высота изменяется через событие RowHeightChanged

        Dim _newrow = New Row(oStartPositionOfNewRowByPage, Me.oDeviceMaxWidth - oStartPositionOfNewRowByPage.X)
        Me.oRowCollection.Add(_newrow)
        AddHandler _newrow.RowHeightChanged, AddressOf RowHeightChanged_EventHandler
    End Sub

    ''' <summary>
    ''' показывает, что страница заполнена
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsFull As Boolean
        Get
            Return Me.oFlagFull
        End Get
    End Property

    Private oNextPage As clsPage

    ''' <summary>
    ''' добавить этикетку на страницу/размер указать в мм
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddLabel(value As KeyValuePair(Of Image, SizeF)) As Boolean
        Return AddLabel(value.Key, value.Value)
    End Function


    ''' <summary>
    ''' добавить этикетку на страницу/ размер указать в мм
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function AddLabel(Image As Image, labelSize As SizeF) As Boolean
        Debug.Assert(Not Image Is Nothing)
        If Image Is Nothing Then Return False
        If Me.IsFull Then
            Return False
        End If

        If oRowCollection.Count = 0 Then
            Me.AddNewRow()
        ElseIf Me.oRowCollection.Item(Me.oRowCollection.Count - 1).RowFull Then
            Me.AddNewRow()
        End If

        Dim _res = Me.oRowCollection.Item(Me.oRowCollection.Count - 1).AddLabel(New Label(Image, labelSize))

        If _res = False Then
            'новая строка
            Me.AddNewRow()
            _res = Me.oRowCollection.Item(Me.oRowCollection.Count - 1).AddLabel(New Label(Image, labelSize))
        End If

        Return _res

    End Function

    Private Sub New()
    End Sub
    ''' <summary>
    ''' указать размер панели для размещения фото
    ''' </summary>
    ''' <param name="panelsize"></param>
    ''' <remarks></remarks>
    Public Sub New(panelsize As RectangleF)
        Me.New(panelsize.Width, panelsize.Height)
    End Sub

    ''' <summary>
    ''' указать размер панели для размещения фото
    ''' </summary>
    ''' <param name="panelsize"></param>
    ''' <remarks></remarks>
    Public Sub New(panelsize As SizeF)
        Me.New(panelsize.Width, panelsize.Height)
    End Sub

    ''' <summary>
    ''' указать размер панели для размещения фото
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(PanelWidth As Single, PanelHeight As Single)
        'получить с устройства размер страницы
        Me.oDeviceMaxHeigh = PanelHeight
        Me.oDeviceMaxWidth = PanelWidth
        Me.oStartPositionOfNewRowByPage = New PointF(0, 0)
        Me.oRowCollection = New List(Of Row)
        oFlagFull = False
    End Sub

    ''' <summary>
    ''' рисует этикетки на панели. PageUnit задаст систему координат
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DrawLabels(ByRef GraficsPanel As System.Drawing.Graphics, PageUnit As GraphicsUnit)
        For Each t In Me.oRowCollection
            For Each l In t.LabelCollection
                If l.IsPlaced Then
                    GraficsPanel.PageUnit = PageUnit
                    Try
                        GraficsPanel.DrawImage(l.Image, l.StartPositionByPage.X, l.StartPositionByPage.Y, l.LabelSize_mm.Width, l.LabelSize_mm.Height)
                    Catch ex As Exception

                    End Try
                End If
            Next
        Next
    End Sub

    Private Class Row
        ''' <summary>
        ''' стартовая позиция строки в целом
        ''' </summary>
        ''' <remarks></remarks>
        Private oStartPositionByPage As PointF
        ''' <summary>
        ''' максимальный прямоугольник строки(устанавливается придобавлении новой этикетки
        ''' </summary>
        ''' <remarks></remarks>
        Private oMaxSize As SizeF
        ''' <summary>
        ''' означает, что строка заполнена
        ''' </summary>
        ''' <remarks></remarks>
        Private oFlagFull As Boolean
        ''' <summary>
        ''' коллекция этикеток
        ''' </summary>
        ''' <remarks></remarks>
        Private oLabelCollection As List(Of Label)
        ''' <summary>
        ''' стартовая позиция для следующей этикетки
        ''' </summary>
        ''' <remarks></remarks>
        Private oStartPositionOfNewLabelByRow As PointF

        Public Event RowHeightChanged(sender As Object, e As RowHeigthChangedEventArgs)

        Public Class RowHeigthChangedEventArgs
            Inherits EventArgs
            Public NewHeight As Single
            ''' <summary>
            ''' позволяет отменить операцию
            ''' </summary>
            ''' <remarks></remarks>
            Public Cancel As Boolean
        End Class
        ''' <summary>
        ''' будет установлен в случае неудачной попытки разместить этикетку
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RowFull As Boolean
            Get
                Return oFlagFull
            End Get
        End Property

        Public ReadOnly Property LabelCollection As List(Of Label)
            Get
                Return Me.oLabelCollection
            End Get
        End Property

        Public Function AddLabel(label As Label) As Boolean
            'вычислить стартувую позицию след.этикетки
            Dim _currentByRow = oStartPositionOfNewLabelByRow
            Dim _currentByPage = oStartPositionByPage

            'oStartPositionOfNewLabelByRow.Offset(label.ImageSize.Width + My.Settings.dx, 0)
            Dim _offset = New SizeF(label.LabelSize_mm.Width + My.Settings.dx, 0)
            oStartPositionOfNewLabelByRow = oStartPositionOfNewLabelByRow + _offset

            'oStartPositionByPage.Offset(label.ImageSize.Width + My.Settings.dx, 0)
            _offset = New SizeF(label.LabelSize_mm.Width + My.Settings.dx, 0)
            oStartPositionByPage = oStartPositionByPage + _offset


            If (_currentByRow.X + label.LabelSize_mm.Width) > oMaxSize.Width Then
                'не лезит, вернем все на место
                oStartPositionOfNewLabelByRow = _currentByRow
                oStartPositionByPage = _currentByPage
                Me.oFlagFull = True
                label.IsPlaced = False
                Return False
            End If
            'этикетка влазит. задать координаты страницы
            label.StartPositionByPage = _currentByPage
            'проверить высоту
            If Me.oMaxSize.Height < label.LabelSize_mm.Height Then
                Dim _Arg = New RowHeigthChangedEventArgs With {.NewHeight = label.LabelSize_mm.Height, .Cancel = False}
                RaiseEvent RowHeightChanged(Me, _Arg)
                If _Arg.Cancel Then
                    'строка не влазит на страницу
                    'не лезит, вернем все на место
                    oStartPositionOfNewLabelByRow = _currentByRow
                    oStartPositionByPage = _currentByPage
                    Me.oFlagFull = True
                    label.IsPlaced = False
                    Return False
                Else
                    Me.oMaxSize = New SizeF(Me.oMaxSize.Width, label.LabelSize_mm.Height)
                End If

            End If
            'привести к координатам страницы
            label.IsPlaced = True
            Me.oLabelCollection.Add(label)
            Return True
        End Function

        Public Sub New(startPositionByPage As PointF, width As Single)
            oStartPositionByPage = startPositionByPage
            Me.oLabelCollection = New List(Of Label)
            'первая этикетка с нулевой позиции
            oStartPositionOfNewLabelByRow = New PointF(0, 0)
            oMaxSize = New SizeF(width, 0)
            oFlagFull = False
        End Sub

        Private Sub New()

        End Sub
    End Class

    Private Class Label
        ''' <summary>
        ''' собственно изображение на печать
        ''' </summary>
        ''' <remarks></remarks>
        Private oImage As Image
        ''' <summary>
        ''' позиция верх. лев. угла в координатах страницы
        ''' </summary>
        ''' <remarks></remarks>
        Private oStartPositionByPage As PointF
        ''' <summary>
        ''' размер этикетки в дюймах
        ''' </summary>
        ''' <remarks></remarks>
        Private oLabelSize As SizeF

        ''' <summary>
        ''' указывает, что этикетка включена в страницу
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsPlaced As Boolean

        Public ReadOnly Property LabelSize_mm As SizeF
            Get
                Return oLabelSize
            End Get
        End Property

        Public ReadOnly Property Image As Image
            Get
                Return oImage
            End Get
        End Property

        'Public ReadOnly Property ImageSize As Size
        '    Get
        '        Return oImage.Size
        '    End Get
        'End Property
        Private Sub New()

        End Sub

        Public Sub New(Image As Image, labelsize As SizeF)
            oImage = Image
            oLabelSize = labelsize
        End Sub

        Public Property StartPositionByPage As PointF
            Get
                Return oStartPositionByPage
            End Get
            Set(value As PointF)
                oStartPositionByPage = value
            End Set
        End Property
    End Class

    Private Sub RowHeightChanged_EventHandler(sender As Object, e As Row.RowHeigthChangedEventArgs)
        'проверка возможности растянуть строку
        If Me.oStartPositionOfNewRowByPage.Y + e.NewHeight > Me.oDeviceMaxHeigh Then
            'растягивание строки невозможно. Отменить операцию
            e.Cancel = True
            Me.oFlagFull = True
            Exit Sub
        End If
        Dim _offset = New SizeF(0, e.NewHeight + My.Settings.dy)
        Me.oStartPositionOfNewRowByPage = Me.oStartPositionOfNewRowByPage + _offset
        'Me.oStartPositionOfNewRowByPage.Offset(0, e.NewHeight + My.Settings.dy)
    End Sub

End Class
