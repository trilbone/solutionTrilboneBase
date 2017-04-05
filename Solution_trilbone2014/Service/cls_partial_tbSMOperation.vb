Imports System.Linq
Partial Public Class tbSMOperation
   

    ''' <summary>
    ''' вернет укороченную версию класса
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetShotClass() As clsSMoperation
        Return New clsSMoperation(Me)
    End Function

    ''' <summary>
    ''' урезанная версия класса tbSMOperation
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsSMoperation

        Public Shared Function Empty() As clsSMoperation
            Dim _new As New clsSMoperation
            With _new
                .Parent = Nothing
                .ContainsLotObject = False
                .ID = 0
                .ObjectNumbersList = New List(Of String)
                .ObjectQTY = 0
                .Remark = "новый образец"
                .WorkOperationID = 1
                .WorkOperationName = "новый образец"
            End With
            Return _new
        End Function

        Private Sub New()

        End Sub

        Public Sub New(parent As tbSMOperation)
            Me.Parent = parent
            Me.ID = parent.ID
            Dim _resultLotList = parent.tbSMLotOperation.AsQueryable.Where(Function(x) x.SMOperationID = parent.ID).Select(Function(x) x.tbSMLot).ToList
            Me.ObjectNumbersList = _resultLotList.Select(Function(x) x.LotNumber).ToList
            Me.Remark = parent.Remark
            Me.WorkOperationID = parent.SMWorkOperationID

            Me.ObjectQTY = _resultLotList.Count
            Me.ContainsLotObject = (_resultLotList.Where(Function(x) x.SMLotTypeID > 1).Count > 0)

            Me.WorkOperationName = parent.tbSMWorkOperation.Name
        End Sub

        Public Property Parent As tbSMOperation

        ''' <summary>
        ''' ID операции
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ID As Integer

        ''' <summary>
        ''' список номеров
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ObjectNumbersList As List(Of String)

        ''' <summary>
        ''' имя операций можно будет получить из загруженных сущностей
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WorkOperationID As Integer

        ''' <summary>
        ''' название текущей операции
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WorkOperationName As String

        ''' <summary>
        ''' примечание, если спиок рабочих операций не содержал нужную операцию
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Remark As String


        ''' <summary>
        ''' показывает, если хоть один из обьектов, над которыми производится операция, лотовый (НЕ ПУТАТЬ С ЛОТОМ ОБРАЗЦОВ!!)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ContainsLotObject As Boolean

        ''' <summary>
        ''' кол-во обьектов, над которыми проводится операция = ЛОТ ОБРАЗЦОВ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ObjectQTY As Integer


        Public Overrides Function ToString() As String
            Dim _out As String = ""
            If Me.Parent Is Nothing Then
                Return "<Новый образец>"
            End If
            'название образца
            If Me.ContainsLotObject Then
                Select Case Me.ObjectQTY
                    Case 0
                        'ошибка, запрос не должен был выдать ContainsLotObject=true
                        Debug.Fail("ошибка, запрос не должен был выдать ContainsLotObject=true при ObjectQTY=0")
                    Case 1
                        _out += String.Format("лот {0}", IIf(String.IsNullOrEmpty(Me.ObjectNumbersList(0)), "без номера", Me.ObjectNumbersList(0)))
                    Case Else
                        _out += String.Format("лот лотов {0}шт", Me.ObjectQTY)
                End Select
            Else
                Select Case Me.ObjectQTY
                    Case 0
                        _out += String.Format("[общее]")
                    Case 1
                        _out += String.Format("образец {0}", IIf(String.IsNullOrEmpty(Me.ObjectNumbersList(0)), "без номера", Me.ObjectNumbersList(0)))
                    Case Else
                        _out += String.Format("лот образцов {0}шт", Me.ObjectQTY)
                End Select
            End If

            _out += " ("

            'операция
            If Me.WorkOperationID = 1 Then
                'операция с указанием в примечании
                'запишем 10 символов из примечания
                Select Case Me.Remark.Length
                    Case 0
                        _out += Me.WorkOperationName
                    Case Is <= 10
                        _out += Me.Remark
                    Case Else
                        _out += Me.Remark.Substring(0, 10)
                End Select
            Else
                _out += Me.WorkOperationName
            End If
            _out += ")"

            Return _out
        End Function
    End Class

End Class
