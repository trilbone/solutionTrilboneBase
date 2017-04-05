Imports System.ComponentModel
Imports System.Drawing
Imports System.Xml.Linq
Imports System.Linq

Public Interface iMyTreesDataProvider




    ''' <summary>
    ''' вернет версию источника данных 1 = файлы на gdrive
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Version() As Integer

    ''' <summary>
    ''' все имена из всех деревьев. VolumeFilter какую строку должно содержать название раздела (Sys для Systematica например)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetAllNamesByVolume(VolumeFilter As String) As List(Of String)

    ''' <summary>
    ''' все имена существующих деревьев (имена файлов в версии 1.0)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTreesNames() As String()

    ' Function ParceNode(node As iMyTreesDataProvider.SerializableNodeObject) As String

End Interface
