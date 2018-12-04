Class MainWindow
    Dim selectedOp As SelectedOperator
    Dim result As Double
    Dim lastNumber As Double
    Private Sub AcButton_Click(sender As Object, e As RoutedEventArgs)
        resultLabel.Content = "0"
    End Sub

    Private Sub NegativeButton_Click(sender As Object, e As RoutedEventArgs)
        resultLabel.Content = If(Double.TryParse(resultLabel.Content, lastNumber), lastNumber * -1, lastNumber)
    End Sub

    Private Sub PercentageButton_Click(sender As Object, e As RoutedEventArgs)
        resultLabel.Content = If(Double.TryParse(resultLabel.Content, lastNumber), lastNumber / 100, lastNumber)
    End Sub

    Private Sub DecimalButton_Click(sender As Object, e As RoutedEventArgs)
        Dim content As String = resultLabel.Content
        If content.Contains(".") Then
            resultLabel.Content = $"{resultLabel.Content}."
        End If
    End Sub

    Private Sub OperationButton_Click(sender As Object, e As RoutedEventArgs)
        If (Double.TryParse(resultLabel.Content, lastNumber)) Then
            resultLabel.Content = "0"
        End If
        If (sender.Equals(multiplicationButton)) Then
            selectedOp = SelectedOperator.Multiplication
        ElseIf (sender.Equals(divideButton)) Then
            selectedOp = SelectedOperator.Division
        ElseIf (sender.Equals(addButton)) Then
            selectedOp = SelectedOperator.Addition
        ElseIf (sender.Equals(subtractButton)) Then
            selectedOp = SelectedOperator.Subtraction
        End If
    End Sub

    Private Sub NumberButton_Click(sender As Object, e As RoutedEventArgs)
        Dim selectedValue As Int16 = 0
        If (sender.Equals(oneButton)) Then
            selectedValue = 1
        ElseIf (sender.Equals(twoButton)) Then
            selectedValue = 2
        ElseIf (sender.Equals(threeButton)) Then
            selectedValue = 3
        ElseIf (sender.Equals(fourButton)) Then
            selectedValue = 4
        ElseIf (sender.Equals(fiveButton)) Then
            selectedValue = 5
        ElseIf (sender.Equals(sixButton)) Then
            selectedValue = 6
        ElseIf (sender.Equals(sevenButton)) Then
            selectedValue = 7
        ElseIf (sender.Equals(eightButton)) Then
            selectedValue = 8
        ElseIf (sender.Equals(nineButton)) Then
            selectedValue = 9
        End If
        resultLabel.Content = If(resultLabel.Content.Equals("0"), $"{selectedValue}", $"{resultLabel.Content.ToString()}{selectedValue}")
    End Sub

    Private Sub EqualsButton_Click(sender As Object, e As RoutedEventArgs)
        Dim newNumber As Double

        If (Double.TryParse(resultLabel.Content.ToString(), newNumber)) Then
            Select Case selectedOp
                Case SelectedOperator.Addition
                    result = SimpleMath.Add(lastNumber, newNumber)
                Case SelectedOperator.Subtraction
                    result = SimpleMath.Subtract(lastNumber, newNumber)
                Case SelectedOperator.Multiplication
                    result = SimpleMath.Multiply(lastNumber, newNumber)
                Case SelectedOperator.Division
                    result = SimpleMath.Divide(lastNumber, newNumber)
            End Select
        End If
        resultLabel.Content = result.ToString()
    End Sub

    Private Enum SelectedOperator
        Addition
        Subtraction
        Multiplication
        Division
    End Enum
End Class

Public Class SimpleMath
    Public Shared Function Add(n1 As Double, n2 As Double)
        Return n1 + n2
    End Function

    Public Shared Function Subtract(n1 As Double, n2 As Double)
        Return n1 - n2
    End Function

    Public Shared Function Multiply(n1 As Double, n2 As Double)
        Return n1 * n2
    End Function

    Public Shared Function Divide(n1, n2)
        If (n2 = 0) Then
            MessageBox.Show("Division by Zero is not supported.", "Invalid Operation.", MessageBoxButton.OK, MessageBoxImage.Stop)
            Return 0
        End If
        Return n1 / n2
    End Function
End Class