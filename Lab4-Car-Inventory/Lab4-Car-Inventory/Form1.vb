Option Strict On
Public Class Form1
#Region "Variables and Constants"
    '' Constants 
    Const MIN_PRICE As Integer = 5000
    Const MAX_PRICE As Integer = 999999999

    '' Variables 
    Dim cars As New List(Of Car)
    Dim editMode As Boolean = False
    Dim updateData As Boolean = False
    Dim currentSelectedIndex As Integer = -1
#End Region

#Region "Subs and Function"
    ''' <summary>
    ''' Resets the form to to its inital values
    ''' </summary>
    Private Sub Reset()
        lvCarInventory.SelectedIndices.Clear()

        txtModel.Text = ""
        txtPrice.Text = ""
        cbMake.SelectedIndex = -1
        cbYear.SelectedIndex = -1
        ckNew.Checked = False

        editMode = False

        txtOutput.Text = "Reset Form"
    End Sub

    ''' <summary>
    ''' Validate inputs
    ''' </summary>
    ''' <returns>Status of error message, empty if no errors</returns>
    Function validateInput(Make As String, Model As String, Year As String, Price As String) As String
        Dim errorMessage As String = String.Empty
        Dim isNumeric As Decimal

        If (String.IsNullOrEmpty(Make)) Then
            errorMessage += "Please select a valid car make" & Environment.NewLine
        End If

        If (String.IsNullOrEmpty(Trim(Model))) Then
            errorMessage += "Please enter a valid model name" & Environment.NewLine
        End If

        If (String.IsNullOrEmpty(Year)) Then
            errorMessage += "Please select a valid year" & Environment.NewLine
        End If

        If (Decimal.TryParse(Price, isNumeric)) Then
            If (isNumeric < MIN_PRICE Or isNumeric > MAX_PRICE) Then
                errorMessage += "Please enter a price within the valid range between " + MIN_PRICE.ToString + " and " + MAX_PRICE.ToString & Environment.NewLine
            End If
        Else
            errorMessage += "Please enter a valid price number" & Environment.NewLine
        End If

        Return errorMessage
    End Function

    ''' <summary>
    ''' Reloads current list of cars into listview
    ''' </summary>
    Private Sub updateCarList()
        Dim carListItem As ListViewItem

        updateData = True
        lvCarInventory.Items.Clear()

        For Each car As Car In cars
            carListItem = New ListViewItem()

            carListItem.Checked = car.NewCondition
            carListItem.SubItems.Add(car.ID.ToString)
            carListItem.SubItems.Add(car.Make)
            carListItem.SubItems.Add(car.Model)
            carListItem.SubItems.Add(car.Year)
            carListItem.SubItems.Add("$" + car.Price)

            lvCarInventory.Items.Add(carListItem)
        Next
        updateData = False

    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim inputModel As String = txtModel.Text
        Dim inputPrice As String = txtPrice.Text
        Dim inputMake As String = cbMake.Text
        Dim inputYear As String = cbYear.Text
        Dim inputNewCondition As Boolean = ckNew.Checked
        Dim errors As String = validateInput(inputMake, inputModel, inputYear, inputPrice)
        Dim car As Car

        If (String.IsNullOrEmpty(errors)) Then
            ' validation successful

            If (editMode) Then
                ' update existing car
                cars(currentSelectedIndex).Make = inputMake
                cars(currentSelectedIndex).Model = inputModel
                cars(currentSelectedIndex).Year = inputYear
                cars(currentSelectedIndex).Price = inputPrice
                cars(currentSelectedIndex).NewCondition = inputNewCondition

                updateCarList()
                Reset()

                txtOutput.Text = "Updated car"
            Else
                ' creating new car
                car = New Car(inputMake, inputModel, inputYear, inputPrice, inputNewCondition)
                cars.Add(car)
                Reset()

                txtOutput.Text = "Added new car"

                updateCarList()
            End If

        Else
            ' validation unsuccessful
            txtOutput.Text = errors
        End If
    End Sub

    ''' <summary>
    ''' Handles selection of cars from list
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ListSelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCarInventory.SelectedIndexChanged
        If (Not lvCarInventory.FocusedItem Is Nothing) Then
            currentSelectedIndex = lvCarInventory.FocusedItem.Index
            Dim car As Car = cars(currentSelectedIndex)

            editMode = True

            txtModel.Text = car.Model
            txtPrice.Text = car.Price
            cbMake.Text = car.Make
            cbYear.Text = car.Year
            ckNew.Checked = car.NewCondition

            txtOutput.Text = "Loaded car data to update"
        End If
    End Sub

    ''' <summary>
    ''' Prevent the user from using checkboxes in listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lvwCustomers_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvCarInventory.ItemCheck
        If (Not updateData) Then
            e.NewValue = e.CurrentValue
        End If
    End Sub
#End Region
End Class
