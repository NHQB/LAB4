Option Strict On
Public Class Car

#Region "Properties"
    Private carMake As String = String.Empty
    Private carModel As String = String.Empty
    Private carYear As String = String.Empty
    Private carPrice As String = String.Empty
    Private carNewCondition As Boolean = False
    Private carInternalID As Integer = 0
    Shared carCount As Integer = 0
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Create a new car using default values
    ''' </summary>
    Public Sub New()
        carInternalID = carCount
        carCount += 1
    End Sub

    ''' <summary>
    ''' Create a new car using provided values
    ''' </summary>
    ''' <param name="make">Car make</param>
    ''' <param name="model">Car model</param>
    ''' <param name="year">Year of the car</param>
    ''' <param name="price">Car price</param>
    ''' <param name="newCondition">Car new status</param>
    Public Sub New(make As String, model As String, year As String, price As String, newCondition As Boolean)
        carInternalID = carCount
        carCount += 1
        Me.Make = make
        Me.Model = model
        Me.Year = year
        Me.Price = price
        Me.NewCondition = newCondition
    End Sub
#End Region

#Region "Property Methods"
    ''' <summary>
    ''' Get/Set the car make
    ''' </summary>
    ''' <returns>Car make as string</returns>
    Public Property Make() As String
        Get
            Return carMake
        End Get
        Set(ByVal Value As String)
            carMake = Value
        End Set
    End Property

    ''' <summary>
    '''  Get/Set the car model
    ''' </summary>
    ''' <returns>Car model as string</returns>
    Public Property Model() As String
        Get
            Return carModel
        End Get
        Set(ByVal Value As String)
            carModel = Value
        End Set
    End Property

    ''' <summary>
    '''  Get/Set the year of the car
    ''' </summary>
    ''' <returns>Year of the car as string</returns>
    Public Property Year() As String
        Get
            Return carYear
        End Get
        Set(ByVal Value As String)
            carYear = Value
        End Set
    End Property

    ''' <summary>
    '''  Get/Set the car price
    ''' </summary>
    ''' <returns>Car price as string</returns>
    Public Property Price() As String
        Get
            Return carPrice
        End Get
        Set(ByVal Value As String)
            carPrice = Value
        End Set
    End Property

    ''' <summary>
    '''  Get/Set whether the car is new
    ''' </summary>
    ''' <returns>New status as boolean</returns>
    Public Property NewCondition() As Boolean
        Get
            Return carNewCondition
        End Get
        Set(ByVal value As Boolean)
            carNewCondition = value
        End Set
    End Property

    ''' <summary>
    ''' Get the car's internal ID 
    ''' </summary>
    ''' <returns>Cars internal ID as integer</returns>
    Public ReadOnly Property ID() As Integer
        Get
            Return carInternalID
        End Get
    End Property

    ''' <summary>
    ''' Get the current count of cars
    ''' </summary>
    ''' <returns>Count of current cars as integer</returns>
    Public ReadOnly Property Count() As Integer
        Get
            Return carCount
        End Get
    End Property
#End Region
End Class
