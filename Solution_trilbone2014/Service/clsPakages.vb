Public MustInherit Class clsPakages
    Private oHeight As Decimal
    Private oSizeA As Decimal
    Private oSizeB As Decimal
    Private oWeight As Decimal
    Private oEan13Shot As String
    Private oPublicName As String
    Private oName As String

    ''' <summary>
    ''' размер а
    ''' </summary>
    Public Property SizeA As Decimal
        Get
            Return oSizeA
        End Get
        Set(value As Decimal)
            oSizeA = value
        End Set
    End Property

    ''' <summary>
    ''' размер б
    ''' </summary>
    Public Property SizeB As Decimal
        Get
            Return oSizeB
        End Get
        Set(value As Decimal)
            oSizeB = value
        End Set
    End Property

    ''' <summary>
    ''' высота
    ''' </summary>
    Public Property Height As Decimal
        Get
            Return oHeight
        End Get
        Set(value As Decimal)
            oHeight = value
        End Set
    End Property

    ''' <summary>
    ''' вес
    ''' </summary>
    Public Property Weight As Decimal
        Get
            Return oWeight
        End Get
        Set(value As Decimal)
            oWeight = value
        End Set
    End Property

    ''' <summary>
    ''' имя для пользователя
    ''' </summary>
    Public Property PublicName As String
        Get
            Return oPublicName
        End Get
        Set(value As String)
            oPublicName = value
        End Set
    End Property

    ''' <summary>
    ''' короткий код из базы
    ''' </summary>
    Public Property Ean13Shot As String
        Get
            Return oEan13Shot
        End Get
        Set(value As String)
            oEan13Shot = value
        End Set
    End Property

    ''' <summary>
    ''' короткое имя из Settings
    ''' </summary>
    Public Property Name As String
        Get
            Return oName
        End Get
        Set(value As String)
            oName = value
        End Set
    End Property

    Private oIsApproximateSizes As Boolean
    ''' <summary>
    ''' Размер указан не точно
    ''' </summary>
    Public ReadOnly Property IsApproximateSizes As Boolean
        Get
            Return Me.oIsApproximateSizes
        End Get
    End Property

    ''' <summary>
    ''' получить этикетку нужного размера
    ''' </summary>
    Public MustOverride Function GetLabel(LabelName As String) As Drawing.Image

    ''' <summary>
    ''' вернет Name
    ''' </summary>
    Public Overrides Function ToString() As String
        Return Name
    End Function



End Class

Public Class clsPaperBox
    Inherits clsPakages

    ''' <summary>
    ''' разбирает строку из settings и создает обьект
    ''' </summary>
    Public Shared Sub CreateFromCode(code As String)

    End Sub
    Public Shared Sub CreateInstance(Name As String, EAN13shot As String)

    End Sub


    Public Overrides Function GetLabel(LabelName As String) As Drawing.Image
        Return Nothing
    End Function
End Class

Public Class clsPlasticBox
    Inherits clsPakages

    Public Overrides Function GetLabel(LabelName As String) As System.Drawing.Image
        Return Nothing
    End Function
End Class

Public Class clsWoodBox
    Inherits clsPakages

    Public Overrides Function GetLabel(LabelName As String) As System.Drawing.Image
        Return Nothing
    End Function
End Class
