Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Collections.Generic
Imports eBay.Service.EPS
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap


Public Class clsUploadPictures
    Public Sub load()
        '© 2007-2013 eBay Inc., All Rights Reserved
        'Licensed under CDDL 1.0 - http://opensource.org/licenses/cddl1.php
        Dim token As String = ""
        Dim SandboxURL = "https://api.sandbox.ebay.com/ws/api.dll"
        Dim PictureURL = "your Picture URL here"
        Dim DevID = "your DevID here"
        Dim AppID = "your AppID here"
        Dim CertID = "your CertID here"
        Dim payload As String = "<?xml version='1.0' encoding='utf-8'?> " +
    "<UploadSiteHostedPicturesRequest xmlns='urn:ebay:apis:eBLBaseComponents'>" +
    "<ExternalPictureURL>" + PictureURL + "</ExternalPictureURL>" +
    "<RequesterCredentials><eBayAuthToken>" + token + "</eBayAuthToken></RequesterCredentials>" +
    "</UploadSiteHostedPicturesRequest>"


        'string payload = "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
        '"<UploadSiteHostedPicturesRequest xmlns=\"urn:ebay:apis:eBLBaseComponents\">" +
        '"<ExternalPictureURL>" + PictureURL + "</ExternalPictureURL>" +
        '"<RequesterCredentials><eBayAuthToken>" + token + "</eBayAuthToken></RequesterCredentials>" +
        '"</UploadSiteHostedPicturesRequest>";
        Dim req As HttpWebRequest = WebRequest.Create(SandboxURL)
        Dim resp As HttpWebResponse = Nothing
        'Add the request headers
        req.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "803")
        req.Headers.Add("X-EBAY-API-SITEID", "0")
        req.Headers.Add("X-EBAY-API-CALL-NAME", "UploadSiteHostedPictures")
        req.Headers.Add("X-EBAY-API-DEV-NAME", DevID)
        req.Headers.Add("X-EBAY-API-APP-NAME", AppID)
        req.Headers.Add("X-EBAY-API-CERT-NAME", CertID)
        '//set the method to POST
        req.Method = "POST"
        '//Convert the string to a byte array
        Dim postDataBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(payload)
        Dim len As Integer = postDataBytes.Length
        req.ContentLength = len
        '//Post the request to eBay
        Dim requestStream = req.GetRequestStream()
        requestStream.Write(postDataBytes, 0, len)
        requestStream.Close()

        Try
            '// get response and write to console
            resp = req.GetResponse()
            Dim responseReader = New StreamReader(resp.GetResponseStream(), Encoding.UTF8)
            Dim output = responseReader.ReadToEnd()
            resp.Close()
            Dim xmlResponse = New XmlDocument()
            xmlResponse.LoadXml(output)
            '//string response = xmlResponse.ToString();
            '//process response
            '//show them how to get the full url and specify that in the AddItem request

        Catch ex As Exception
            '//handle exception

        End Try
    End Sub


    ''' <summary>
    ''' нормальная загрузка фото
    ''' </summary>
    ''' <remarks></remarks>
    'Public Sub load2()
    '    Dim context = New ApiContext()
    '    context.ApiCredential.eBayToken = "Your Token here"
    '    context.Site = SiteCodeType.US
    '    context.SignInUrl = "https://api.sandbox.ebay.com/wsapi"


    '    Dim pictureService = New eBayPictureService(context)
    '    Dim request = New UploadSiteHostedPicturesRequestType()
    '    With request
    '        'после окончания хранить 1-30дней
    '        '.ExtensionInDays = 1

    '        'Supersize, 4-picture set. If you specify this value on input, and this value is returned in the response, then in AddItem or a related call, you must specify Item.PictureDetails.PhotoDisplay.Supersize or Item.PictureDetails.PhotoDisplay.PicturePack.
    '        'IMPORTANT To get the standard website image sizing with Zoom, set this field to Supersize
    '        .PictureSet = PictureSetCodeType.Supersize

    '        .PictureName = "Deva_testimage_URL"

    '        .PictureSetSpecified = True

    '        '.PictureUploadPolicy = PictureUploadPolicyCodeType.Add

    '        'водяной знак
    '        'Dim _w As New PictureWatermarkCodeTypeCollection
    '        '_w.Add(PictureWatermarkCodeType.Icon)
    '        '.PictureWatermark = _w

    '    End With

    '    'request.PictureName = "Deva_testimage_URL"
    '    ' request.PictureSet = PictureSetCodeType.Large
    '    'request.PictureSetSpecified = True

    '    Dim pictureList = {"C:\images\test1.jpg", "C:\images\test2.jpg", "C:\images\test3.jpg", "C:\images\test4.jpg"}

    '    Dim picURLs = pictureService.UpLoadPictureFiles(PhotoDisplayCodeType.SuperSize, pictureList)

    '    For Each _pic In picURLs
    '        Console.WriteLine(_pic)
    '    Next
    'End Sub

End Class
