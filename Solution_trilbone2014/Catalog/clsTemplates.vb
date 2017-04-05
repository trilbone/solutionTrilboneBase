Imports System.Linq
Namespace Trilbone

    Partial Class clsTemplateManager
        Public Class clsTemplates
            Inherits List(Of clsKeyPair)
            Sub New()
                MyBase.New()
                oMustSaved = True
            End Sub
            

            Public ReadOnly Property Keys As List(Of String)
                Get
                    Dim _result = (From c In Me Select c.Key).ToList
                    Return _result
                End Get
            End Property

            Public ReadOnly Property Values As List(Of String)
                Get
                    Dim _result = (From c In Me Select c.Value).ToList
                    Return _result
                End Get
            End Property




            <System.SerializableAttribute()>
            Public Class clsKeyPair
                <System.Xml.Serialization.XmlAttribute("includesmall")> _
                Public Property includesmall As Boolean

                ''' <summary>
                ''' Ширина картинки в этом шаблоне
                ''' </summary>
                ''' <value></value>
                ''' <returns></returns>
                ''' <remarks></remarks>
                <System.Xml.Serialization.XmlAttribute("imagewidth")> _
                Public Property ImageWidth As Integer

                <System.Xml.Serialization.XmlElementAttribute("KEY")> _
                Public Property Key As String

                <System.Xml.Serialization.XmlElementAttribute("FILE")> _
                Public Property Value As String

                Public Overrides Function Equals(obj As Object) As Boolean
                    If Not obj.GetType.Equals(GetType(clsKeyPair)) Then Return False
                    If Not CType(obj, clsKeyPair).Key.ToLower = Me.Key.ToLower Then Return False
                    Return MyBase.Equals(obj)
                End Function
            End Class


            ''' <summary>
            ''' возвращает строку xml сериализации класса
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function GetXML() As String

                Dim _wrsett As New Xml.XmlWriterSettings
                Dim _xmlSerializer As Xml.Serialization.XmlSerializer
                Dim _xmlwriter As Xml.XmlWriter
                Dim _strBuilt As New System.Text.StringBuilder

                _xmlSerializer = New Xml.Serialization.XmlSerializer(GetType(clsTemplates))
                With _wrsett
                    .Encoding = System.Text.Encoding.GetEncoding("windows-1251")
                    .Indent = True
                End With

                _xmlwriter = Xml.XmlWriter.Create(_strBuilt, _wrsett)
                _xmlSerializer.Serialize(_xmlwriter, Me)
                _xmlwriter.Flush()
                _xmlwriter.Close()


                Return _strBuilt.ToString

            End Function

            Default Public Overloads ReadOnly Property Item(key As String) As String
                Get
                    Dim _obj = (From c In Me Where c.Key.ToLower = key.ToLower Select c).FirstOrDefault
                    Return _obj.Value
                End Get
            End Property

            Public Shadows Sub Remove(key As String)
                Dim _obj = (From c In Me Where c.Key.ToLower = key.ToLower Select c).FirstOrDefault
                MyBase.Remove(_obj)
            End Sub

            Public Overloads Sub Add(key As String, Value As String)
                MyBase.Add(New clsKeyPair With {.Key = key, .Value = Value})
                oMustSaved = True
            End Sub

            Public Function ContainsKey(key As String) As Boolean
                Dim _obj = From c In Me Where c.Key.ToLower = key.ToLower Select c

                If _obj.Count > 0 Then Return True
                Return False
            End Function

            Public Function ContainsValue(value As String) As Boolean
                Dim _obj = From c In Me Where c.Value.ToLower = value.ToLower Select c

                If _obj.Count > 0 Then Return True
                Return False
            End Function

            ''' <summary>
            ''' читает (разбирает) каталог из строки
            ''' </summary>
            Public Shared Function ParseTemplates(ByVal xmlString As String) As clsTemplates
                If xmlString.Length = 0 Then
                    MsgBox("017. в ReadCatalog передана пустая строка")
                    Return Nothing
                End If


                Dim _templates As clsTemplates

                Dim _rdsett As New Xml.XmlReaderSettings
                Dim _xmlSerializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(clsTemplates))
                Dim _xmlreader As Xml.XmlReader
                Dim _strBuilt As IO.StringReader

                'catalog
                _strBuilt = New IO.StringReader(xmlString)

                With _rdsett
                    .CloseInput = True
                    .IgnoreComments = True
                    '.Schemas = _xmlsh
                End With

                _xmlreader = Xml.XmlReader.Create(_strBuilt, _rdsett)
                _templates = _xmlSerializer.Deserialize(_xmlreader)
                _xmlreader.Close()

                oMustSaved = False
                For Each t In _templates
                    If t.ImageWidth = 0 Then
                        Dim _result As Integer
                        If Integer.TryParse(InputBox("Ведите максимальную ширину картинки для шаблона " & t.Key, , "1600"), _result) Then
                            t.ImageWidth = _result
                            oMustSaved = True
                        End If
                    End If
                Next


                Return _templates

            End Function
            Private Shared oMustSaved As Boolean

            ''' <summary>
            ''' будет установлено, если шаблоны необходимо сохранить
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property MustSaved As Boolean
                Get
                    Return oMustSaved
                End Get
                
            End Property
        End Class
    End Class
End Namespace
