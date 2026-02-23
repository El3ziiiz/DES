Public Class Form1
    Private Sub bttn_Click(sender As Object, e As EventArgs) Handles bttn.Click
        Dim d As String = txtBox.Text
        MsgBox(cut(d))
    End Sub
    Function cut(ByVal str1 As String)
        Dim res As String = ""
        For Each ch As Char In str1
            res &= (Asc(ch) - 97).ToString() & ","
        Next
        Return res
    End Function
End Class
