Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports RestMS_Client
Imports RestMS_Client.clsMoyScladManager
Imports Service
Imports RestMS_Client.MoySkladAPI

''' <summary>
''' тесты Мой Склад
''' </summary>
''' <remarks></remarks>
<TestClass()> Public Class MoySklad

    Dim _msi As iMoySkladDataProvider
    Dim _msi_main As clsRestMS_service
    Dim _manager As clsMoyScladManager

    ''' <summary>
    ''' соединение с МС
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_connect()
        'вывод смотрим в окне интерпретации
        Debug.WriteLine("------------------------")
        _msi_main = New clsRestMS_service

        _msi = _msi_main.GetInterface(True)

        Do While _msi Is Nothing
            Debug.WriteLine("wait connection..")
            _msi = _msi_main.GetInterface(False)
            clsApplicationTypes.BeepNOT()
            Threading.Thread.Sleep(5000)
        Loop
        _manager = clsRestMS_service.Manager
        clsApplicationTypes.BeepYES()
        Debug.WriteLine("connected")
    End Sub
    ''' <summary>
    ''' коллекция обьектов с фильтром
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestCollection()
        TestMethod_MC_connect()
        Dim _result As New List(Of good)
        Dim _message As String = ""
        If _manager.RequestAnyCollection(Of good)(_result, "8-4856", emMoySkladFilterTypes.code, _message) Then
            Debug.WriteLine("collection received")
            Debug.WriteLine(_result.Count)
        Else
            Debug.Fail(_message)
        End If
    End Sub
    ''' <summary>
    ''' коллекция обьектов без фильтра
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestProjects()
        TestMethod_MC_connect()
        Dim _result As New List(Of project)
        Dim _message As String = ""
        If _manager.RequestAnyCollection(Of project)(_result, "", emMoySkladFilterTypes.empty, _message) Then
            Debug.WriteLine("collection received")
            For Each t In _result
                Debug.WriteLine(t.name)
            Next
        Else
            Debug.Fail(_message)
        End If
    End Sub
    ''' <summary>
    ''' запрос элемента справочника пользователя
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestUserEntity()
        TestMethod_MC_connect()
        Dim _listName = "сотрудник Trilbone"
        Dim _valueName = "Пахомов Игорь Олегович"
        Dim _res = _msi_main.GetUserEntity(_listName, _valueName)
        Debug.WriteLine("вариант 1")
        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. UUID:{0}  MetaUUID:{1} ", _res.UUID, _res.MetaDataUUID))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If

        '---
        _listName = "счета"
        _valueName = "наличные на выставке1"
        _res = _msi_main.GetUserEntity(_listName, _valueName)
        Debug.WriteLine("вариант 2")

        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. UUID:{0}  MetaUUID:{1} ", _res.UUID, _res.MetaDataUUID))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If

        '---
        _listName = "счета"
        _valueName = "наличные на выставке"
        _res = _msi_main.GetUserEntity(_listName, _valueName)
        Debug.WriteLine("вариант 3")

        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. UUID:{0}  MetaUUID:{1} ", _res.UUID, _res.MetaDataUUID))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If
        '---------------
        Dim _MetadataUUID = "eff32c15-e428-11e3-d0f4-002590a28eca1"
        Dim _valueUUID = "0bcea5ed-124d-11e4-cd52-002590a28eca1"
        _res = _msi_main.GetUserEntityByUUID(_MetadataUUID, _valueUUID)
        Debug.WriteLine("вариант 1a")

        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. Значение:{0}  Справочник:{1} ", _res.Value, _res.MetaDataValue))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If
        '---------------
        _MetadataUUID = "eff32c15-e428-11e3-d0f4-002590a28eca"
        _valueUUID = "0bcea5ed-124d-11e4-cd52-002590a28eca1"
        _res = _msi_main.GetUserEntityByUUID(_MetadataUUID, _valueUUID)
        Debug.WriteLine("вариант 2a")

        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. Значение:{0}  Справочник:{1} ", _res.Value, _res.MetaDataValue))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If
        '---------------
        _MetadataUUID = "eff32c15-e428-11e3-d0f4-002590a28eca"
        _valueUUID = "0bcea5ed-124d-11e4-cd52-002590a28eca"
        _res = _msi_main.GetUserEntityByUUID(_MetadataUUID, _valueUUID)
        Debug.WriteLine("вариант 3a")

        If Not _res.IsEmpty Then
            Debug.WriteLine(String.Format("значение найдено. Значение:{0}  Справочник:{1} ", _res.Value, _res.MetaDataValue))
        ElseIf _res.IsMetadataEmpty Then
            Debug.WriteLine(String.Format("справочника '{0}' не существует в МС", _res.MetaDataValue))
        Else
            Debug.WriteLine(String.Format("значения '{0}' нет в справочнике '{1}'", _res.Value, _res.MetaDataValue))
        End If

    End Sub
    ''' <summary>
    ''' список значений пользовательского справочника
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestUserEntityListByName()
        TestMethod_MC_connect()
        'список значений пользовательского справочника
        Dim _res = _msi_main.GetUserEntityListByName("счета")
        For Each t In _res
            Debug.WriteLine(t.Value)
        Next
        Debug.WriteLine("----вариант 2")
        _res = _msi_main.GetUserEntityListByName("счета1")


    End Sub
    ''' <summary>
    ''' список значений пользовательского справочника
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestUserEntityListByUUID()
        'список значений пользовательского справочника
        TestMethod_MC_connect()
        Dim _res = _msi_main.GetUserEntityListByMetadataUUID("2e477c0c-a004-11e3-ddf5-002590a28eca")
        For Each t In _res
            Debug.WriteLine(t.Value)
        Next
        Debug.WriteLine("----вариант 2")
        _res = _msi_main.GetUserEntityListByMetadataUUID("2e477c0c-a004-11e3-ddf5-002590a28eca1")
    End Sub
    ''' <summary>
    ''' список всех пользовательских справочников
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestUserEntityList()

        TestMethod_MC_connect()

        Dim _result As New List(Of customEntityMetadata)
        Dim _message As String = ""
        If _manager.RequestAnyCollection(Of customEntityMetadata)(_result, "", emMoySkladFilterTypes.empty, _message) Then
            Debug.WriteLine("collection received")
            For Each t In _result
                Debug.WriteLine(t.name)
            Next
        Else
            Debug.Fail(_message)
        End If
    End Sub

    ''' <summary>
    ''' список складов
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestWarehouse()
        'список значений пользовательского справочника
        TestMethod_MC_connect()
        Dim _res = _msi_main.GetWarehouseList
        For Each t In _res
            Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.Value, t.UUID))
        Next
    End Sub


    ''' <summary>
    ''' получение Отгрузки по имени
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestDemand()
        TestMethod_MC_connect()

        Dim _objName = "00005"

        Dim _res = _msi_main.GetDemandInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(t)
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
                'все свойства обьекта
                For Each pr In t.GetType.GetProperties()
                    Debug.WriteLine(PropertyHelper(t, pr.Name))
                Next
                For Each p In t.Position
                    Debug.WriteLine(p)
                    Debug.WriteLine(String.Format("position name:{0}  uuid:{1}", p.GoodName, p.goodUuid))
                    For Each pr In p.GetType.GetProperties()
                        Debug.WriteLine(PropertyHelper(p, pr.Name))
                    Next
                Next
                For Each e In t.attributes
                    Debug.WriteLine(e)
                    If e.IsMetadataEmpty Then
                        e.TryGetCustomValue()
                    End If
                    If Not e.IsMetadataEmpty Then
                        Debug.WriteLine(String.Format("attribute справочник:{1} значение:{0}", e.Value, e.MetaDataValue))
                        Dim a = 0
                    End If
                Next

            Next
        End If
        '------------
        Debug.WriteLine("----вариант 2")
        _objName = "00056asdsd"
        _res = _msi_main.GetDemandInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
            Next
        End If

    End Sub


    ''' <summary>
    ''' получение Заказа по имени
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestOrder()
        TestMethod_MC_connect()

        Dim _objName = "00021a2"

        Dim _res = _msi_main.GetOrderInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(t)
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
                'все свойства обьекта
                For Each pr In t.GetType.GetProperties()
                    Debug.WriteLine(PropertyHelper(t, pr.Name))
                Next

                For Each p In t.Position
                    Debug.WriteLine(p.ToString)
                    Debug.WriteLine(String.Format("position name:{0}  uuid:{1}", p.GoodName, p.goodUuid))
                    'все свойства обьекта
                    For Each pr In p.GetType.GetProperties()
                        Debug.WriteLine(PropertyHelper(p, pr.Name))
                    Next

                Next
                For Each e In t.attributes
                    Debug.WriteLine(e.ToString)
                    If e.IsMetadataEmpty Then
                        e.TryGetCustomValue()
                    End If
                    If Not e.IsMetadataEmpty Then
                        Debug.WriteLine(String.Format("attribute справочник:{1} значение:{0}", e.Value, e.MetaDataValue))
                        Dim a = 0
                    End If
                Next
            Next
        End If
        '------------
        Debug.WriteLine("----вариант 2")
        _objName = "00021a2jjj"
        _res = _msi_main.GetOrderInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
            Next
        End If

    End Sub


    ''' <summary>
    ''' получение входящих по имени
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestPaymentIn()
        TestMethod_MC_connect()

        Dim _objName = "00017"

        Dim _res = _msi_main.GetPaymentInInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(t.ToString())
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
                'все свойства обьекта
                For Each pr In t.GetType.GetProperties()
                    Debug.WriteLine(PropertyHelper(t, pr.Name))
                Next
                For Each e In t.attributes
                    If e.IsMetadataEmpty Then
                        e.TryGetCustomValue()
                    End If
                    If Not e.IsMetadataEmpty Then
                        Debug.WriteLine(String.Format("attribute справочник:{1} значение:{0}", e.Value, e.MetaDataValue))
                        Dim a = 0
                    End If
                Next
            Next
        End If
        '------------
        Debug.WriteLine("----вариант 2")
        _objName = "00021a2jjj"
        _res = _msi_main.GetPaymentInInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
            Next
        End If

    End Sub

    ''' <summary>
    ''' получение исходящих по имени
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub TestMethod_MC_requestOutPayment()
        TestMethod_MC_connect()

        Dim _objName = "00017"

        Dim _res = _msi_main.GetPaymentOutInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(t.ToString())
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
                'все свойства обьекта
                For Each pr In t.GetType.GetProperties()
                    Debug.WriteLine(PropertyHelper(t, pr.Name))
                Next
                For Each e In t.attributes
                    If e.IsMetadataEmpty Then
                        e.TryGetCustomValue()
                    End If
                    If Not e.IsMetadataEmpty Then
                        Debug.WriteLine(String.Format("attribute справочник:{1} значение:{0}", e.Value, e.MetaDataValue))
                        Dim a = 0
                    End If
                Next
            Next
        End If
        '------------
        Debug.WriteLine("----вариант 2")
        _objName = "00021a2jjj"
        _res = _msi_main.GetPaymentOutInfo(_objName)
        If _res.Count = 0 Then
            Debug.WriteLine(String.Format("not found:{0}", _objName))
        Else
            For Each t In _res
                Debug.WriteLine(String.Format("Object name:{0}  uuid:{1}", t.name, t.UUID))
            Next
        End If

    End Sub



    Private Function PropertyHelper(p As Object, propertyName As String) As String
        Dim _property = p.GetType.GetProperty(propertyName)
        If _property Is Nothing Then
            Return String.Format("Property name:{0} Not exist!!!", propertyName)
        End If
        Dim _out As String = String.Format("Property name:{0}={1}  type:{2}", _property.Name, If(_property.GetValue(p, Nothing) Is Nothing OrElse String.IsNullOrEmpty(_property.GetValue(p, Nothing).ToString), "{нет значения}", _property.GetValue(p, Nothing)), _property.PropertyType.Name)
        Return _out

    End Function


    <TestMethod()> Public Sub TestMethod_MC_CellRequest()
        TestMethod_MC_connect()
        Dim _wareUUID = _manager.GetWarehousUUIDbyName("Внутренний Нарва")
        Dim _goods As IEnumerable(Of good) = Nothing
        Dim _res = _manager.FindGoods("8-2321-1", "", "", _goods)
        If _res > 0 Then
            Dim _rr = _manager.FindCellsForGood(_goods(0).uuid, _wareUUID)

            For Each t In _rr
                MsgBox(t.ToString)
            Next

        End If

    End Sub

End Class