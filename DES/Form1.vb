Public Class Form1
    Private Sub bttn_Click(sender As Object, e As EventArgs) Handles bttn.Click
        Dim inputText As String = txtBox.Text.Trim()
        If Not IsNumeric(inputText) Then
            MsgBox("Please enter a number.")
            Return
        End If

        Dim numberValue As Integer = CInt(inputText)
        If numberValue < 0 Or numberValue > 255 Then
            MsgBox("Please enter a number between 0 and 255.")
            Return
        End If

        Dim binaryValue As String = Convert.ToString(numberValue, 2).PadLeft(8, "0"c)
        Dim shuffled As String = InitialPermutation(binaryValue)
        Dim leftHalf As String = shuffled.Substring(0, 4)
        Dim rightHalf As String = shuffled.Substring(4, 4)

        MsgBox("Original 8-bit: " & binaryValue & vbCrLf &
               "After IP:" & " (L): " & leftHalf & " (R): " & rightHalf)
    End Sub

    Function InitialPermutation(ByVal input8 As String) As String
        Dim ipTable As Integer() = {8, 1, 2, 3, 4, 5, 6, 7}
        Dim result As New System.Text.StringBuilder()
        For i As Integer = 0 To 7
            result.Append(input8(ipTable(i) - 1))
        Next
        Return result.ToString()
    End Function
End Class