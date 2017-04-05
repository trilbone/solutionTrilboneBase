Public Class fmCondition

    
    Private Sub UserControlQality1_QualityTextChanged(sender As Object, e As Service.UserControlQality.QualityTextChangedEventArgs) Handles UserControlQality1.QualityTextChanged
        RaiseEvent QualityTextChanged(Me, e)
    End Sub

    Public Event QualityTextChanged(sender As Object, e As Service.UserControlQality.QualityTextChangedEventArgs)



End Class