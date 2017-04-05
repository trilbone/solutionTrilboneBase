Public Interface iNopDataProvider
    Function GetProduct(Optional CategoryID As Integer = 0) As List(Of clsNopProduct)
    Function GetACL(sku As String) As List(Of clsNopACL)
    Function GetAviableStore(sku As String) As List(Of clsNopStore)
    Function GetStores() As List(Of clsNopStore)
    Function GetCategories() As List(Of clsNopCategory)
    Function GetRoles() As List(Of clsNopRole)

    Function AllowShop(sku As String, shopId As Integer, allowed As Boolean) As Boolean
    Function AllowRole(sku As String, roleId As Integer, allowed As Boolean) As Boolean
    Function SetPrice(sku As String, roleId As Integer, price As Decimal) As Boolean

    ReadOnly Property IsConnect As Boolean

    Class clsNopRole
        Property id As Integer
        Property Name As String
    End Class

    Class clsNopCategory
        Property id As Integer
        Property Name As String
        Property ParentCategoryId As String
    End Class

    Class clsNopStore
        Property id As Integer
        Property Name As String
    End Class


    ''' <summary>
    ''' описывает строку ACL для продукта
    ''' </summary>
    ''' <remarks></remarks>
    Class clsNopACL
        Property Discount As Decimal
        Property LimitedToStores As Boolean
        Property Name As String
        Property price As Decimal
        Property productid As Integer
        Property Quantity As Integer
        Property roleid As Integer
        Property rolename As String
        Property Sku As String
        Property StoreId As Integer
        Property storename As String
        Property SubjectToAcl As Boolean
        Property tierprice As Decimal
    End Class


    ''' <summary>
    ''' описывает строку продукта
    ''' </summary>
    ''' <remarks></remarks>
    Class clsNopProduct
        Implements IEqualityComparer(Of clsNopProduct)
        Implements IComparable(Of clsNopProduct)

        Property HasTierPrices As Boolean
        Property Id As Integer
        Property LimitedToStores As Boolean
        Property CustomerRolesIdList As List(Of Integer)
        Property Name As String
        Property Price As Decimal
        Property Currency As String
        Property Published As Boolean
        Property ShowOnHomePage As Boolean
        Property Sku As String
        Property StockQuantity As Integer
        Property SubjectToAcl As Boolean
        Property WarehouseId As Integer
        Property warename As String
        Property fossilsSizes As Decimal()

        Public Function TryGetSampleNumber(ByRef SampleNumber As clsApplicationTypes.clsSampleNumber) As Boolean
            Dim _sm = clsApplicationTypes.clsSampleNumber.CreateFromString(Me.Sku)
            If _sm.CodeIsCorrect Then
                SampleNumber = _sm
                Return True
            Else
                SampleNumber = Nothing
                Return False
            End If
        End Function


        Public Function Equals1(x As clsNopProduct, y As clsNopProduct) As Boolean Implements IEqualityComparer(Of clsNopProduct).Equals
            If x Is y Then Return True
            If x Is Nothing OrElse y Is Nothing Then Return False
            If x.Sku Is Nothing Then Return False
            If y.Sku Is Nothing Then Return False
            Return x.Sku.Equals(y.Sku) 'AndAlso x.Name.ToLower.Equals(y.Name.ToLower)
        End Function

        Public Function GetHashCode1(obj As clsNopProduct) As Integer Implements IEqualityComparer(Of clsNopProduct).GetHashCode
            If obj Is Nothing Then Return 0
            'Dim hashProductName = If(obj.Name Is Nothing, 0, obj.Name.GetHashCode())
            Dim hashProcuctSku = If(String.IsNullOrEmpty(obj.Sku), 0, obj.Sku.GetHashCode)

            Return hashProcuctSku 'Xor hashProductName
        End Function

        Public Function CompareTo(other As clsNopProduct) As Integer Implements IComparable(Of clsNopProduct).CompareTo
            Return Me.Name.CompareTo(other.Name)
        End Function
    End Class


End Interface

