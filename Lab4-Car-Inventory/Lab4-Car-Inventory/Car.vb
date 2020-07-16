Option Strict On
Public Class Car

#Region "Properties"
    Private carMake As String = String.Empty
    Private carModel As String = String.Empty
    Private carYear As String = String.Empty
    Private carPrice As String = String.Empty
    Private carNew As Boolean = False
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
    ''' <param name="number">Student ID Number</param>
    ''' <param name="name">Student Name</param>
    ''' <param name="program">Student Program of Study</param>
    ''' <param name="tuitionStatus">Student Tuition Payment Status</param>
    Public Sub New(number As String, name As String, program As String, tuitionStatus As Boolean)
        carInternalID = carCount
        carCount += 1
        Me.Make = Make
        Me.Model = Model
        Me.Year = Year
        Me.Price = Price
        Me.Neww = Neww
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
    Public Property Neww() As Boolean
        Get
            Return carNew
        End Get
        Set(ByVal value As Boolean)
            carNew = value
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
