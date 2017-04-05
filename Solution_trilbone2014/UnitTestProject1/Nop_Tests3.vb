Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Service
Imports Trilbone
Imports System.Windows.Forms
Imports Service.Catalog

<TestClass()> Public Class Nop_Tests3

    Private Function XML() As XElement
        Dim _xml As XElement = <CATALOGSAMPLE xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" bar="8029000006906" version="2">
                                   <DATA>
                                       <ELEMENT hash="59416167" name="NUMBER" order="1" alt="false" position="down" border="0" underline="false">8-690</ELEMENT>
                                       <ELEMENT hash="593227003" name="NAME" order="1" alt="Specimen name" position="title" border="0" underline="false">Asaphus bottnicus(Jaanusson, 1953)</ELEMENT>
                                       <ELEMENT hash="-950224312" name="MATRIXSIZE" order="1" alt="Block size" position="upperright" border="0" underline="false">7,5x7,0x5,0cm</ELEMENT>
                                       <ELEMENT hash="746245437" name="WEIGHT" order="2" alt="Net weight" position="upperright" border="0" underline="false">0,190kg</ELEMENT>
                                       <ELEMENT hash="-2000359731" name="FOSSILSIZE" order="1" alt="[1]Size of Asaphus bottnicus" position="upperleft" border="0" underline="false">3,8x2,6cm</ELEMENT>
                                       <ELEMENT hash="1925064812" name="SYSTEMATICA" order="2" alt="Systematica" position="down" border="0" underline="false">order Asaphida(Fortey, Chatterton, 1988)-&gt; family Asaphidae(Burmeister, 1843)-&gt; genus Asaphus(Brongniart, 1822)-&gt; Asaphus bottnicus(Jaanusson, 1953)</ELEMENT>
                                       <ELEMENT hash="2005553651" name="LOCALITY" order="3" alt="Locality" position="down" border="0" underline="false">St.Petersburg region, east of Leningradskaya oblast, Volkhov river, Porogi</ELEMENT>
                                       <ELEMENT hash="-1283930462" name="STRATIGRAPHY" order="4" alt="Stratigraphy" position="down" border="0" underline="false">lasnamagi horizone-&gt; A.bottnicus zone</ELEMENT>
                                       <ELEMENT hash="1699463536" name="TIMESCALE" order="5" alt="Age" position="down" border="0" underline="false">ordovician, middle epoch, Darriwilian stage(468-461 Ma)</ELEMENT>
                                   </DATA>
                                   <IMAGES titleimage="relative">
                                       <IMAGE src="01.jpg"/>
                                       <IMAGE src="02.jpg"/>
                                       <IMAGE src="03.jpg"/>
                                       <IMAGE src="04.jpg"/>
                                       <IMAGE src="05.jpg"/>
                                       <IMAGE src="06.jpg"/>
                                       <IMAGE src="07.jpg"/>
                                       <IMAGE src="08.jpg"/>
                                       <IMAGE src="09.jpg"/>
                                       <IMAGE src="10.jpg"/>
                                       <IMAGE src="11.jpg"/>
                                       <IMAGE src="12.jpg"/>
                                   </IMAGES>
                               </CATALOGSAMPLE>
        Return _xml
    End Function


    <TestMethod()> Public Sub TestMethod_fmMap()
        Trilbone_load.ModuleMain.initService()
        Dim _status As Integer
        Dim _cat As CATALOGSAMPLE = CATALOGSAMPLE.ParseSample(Me.XML.ToString, _status)
        Dim _fm = clsCatalogService.GetMappingForm(_cat, "")
        _fm.Visible = True
        Application.Run(_fm)

    End Sub

    <TestMethod()> Public Sub TestMethod_Uri()
        Dim _abs = "/site/wwwroot/Maps/test3D.JPG"

        Dim _a = New Uri("http://www.trilbone.com/map/")

        Dim _a1 = New Uri(_a, _abs)

        Dim _k As New UriBuilder
        With _k
            .Host = _a.Host
            .Path = "segment/123.jpg"
        End With



        Dim _b = New Uri(_a, "segment")
        _b = New Uri(_b, "123.jpg")
        MsgBox(_b.AbsoluteUri)

    End Sub

End Class