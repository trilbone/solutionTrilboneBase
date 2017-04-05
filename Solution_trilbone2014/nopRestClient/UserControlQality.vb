Imports System.Windows.Forms
Imports System.Globalization
''' <summary>
''' используем ТОЛЬКО в этом проэкте
''' </summary>
''' <remarks></remarks>
Friend Class UserControlQality
    ''' <summary>
    ''' показывает, что происходит замена текста
    ''' </summary>
    ''' <remarks></remarks>
    Private oTextChanging As Boolean
    ''' <summary>
    ''' хранит текущие выбранные значения
    ''' </summary>
    ''' <remarks></remarks>
    Private oArrCurrentValue(3) As Integer

    Dim oCurrentCulture As CultureInfo

    ''' <summary>
    ''' все значения
    ''' </summary>
    ''' <remarks></remarks>
    Dim oValueArray As List(Of clsQuality)

    Private oIsInit As Boolean

    Private Class clsQuality
        Property EN As String
        Property RU As String
        Property Index As Integer
        Property Volume As Integer
        Property ENVolume As String
        Property RUVolume As String
    End Class

    Public Sub New()
        oIsInit = True
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        init()
        oIsInit = False
        If rbEnglish.Checked Then
            oCurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        End If
        If rbRussian.Checked Then
            oCurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU")
        End If
        Me.Culture = oCurrentCulture
    End Sub

    Private Sub init()

        '--------------------
        oValueArray = New List(Of clsQuality)
        'препарация
        oValueArray.Add(New clsQuality With {.Volume = 0, .Index = 5, .ENVolume = "Preparation quality", .RUVolume = "Качество препарации", .EN = "no preparation", .RU = "без препарации"})
        oValueArray.Add(New clsQuality With {.Volume = 0, .Index = 4, .ENVolume = "Preparation quality", .RUVolume = "Качество препарации", .EN = "nice", .RU = "отличное"})
        oValueArray.Add(New clsQuality With {.Volume = 0, .Index = 3, .ENVolume = "Preparation quality", .RUVolume = "Качество препарации", .EN = "good", .RU = "хорошее"})
        oValueArray.Add(New clsQuality With {.Volume = 0, .Index = 2, .ENVolume = "Preparation quality", .RUVolume = "Качество препарации", .EN = "normal", .RU = "обычное"})
        oValueArray.Add(New clsQuality With {.Volume = 0, .Index = 1, .ENVolume = "Preparation quality", .RUVolume = "Качество препарации", .EN = "below average", .RU = "ниже обычного"})

        ' oValueArray.Add(New clsQuality With {.Volume = 1, .Index = 5, .ENVolume = "Preservation", .RUVolume = "Сохранность", .EN = "", .RU = ""})
        oValueArray.Add(New clsQuality With {.Volume = 1, .Index = 4, .ENVolume = "Preservation", .RUVolume = "Сохранность", .EN = "nice", .RU = "отличная"})
        oValueArray.Add(New clsQuality With {.Volume = 1, .Index = 3, .ENVolume = "Preservation", .RUVolume = "Сохранность", .EN = "good", .RU = "хорошая"})
        oValueArray.Add(New clsQuality With {.Volume = 1, .Index = 2, .ENVolume = "Preservation", .RUVolume = "Сохранность", .EN = "normal", .RU = "обычная"})
        oValueArray.Add(New clsQuality With {.Volume = 1, .Index = 1, .ENVolume = "Preservation", .RUVolume = "Сохранность", .EN = "below average", .RU = "ниже обычной"})

        oValueArray.Add(New clsQuality With {.Volume = 2, .Index = 5, .ENVolume = "Reconstruction", .RUVolume = "Реконструкция", .EN = "no reconstruction", .RU = "без реконструкции"})
        oValueArray.Add(New clsQuality With {.Volume = 2, .Index = 4, .ENVolume = "Reconstruction", .RUVolume = "Реконструкция", .EN = "less then 3%", .RU = "менее чем 3%"})
        oValueArray.Add(New clsQuality With {.Volume = 2, .Index = 3, .ENVolume = "Reconstruction", .RUVolume = "Реконструкция", .EN = "less then 5%", .RU = "менее чем 5%"})
        oValueArray.Add(New clsQuality With {.Volume = 2, .Index = 2, .ENVolume = "Reconstruction", .RUVolume = "Реконструкция", .EN = "less then 10%", .RU = "менее чем 10%"})
        oValueArray.Add(New clsQuality With {.Volume = 2, .Index = 1, .ENVolume = "Reconstruction", .RUVolume = "Реконструкция", .EN = "less then 15%", .RU = "менее чем 15%"})

        'oValueArray.Add(New clsQuality With {.Volume = 3, .Index = 5, .ENVolume = "Matrix reconstruction", .RUVolume = "", .EN = "", .RU = ""})
        'oValueArray.Add(New clsQuality With {.Volume = 3, .Index = 4, .ENVolume = "Matrix reconstruction", .RUVolume = "", .EN = "", .RU = ""})
        oValueArray.Add(New clsQuality With {.Volume = 3, .Index = 3, .ENVolume = "Matrix reconstruction", .RUVolume = "Реконструкция породы", .EN = "no reconstruction (original matrix)", .RU = "без реконструкции (оригинальная порода)"})
        oValueArray.Add(New clsQuality With {.Volume = 3, .Index = 2, .ENVolume = "Matrix reconstruction", .RUVolume = "Реконструкция породы", .EN = "some crack (original matrix)", .RU = "некоторые трещины и расколы (оригинальная порода)"})
        oValueArray.Add(New clsQuality With {.Volume = 3, .Index = 1, .ENVolume = "Matrix reconstruction", .RUVolume = "Реконструкция породы", .EN = "removed on other matrix", .RU = "пересажен на другую породу"})
    End Sub



#Region "События эу"
    ''' <summary>
    ''' очистка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btClearCondition_Click(sender As Object, e As EventArgs) Handles btClearCondition.Click
        Clear()
    End Sub

    ''' <summary>
    ''' формирует массив значений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_CheckedChanged(sender As Object, e As EventArgs) Handles _
        rbPrep_no.CheckedChanged, rbPrep_below.CheckedChanged, rbPrep_good.CheckedChanged, rbPrep_nice.CheckedChanged, rbPrep_normal.CheckedChanged, _
        rbPreserv_below.CheckedChanged, rbPreserv_good.CheckedChanged, rbPreserv_nice.CheckedChanged, rbPreserv_normal.CheckedChanged, _
        rbReconstr_no.CheckedChanged, rbReconstr_5.CheckedChanged, rbReconstr_3.CheckedChanged, rbReconstr_10.CheckedChanged, rbReconstr_15.CheckedChanged, _
        rbMatrix_no.CheckedChanged, rbMatrix_crack.CheckedChanged, rbMatrix_removed.CheckedChanged

        oArrCurrentValue(0) = 0
        oArrCurrentValue(1) = 0
        oArrCurrentValue(2) = 0
        oArrCurrentValue(3) = 0

        If rbPrep_no.Checked Then
            oArrCurrentValue(0) = 5
        End If
        If rbPrep_nice.Checked Then
            oArrCurrentValue(0) = 4
        End If
        If rbPrep_good.Checked Then
            oArrCurrentValue(0) = 3
        End If
        If rbPrep_normal.Checked Then
            oArrCurrentValue(0) = 2
        End If
        If rbPrep_below.Checked Then
            oArrCurrentValue(0) = 1
        End If
        '------------
        'If rbPreserv_nice.Checked Then
        '    _arr(1) = 5
        'End If
        If rbPreserv_nice.Checked Then
            oArrCurrentValue(1) = 4
        End If
        If rbPreserv_good.Checked Then
            oArrCurrentValue(1) = 3
        End If
        If rbPreserv_normal.Checked Then
            oArrCurrentValue(1) = 2
        End If
        If rbPreserv_below.Checked Then
            oArrCurrentValue(1) = 1
        End If
        '------------
        oArrCurrentValue(2) = 0
        If rbReconstr_no.Checked Then
            oArrCurrentValue(2) = 5
        End If
        If rbReconstr_5.Checked Then
            oArrCurrentValue(2) = 3
        End If
        If rbReconstr_3.Checked Then
            oArrCurrentValue(2) = 4
        End If
        If rbReconstr_10.Checked Then
            oArrCurrentValue(2) = 2
        End If
        If rbReconstr_15.Checked Then
            oArrCurrentValue(2) = 1
        End If
        '------------
        '------------
        'If rbMatrix_no.Checked Then
        '    _arr(3) = 5
        'End If
        'If rbMatrix_no.Checked Then
        '    _arr(3) = 4
        'End If
        oArrCurrentValue(3) = 0
        If rbMatrix_no.Checked Then
            oArrCurrentValue(3) = 3
        End If
        If rbMatrix_crack.Checked Then
            oArrCurrentValue(3) = 2
        End If
        If rbMatrix_removed.Checked Then
            oArrCurrentValue(3) = 1
        End If
        '-------------
        DescriptionChanged()
    End Sub

    ''' <summary>
    ''' вернет значение без построения описания (как есть)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btAccept_Click(sender As Object, e As EventArgs) Handles btAccept.Click
        Me.Tag = rtbConditionDescription.Text
        Dim _onlygenerate = Me.GetString(oArrCurrentValue, oCurrentCulture)
        RaiseEvent QualityTextChanged(Me, New QualityTextChangedEventArgs With {.text = rtbConditionDescription.Text, .Values = oArrCurrentValue, .GeneratedText = _onlygenerate, .Culture = oCurrentCulture, .GetText = AddressOf Me.GetString})
        RaiseEvent DescriptionCompleted(Me, EventArgs.Empty)
    End Sub

#End Region

#Region "Открытые методы"

    Public Property Culture As CultureInfo
        Get
            Return oCurrentCulture
        End Get
        Set(value As CultureInfo)
            oCurrentCulture = value
            If oCurrentCulture.Name = "ru-RU" Then
                ChangeToRus()
            Else
                ChangeToEng()
            End If
        End Set
    End Property


    ''' <summary>
    ''' очистка ЭУ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        Array.Clear(oArrCurrentValue, 0, oArrCurrentValue.Length)
        For Each ctl In tpPrep.Controls
            If TypeOf ctl Is RadioButton Then
                CType(ctl, RadioButton).Checked = False
            End If
        Next
        For Each ctl In tpPreserv.Controls
            If TypeOf ctl Is RadioButton Then
                CType(ctl, RadioButton).Checked = False
            End If
        Next
        For Each ctl In tpReconstr.Controls
            If TypeOf ctl Is RadioButton Then
                CType(ctl, RadioButton).Checked = False
            End If
        Next
        For Each ctl In tpMatrix.Controls
            If TypeOf ctl Is RadioButton Then
                CType(ctl, RadioButton).Checked = False
            End If
        Next
        Me.tbcItemSpecifics.SelectedTab = tpPrep
        DescriptionChanged()
    End Sub


    Public Event QualityTextChanged(sender As Object, e As QualityTextChangedEventArgs)
    Public Event DescriptionCompleted(sender As Object, e As EventArgs)

    Public Class QualityTextChangedEventArgs
        Inherits EventArgs
        Public Property GeneratedText As String
        Public Property text As String
        Public Property Values As Integer()
        Public Property Culture As CultureInfo
        Public Property GetText As Func(Of Integer(), CultureInfo, String)
    End Class

    ''' <summary>
    ''' текущий текст из блока текста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QualityText As String
        Get
            Return rtbConditionDescription.Text
        End Get
    End Property

    ''' <summary>
    ''' вернет строку по выбранным отметкам
    ''' </summary>
    ''' <param name="_arr"></param>
    ''' <param name="lang"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetString(_arr As Integer(), lang As CultureInfo) As String
        Dim _out As String = ""

        If lang.Name = "ru-RU" Then
            For i = 0 To _arr.Count - 1
                Dim j = i
                If _arr(j) > 0 Then
                    _out += oValueArray.Where(Function(x) x.Volume = j).FirstOrDefault.RUVolume
                    _out += ": "
                    _out += oValueArray.Where(Function(x) x.Volume = j And x.Index = _arr(j)).FirstOrDefault.RU
                    _out += "; "
                End If
            Next
        End If

        If lang.Name = "en-US" Then
            For i = 0 To _arr.Count - 1
                Dim j = i
                If _arr(j) > 0 Then
                    _out += oValueArray.Where(Function(x) x.Volume = j).FirstOrDefault.ENVolume
                    _out += ": "
                    _out += oValueArray.Where(Function(x) x.Volume = j And x.Index = _arr(j)).FirstOrDefault.EN
                    _out += "; "
                End If
            Next
        End If

        Return _out.TrimEnd("; ")

    End Function

    ''' <summary>
    ''' вернет массив значений
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetValues() As Integer()
        Return oArrCurrentValue
    End Function

#End Region

    ''' <summary>
    ''' описание изменилось
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DescriptionChanged()
        Me.rtbConditionDescription.Text = GetString(oArrCurrentValue, oCurrentCulture)
        Me.Tag = rtbConditionDescription.Text
        RaiseEvent QualityTextChanged(Me, New QualityTextChangedEventArgs With {.text = rtbConditionDescription.Text, .Values = oArrCurrentValue, .GeneratedText = rtbConditionDescription.Text, .Culture = oCurrentCulture, .GetText = AddressOf Me.GetString})
    End Sub

#Region "Языковые"



    Private Sub ChangeToEng()
        rbEnglish.Checked = True
        tpPrep.Text = oValueArray.Where(Function(x) x.Volume = 0).FirstOrDefault.ENVolume

        rbPrep_no.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 5).FirstOrDefault.EN
        rbPrep_nice.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 4).FirstOrDefault.EN
        rbPrep_good.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 3).FirstOrDefault.EN
        rbPrep_normal.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 2).FirstOrDefault.EN
        rbPrep_below.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 1).FirstOrDefault.EN

        tpPreserv.Text = oValueArray.Where(Function(x) x.Volume = 1).FirstOrDefault.ENVolume
        rbPreserv_nice.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 4).FirstOrDefault.EN
        rbPreserv_good.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 3).FirstOrDefault.EN
        rbPreserv_normal.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 2).FirstOrDefault.EN
        rbPreserv_below.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 1).FirstOrDefault.EN

        tpReconstr.Text = oValueArray.Where(Function(x) x.Volume = 2).FirstOrDefault.ENVolume
        rbReconstr_no.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 5).FirstOrDefault.EN
        rbReconstr_3.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 4).FirstOrDefault.EN
        rbReconstr_5.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 3).FirstOrDefault.EN
        rbReconstr_10.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 2).FirstOrDefault.EN
        rbReconstr_15.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 1).FirstOrDefault.EN

        tpMatrix.Text = oValueArray.Where(Function(x) x.Volume = 3).FirstOrDefault.ENVolume
        rbMatrix_no.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 3).FirstOrDefault.EN
        rbMatrix_crack.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 2).FirstOrDefault.EN
        rbMatrix_removed.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 1).FirstOrDefault.EN
        DescriptionChanged()
    End Sub

    Private Sub ChangeToRus()
        rbRussian.Checked = True
        tpPrep.Text = oValueArray.Where(Function(x) x.Volume = 0).FirstOrDefault.RUVolume
        rbPrep_no.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 5).FirstOrDefault.RU
        rbPrep_nice.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 4).FirstOrDefault.RU
        rbPrep_good.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 3).FirstOrDefault.RU
        rbPrep_normal.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 2).FirstOrDefault.RU
        rbPrep_below.Text = oValueArray.Where(Function(x) x.Volume = 0 And x.Index = 1).FirstOrDefault.RU

        tpPreserv.Text = oValueArray.Where(Function(x) x.Volume = 1).FirstOrDefault.RUVolume
        rbPreserv_nice.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 4).FirstOrDefault.RU
        rbPreserv_good.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 3).FirstOrDefault.RU
        rbPreserv_normal.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 2).FirstOrDefault.RU
        rbPreserv_below.Text = oValueArray.Where(Function(x) x.Volume = 1 And x.Index = 1).FirstOrDefault.RU

        tpReconstr.Text = oValueArray.Where(Function(x) x.Volume = 2).FirstOrDefault.RUVolume
        rbReconstr_no.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 5).FirstOrDefault.RU
        rbReconstr_3.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 4).FirstOrDefault.RU
        rbReconstr_5.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 3).FirstOrDefault.RU
        rbReconstr_10.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 2).FirstOrDefault.RU
        rbReconstr_15.Text = oValueArray.Where(Function(x) x.Volume = 2 And x.Index = 1).FirstOrDefault.RU

        tpMatrix.Text = oValueArray.Where(Function(x) x.Volume = 3).FirstOrDefault.RUVolume
        rbMatrix_no.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 3).FirstOrDefault.RU
        rbMatrix_crack.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 2).FirstOrDefault.RU
        rbMatrix_removed.Text = oValueArray.Where(Function(x) x.Volume = 3 And x.Index = 1).FirstOrDefault.RU
        DescriptionChanged()
    End Sub

    Private Sub rbEnglish_CheckedChanged(sender As Object, e As EventArgs) Handles rbEnglish.CheckedChanged
        If oIsInit Then Return
        If rbEnglish.Checked Then
            Me.Culture = CultureInfo.CreateSpecificCulture("en-US")
        End If
    End Sub

    Private Sub rbRussian_CheckedChanged(sender As Object, e As EventArgs) Handles rbRussian.CheckedChanged
        If oIsInit Then Return
        If rbRussian.Checked Then
            Me.Culture = CultureInfo.CreateSpecificCulture("ru-RU")
        End If
    End Sub






#End Region






End Class
