'Imports eBay.Service.Core.Soap
'Imports eBay.Service.Core.Sdk
'Imports eBay.Service.Util
'Imports eBay.Service.Call
'Imports eBay.Service.EPS





'Namespace TesteBaySoap405
'    ' use your project name here
'    Class GeteBayOfficialTime
'        <STAThread> _
'        Private Shared Sub Main(args As String())
'            Dim endpoint As String = "https://api.sandbox.ebay.com/wsapi"
'            Dim callName As String = "GeteBayOfficialTime"
'            Dim siteId As String = "0"
'            Dim appId As String = "yourAppId"
'            ' use your app ID
'            Dim devId As String = "yourDevId"
'            ' use your dev ID
'            Dim certId As String = "yourCertId"
'            ' use your cert ID
'            Dim version As String = "405"
'            ' Build the request URL
'            Dim requestURL As String = (Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString(endpoint & Convert.ToString("?callname=")) & callName) + "&siteid=") & siteId) + "&appid=") & appId) + "&version=") & version) + "&routing=default"
'            ' Create the service
'            Dim service As New eBayAPIInterfaceService()
'            ' Assign the request URL to the service locator.
'            service.Url = requestURL
'            ' Set credentials
'            service.RequesterCredentials = New CustomSecurityHeaderType()
'            service.RequesterCredentials.eBayAuthToken = "yourToken"
'            ' use your token
'            service.RequesterCredentials.Credentials = New UserIdPasswordType()
'            service.RequesterCredentials.Credentials.AppId = appId
'            service.RequesterCredentials.Credentials.DevId = devId
'            service.RequesterCredentials.Credentials.AuthCert = certId
'            ' Make the call to GeteBayOfficialTime
'            Dim request As New GeteBayOfficialTimeRequestType()
'            request.Version = "405"
'            Dim response As GeteBayOfficialTimeResponseType = service.GeteBayOfficialTime(request)
'            Console.WriteLine("The time at eBay headquarters in San Jose, California, USA, is:")
'            Console.WriteLine(response.Timestamp)
'        End Sub


'    End Class


'End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

