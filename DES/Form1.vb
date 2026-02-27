Public Class Form1
    Private Sub bttn_Click(sender As Object, e As EventArgs) Handles bttn.Click
        Dim inputText As String = txtBox.Text.Trim()
        If IsNumeric(inputText) Then
            Dim numberValue As Integer = CInt(inputText)
            Dim binaryValue As String = Convert.ToString(numberValue, 2).PadLeft(8, "0"c)
            MsgBox(binaryValue)
        Else
            MsgBox(ConvertToBinary(inputText))
        End If
    End Sub
    Function ConvertToBinary(ByVal str1 As String) As String
        Dim res As String = ""
        For Each ch As Char In str1
            Dim asciiValue As Integer = Asc(ch)
            Dim binaryValue As String = Convert.ToString(asciiValue, 2).PadLeft(8, "0"c)
            res &= binaryValue & " "
        Next
        Return res
    End Function
End Class