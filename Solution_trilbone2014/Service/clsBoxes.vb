Public Class clsBoxes
    Public Class FlavioBox
        Private oReikaThin As Decimal
        Public Property ReikaThin As Decimal
            Get
                Return oReikaThin
            End Get
            Set(value As Decimal)
                oReikaThin = value
                inncalculate()
            End Set
        End Property
        Private oFanerathin As Decimal
        Public Property FaneraThin As Decimal
            Get
                Return oFanerathin
            End Get
            Set(value As Decimal)
                oFanerathin = value
                inncalculate()
            End Set
        End Property

        Public ReadOnly Property FaneraVolume As Decimal
            Get
                Dim _out As Decimal = Math.Round((SideA.Width * SideA.Height * 2 + SideB.Width * SideB.Height * 2 + Cover.Width * Cover.Height * 2) / 1000000, 2)
                Return _out
            End Get
        End Property

        Public ReadOnly Property FaneraPercent As Decimal
            Get
                Dim _out As Decimal = Math.Round(FaneraVolume / (oListSq.Width * oListSq.Height) * 100, 1)
                Return _out
            End Get
        End Property

        Public ReadOnly Property ReikaA As Decimal
            Get
                Return oSideA.Width
            End Get
        End Property

        Public ReadOnly Property ReikaB As Decimal
            Get
                Return osideB.Width
            End Get
        End Property

        Public ReadOnly Property Weight As Decimal
            Get
                'плотность фанеры кг/м3
                Dim _ppf As Decimal = 660 / 1000000000

                Dim _out As Decimal = 0
                Dim _volume As Decimal = 0

                _volume += SideB.Width * SideB.Height * FaneraThin * 2
                _volume += SideA.Width * SideA.Height * FaneraThin * 2
                _volume += Cover.Width * Cover.Height * FaneraThin * 2

                _volume += ReikaLen * ReikaThin * 2

                _out = Math.Round(_volume * _ppf, 3)
                Return _out
            End Get
        End Property

        Public ReadOnly Property ReikaLen As Decimal
            Get
                Dim _out As Decimal = Math.Round(((oleight + 2 * ReikaThin) * 4 + owidth * 4) / 1000, 1)
                Return _out
            End Get
        End Property

        Private oListSq As New Drawing.SizeF(1.525, 1.525)

        Private oSideA As New Drawing.SizeF(0, 0)
        Public ReadOnly Property SideA As Drawing.SizeF
            Get
                Return oSideA
            End Get
        End Property
        Private osideB As New Drawing.SizeF(0, 0)
        Public ReadOnly Property SideB As Drawing.SizeF
            Get
                Return osideB
            End Get
        End Property
        Private oCover As New Drawing.SizeF(0, 0)
        Public ReadOnly Property Cover As Drawing.SizeF
            Get
                Return oCover
            End Get
        End Property

        Private oleight As Decimal
        Private owidth As Decimal
        Private oheight As Decimal

        Public Sub calculate(leight As Decimal, width As Decimal, height As Decimal, Optional ReikaThin As Decimal = 20, Optional Fanerathin As Decimal = 4)
            Me.ReikaThin = ReikaThin
            Me.FaneraThin = Fanerathin
            oleight = leight
            owidth = width
            oheight = height

            inncalculate()
        End Sub

        Private Sub inncalculate()
            oSideA = New Drawing.SizeF(Math.Round(oleight + 2 * ReikaThin + 2 * FaneraThin, 0), oheight)
            osideB = New Drawing.SizeF(owidth, oheight)
            oCover = New Drawing.SizeF(Math.Round(oleight + 2 * ReikaThin + 2 * FaneraThin, 0), Math.Round(owidth + 2 * ReikaThin + 2 * FaneraThin, 0))
        End Sub

        Public Sub New()

        End Sub
    End Class



End Class
