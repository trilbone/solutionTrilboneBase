Imports Service
Imports Service.clsApplicationTypes
Imports System.Linq
Imports System.Drawing.Imaging

Public Class fmImage
    Dim oFormText As String
    Dim oRatio As Single
    Private oSampleNumber As clsSampleNumber

    Private _formText As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal image_collection As List(Of Image), ByVal formtext As String)
        InitializeComponent()
        Dim _maxWight As Integer
        Dim _maxHeight As Integer

        For Each t In image_collection
            If t Is Nothing Then
                MsgBox("VAO")
            End If
        Next

        If image_collection.Count > 0 Then
            'вычислить макс. размер фото
            _maxWight = (From c In image_collection Select c.Width).Max
            _maxHeight = (From c In image_collection Select c.Height).Max

            Me.oFormText = formtext
            oRatio = _maxWight / _maxHeight
            If oRatio = 0 Then oRatio = 1
        End If


        Me.BindingSource1.DataSource = image_collection
        Me.BindingNavigator1.BindingSource = Me.BindingSource1
        Me.PictureBox1.DataBindings.Add("Image", Me.BindingSource1, "")
        If Not formtext = "" Then
            Call SelectPhoto()
        End If
        Me.resize_controls(New Size(_maxWight, _maxHeight), formtext)
    End Sub

    Public Sub New(ByVal image As Drawing.Image, ByVal formText As String)
        InitializeComponent()

        oFormText = formText
        oRatio = image.Size.Width / image.Size.Height
        If oRatio = 0 Then oRatio = 1
        'body
        Me.PictureBox1.Image = image
        Me.BindingNavigator1.Enabled = False
        Me.resize_controls(image.Size, formText)
    End Sub
    Public Sub New(ByVal image_collection As Windows.Forms.ImageList, ByVal formtext As String)
        InitializeComponent()
        Me.oFormText = formtext
        oRatio = image_collection.ImageSize.Width / image_collection.ImageSize.Height
        If oRatio = 0 Then oRatio = 1
        'Me.BindingSource1.SuspendBinding()
        Me.BindingSource1.DataSource = image_collection
        Me.BindingSource1.DataMember = "Images"
        Me.BindingNavigator1.BindingSource = Me.BindingSource1
        Me.PictureBox1.DataBindings.Add("Image", Me.BindingSource1, "")
        'Me.BindingSource1.ResumeBinding()
        If Not formtext = "" Then
            Call SelectPhoto()
        End If

        Me.resize_controls(image_collection.ImageSize, formtext)



    End Sub
    Public Sub New(ByVal SampleImageList As Service.SampleSourceImageList, ByVal formtext As String)
        InitializeComponent()
        Me.oFormText = formtext
        Me.oSampleNumber = SampleImageList.SampleNumber
        oRatio = SampleImageList.ImageListSize.Width / SampleImageList.ImageListSize.Height

        If oRatio = 0 Then oRatio = 1
        'Me.BindingSource1.SuspendBinding()
        Me.BindingSource1.DataSource = SampleImageList
        Me.BindingSource1.DataMember = "Images"
        Me.BindingNavigator1.BindingSource = Me.BindingSource1
        Me.PictureBox1.DataBindings.Add("Image", Me.BindingSource1, "")
        Me.DataBindings.Add("Text", Me.BindingSource1, "Tag")
        'Me.BindingSource1.ResumeBinding()
        'select photo
        If Not formtext = "" Then
            Call SelectPhoto()
        End If
        Me.resize_controls(SampleImageList.ImageListSize, formtext)
        '''''''''''''''''''-------------------

    End Sub
    Private Sub SelectPhoto()
        For Each t In Me.BindingSource1
            If Not CType(t, Image).Tag = oFormText Then
                Me.BindingSource1.MoveNext()
            Else
                Exit Sub
            End If
        Next
    End Sub


    Private Sub resize_controls(ByVal newsize As Size, ByVal formtext As String)
        'ширина формы в процентах от экрана
        Const _percentOfScreen As Single = 0.3
        Me.Text = formtext
        '
        'считаем ширину формы
        Me.Size = New Size(My.Computer.Screen.WorkingArea.Size.Width * _percentOfScreen, My.Computer.Screen.WorkingArea.Size.Height * _percentOfScreen)
        'работа с picturebox
        'привязка к верху формы
        Me.PictureBox1.Dock = DockStyle.Top
        'считаем высоту
        Me.PictureBox1.Size = New Size(newsize.Width / oRatio, (Me.ClientSize.Height - Me.BindingNavigator1.Size.Height))
    End Sub

    Private Sub fmImage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'утечка памяти
        Me.BindingSource1.DataSource = Nothing
        Me.BindingSource1.Dispose()
    End Sub

    Private Sub fmImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub fmImage_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

    End Sub

    Private Sub fmImage_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub

    Private Sub fmImage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'window position
        'Me.StartPosition = FormStartPosition.CenterScreen
        Me.oHasChanges = False
        CType(Me.PictureBox1, Control).AllowDrop = True
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        If Me.BindingSource1.Current Is Nothing Then Return
        Dim _fnt As New System.Drawing.Font("Arial", 16, Drawing.FontStyle.Bold)
        Dim _img As Image = Me.BindingSource1.Current
        Dim _string As String = ""
        If Not _img.Tag Is Nothing Then
            _string += IO.Path.GetFileName(_img.Tag)
        End If
        _string += " (" & PictureBox1.Image.Width & "x" & PictureBox1.Image.Height & " px)"



        e.Graphics.DrawString(_string, _fnt, Brushes.Red, New PointF(40, 20))

    End Sub

    Private Sub fmImage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'считаем высоту
        Dim _high As Integer = (Me.ClientSize.Height - Me.BindingNavigator1.Size.Height)
        Dim _width As Integer = _high * oRatio
        If oRatio = 0 Then oRatio = 1
        Me.PictureBox1.Size = New Size(_width / oRatio, _high)
    End Sub

    Private Sub fmImage_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        'считаем высоту
        Dim _high As Integer = (Me.ClientSize.Height - Me.BindingNavigator1.Size.Height)
        Dim _width As Integer = _high * oRatio
        If oRatio = 0 Then oRatio = 1
        Me.PictureBox1.Size = New Size(_width / oRatio, _high)
    End Sub

    Private oDelNamesCollection As New Collections.Specialized.StringCollection

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        oDelNamesCollection.Add(Me.BindingSource1.Current.tag)
    End Sub

    Public Event AcceptDelete(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageDelEventArg)
    Private oHasChanges As Boolean
    Private Sub btAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAccept.Click
        Dim _arg As New Service.clsApplicationTypes.fmImageDelEventArg
        _arg.ImageNames = oDelNamesCollection
        RaiseEvent AcceptDelete(Me, _arg)
        'вызвать зарегестрированных
        If Not Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate Is Nothing Then
            Service.clsApplicationTypes.DelegatStorefmImageDeleteDelegate.Invoke(Me, _arg)
            Me.oHasChanges = True

        End If
    End Sub
    ''' <summary>
    ''' вернет да, если были изменения в фотках
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasChanges As Boolean
        Get
            Return oHasChanges
        End Get
    End Property
    Private Sub btAddImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddImage.Click
        Dim _dg As New OpenFileDialog
        With _dg
            .DefaultExt = "jpg"
            .Multiselect = True
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .RestoreDirectory = True
            .ValidateNames = True
            .Title = "выбор файлов для добавления"
        End With
        _dg.ShowDialog()
        If Not _dg.FileName = "" Then
            Dim _arg As New Service.clsApplicationTypes.fmImageCopyEventArg
            Dim _coll As New Specialized.StringCollection
            For Each t In _dg.FileNames
                _coll.Add(IO.Path.GetFileName(t))
            Next
            ReDim _arg.ImageNames(_dg.FileNames.Length - 1)
            _coll.CopyTo(_arg.ImageNames, 0)
            _arg.ImagesPath = IO.Path.GetDirectoryName(_dg.FileName)

            RaiseEvent NeedCopyFiles(Me, _arg)
            'вызвать зарегестрированных
            If Not Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate Is Nothing Then
                Service.clsApplicationTypes.DelegatStorefmImageCopyDelegate.Invoke(Me, _arg)
                Me.oHasChanges = True
            End If
            Me.BindingSource1.ResetBindings(False)
        End If




    End Sub
    Public Event NeedCopyFiles(ByVal sender As Object, ByVal e As Service.clsApplicationTypes.fmImageCopyEventArg)





    Private odragBoxFromMouseDown As Rectangle

    Private Sub imgLwPhoto_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        ' Remember the point where the mouse down occurred. The DragSize indicates
        ' the size that the mouse can move before a drag event should be started.                
        Dim dragSize As Size = SystemInformation.DragSize
        dragSize = Size.Add(dragSize, New Size(20, 20))
        ' Create a rectangle using the DragSize, with the mouse position being
        ' at the center of the rectangle.
        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
                                                        e.Y - (dragSize.Height / 2)), dragSize)
    End Sub

    Private Sub imgLwPhoto_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
            Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then
             
                If e.X < odragBoxFromMouseDown.X Then
                    'точку ведем вправо
                    If oClick = False Then
                        oDirection = -1
                        oClick = True
                    End If
                Else
                    'точку ведем влево
                    If oClick = False Then
                        oDirection = 1
                        oClick = True
                    End If
                End If

                If (Not sender.ClientRectangle.Contains(e.X, e.Y)) Then
                    'найдем элемент списка
                    Dim ms As New IO.MemoryStream
                    Dim ms2 As New IO.MemoryStream
                    Me.BindingSource1.Current.Save(ms, ImageFormat.Bmp)
                    Dim bytes() As Byte = ms.GetBuffer
                    ms2.Write(bytes, 14, CInt(ms.Length - 14))
                    ms.Position = 0
                    Dim obj As New DataObject
                    obj.SetData("DeviceIndependentBitmap", ms2)
                    sender.DoDragDrop(obj, DragDropEffects.Copy)
                    ms.Close()
                    ms2.Close()
                End If
            End If
      

        End If
    End Sub
    Private oClick As Boolean
    Private oDirection As Integer
    Private Sub imgLwPhoto_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        ' Reset the drag rectangle when the mouse button is raised.
        If (sender.ClientRectangle.Contains(e.X, e.Y)) Then
            If oDirection > 0 Then
                Me.BindingSource1.MoveNext()
            Else
                Me.BindingSource1.MovePrevious()
            End If

        End If

        odragBoxFromMouseDown = Rectangle.Empty
        oClick = False
    End Sub


   
    '#Region "Drag"

    '    'Private odragBoxFromMouseDown As Rectangle

    '    Private Sub pbLabel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown

    '        ' Remember the point where the mouse down occurred. The DragSize indicates
    '        ' the size that the mouse can move before a drag event should be started.                
    '        Dim dragSize As Size = SystemInformation.DragSize

    '        ' Create a rectangle using the DragSize, with the mouse position being
    '        ' at the center of the rectangle.
    '        odragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), _
    '                                                        e.Y - (dragSize.Height / 2)), dragSize)

    '    End Sub

    '    Private Sub pbLabel_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
    '        If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then

    '            ' If the mouse moves outside the rectangle, start the drag.
    '            If (Rectangle.op_Inequality(odragBoxFromMouseDown, Rectangle.Empty) And _
    '                Not odragBoxFromMouseDown.Contains(e.X, e.Y)) Then

    '                'variant 1
    '                'Dim _obg As New DataObject
    '                '_obg.SetData(DataFormats.Dib, True, pbLabel.Image)
    '                'pbLabel.DoDragDrop(_obg, DragDropEffects.Copy)

    '                'variant 2 --OK!!
    '                Dim ms As New IO.MemoryStream
    '                Dim ms2 As New IO.MemoryStream
    '                sender.Image.Save(ms, ImageFormat.Bmp)
    '                Dim bytes() As Byte = ms.GetBuffer
    '                ms2.Write(bytes, 14, CInt(ms.Length - 14))
    '                ms.Position = 0
    '                Dim obj As New DataObject
    '                obj.SetData("DeviceIndependentBitmap", ms2)
    '                sender.DoDragDrop(obj, DragDropEffects.Copy)
    '                ms.Close()
    '                ms2.Close()

    '                'variant 3
    '                '                // declarations
    '                '[DllImport("user32.dll")]
    '                'static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    '                '[DllImport("user32.dll")]
    '                'static extern bool OpenClipboard(IntPtr hWndNewOwner);

    '                '[DllImport("user32.dll")]
    '                'static extern bool EmptyClipboard();

    '                '[DllImport("user32.dll")]
    '                'static extern bool CloseClipboard();

    '                'public static uint CF_ENHMETAFILE = 14;

    '                '...

    '                'Bitmap img = (Bitmap)Bitmap.FromFile(@"c:\TestImage.jpg",true);
    '                '// create graphics object for metafile
    '                'Graphics g = CreateGraphics();
    '                'IntPtr hdc = g.GetHdc();
    '                'Metafile meta = new Metafile(@"SampleMetafilegdiplus.emf", hdc );
    '                'g.ReleaseHdc(hdc);
    '                'g.Dispose();
    '                '// create a metafile image from the jpeg image
    '                'g = Graphics.FromImage(meta);
    '                'g.DrawImage(img, new Point(0,0));
    '                'g.Dispose();
    '                '// get a handle to the metafile
    '                'IntPtr hEmf = meta.GetHenhmetafile();
    '                'meta.Dispose();
    '                '// open the clipboard
    '                'OpenClipboard(this.Handle); // your Form's Window handle
    '                'EmptyClipboard();
    '                '// place the handle to the metafile on to the clipboard
    '                'SetClipboardData(CF_ENHMETAFILE, hEmf);
    '                'CloseClipboard();
    '            End If
    '        End If
    '    End Sub


    '    Private Sub pbLabel_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
    '        ' Reset the drag rectangle when the mouse button is raised.
    '        odragBoxFromMouseDown = Rectangle.Empty
    '    End Sub

    '#End Region

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click

    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click

    End Sub
End Class