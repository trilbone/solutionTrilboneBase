Imports System.Runtime.CompilerServices
Imports System.Windows.Forms



Public Module ModuleWebBrowser
    ''' <summary>
    ''' https://msdn.microsoft.com/ru-ru/library/windows/desktop/ms691264(v=vs.85).aspx
    ''' константы управления браузером
    ''' </summary>
    Private Enum OLECMDID As Long
        OLECMDID_OPEN = 1
        OLECMDID_NEW = 2
        OLECMDID_SAVE = 3
        OLECMDID_SAVEAS = 4
        OLECMDID_SAVECOPYAS = 5
        OLECMDID_PRINT = 6
        OLECMDID_PRINTPREVIEW = 7
        OLECMDID_PAGESETUP = 8
        OLECMDID_SPELL = 9
        OLECMDID_PROPERTIES = 10
        OLECMDID_CUT = 11
        OLECMDID_COPY = 12
        OLECMDID_PASTE = 13
        OLECMDID_PASTESPECIAL = 14
        OLECMDID_UNDO = 15
        OLECMDID_REDO = 16
        OLECMDID_SELECTALL = 17
        OLECMDID_CLEARSELECTION = 18
        OLECMDID_ZOOM = 19
        OLECMDID_GETZOOMRANGE = 20
        OLECMDID_UPDATECOMMANDS = 21
        OLECMDID_REFRESH = 22
        OLECMDID_STOP = 23
        OLECMDID_HIDETOOLBARS = 24
        OLECMDID_SETPROGRESSMAX = 25
        OLECMDID_SETPROGRESSPOS = 26
        OLECMDID_SETPROGRESSTEXT = 27
        OLECMDID_SETTITLE = 28
        OLECMDID_SETDOWNLOADSTATE = 29
        OLECMDID_STOPDOWNLOAD = 30
        OLECMDID_ONTOOLBARACTIVATED = 31
        OLECMDID_FIND = 32
        OLECMDID_DELETE = 33
        OLECMDID_HTTPEQUIV = 34
        OLECMDID_HTTPEQUIV_DONE = 35
        OLECMDID_ENABLE_INTERACTION = 36
        OLECMDID_ONUNLOAD = 37
        OLECMDID_PROPERTYBAG2 = 38
        OLECMDID_PREREFRESH = 39
        OLECMDID_SHOWSCRIPTERROR = 40
        OLECMDID_SHOWMESSAGE = 41
        OLECMDID_SHOWFIND = 42
        OLECMDID_SHOWPAGESETUP = 43
        OLECMDID_SHOWPRINT = 44
        OLECMDID_CLOSE = 45
        OLECMDID_ALLOWUILESSSAVEAS = 46
        OLECMDID_DONTDOWNLOADCSS = 47
        OLECMDID_UPDATEPAGESTATUS = 48
        OLECMDID_PRINT2 = 49
        OLECMDID_PRINTPREVIEW2 = 50
        OLECMDID_SETPRINTTEMPLATE = 51
        OLECMDID_GETPRINTTEMPLATE = 52
        OLECMDID_PAGEACTIONBLOCKED = 55
        OLECMDID_PAGEACTIONUIQUERY = 56
        OLECMDID_FOCUSVIEWCONTROLS = 57
        OLECMDID_FOCUSVIEWCONTROLSQUERY = 58
        OLECMDID_SHOWPAGEACTIONMENU = 59
        OLECMDID_ADDTRAVELENTRY = 60
        OLECMDID_UPDATETRAVELENTRY = 61
        OLECMDID_UPDATEBACKFORWARDSTATE = 62
        ''' <summary>
        ''' Windows Internet Explorer 7 and later. Sets the zoom factor of the browser. Takes a VT_I4 parameter in the range of 10 to 1000 (percent).
        ''' </summary>
        OLECMDID_OPTICAL_ZOOM = 63
        OLECMDID_OPTICAL_GETZOOMRANGE = 64
        OLECMDID_WINDOWSTATECHANGED = 65
        OLECMDID_ACTIVEXINSTALLSCOPE = 66
        OLECMDID_UPDATETRAVELENTRY_DATARECOVERY = 67
    End Enum
    Private Enum ExecOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum
    ''' <summary>
    ''' зум в броузере
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="percent"></param>
    <Extension()>
    Sub Zoom(ByRef a As WebBrowser, percent As Integer)
        If a Is Nothing Then Return
        If a.IsBusy Then Return
        'если ошибка, то учти, что страница должна быть полностью загружена перед применением масштаба
#If Not DEBUG Then
 Try
        Dim obj As SHDocVw.IWebBrowser2 = a.ActiveXInstance
        obj.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, percent, Nothing)
        Catch ex As Exception
            Return
        End Try
#Else
        Dim obj As SHDocVw.IWebBrowser2 = a.ActiveXInstance
        obj.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, percent, Nothing)
#End If

    End Sub
End Module
