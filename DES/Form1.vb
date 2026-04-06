Imports System.Reflection.Emit
Public Class Form1
    Private Const keyText As String = "ABCDEF"
    Private Function Bin8(ByVal n As Integer) As String
        Dim r As String = ""
        For i = 1 To 8
            r = (n Mod 2) & r
            n = n \ 2
        Next
        Return r
    End Function
    Private Function Bin4(ByVal n As Integer) As String
        Dim r As String = ""
        For i = 1 To 4
            r = (n Mod 2) & r
            n = n \ 2
        Next
        Return r
    End Function
    Private Function ToInt(ByVal b As String) As Integer
        Dim r As Integer = 0
        For i = 1 To Len(b)
            r = r * 2 + CInt(Mid(b, i, 1))
        Next
        Return r
    End Function
    Private Function ToBin64(ByVal txt As String) As String
        Dim r As String = ""
        For i = 1 To 8
            r &= Bin8(Asc(Mid(txt, i, 1)))
        Next
        Return r
    End Function
    Private Function IP(ByVal b As String) As String
        Return Mid(b, 33, 32) & Mid(b, 1, 32)
    End Function
    Private Function Expand(ByVal r As String) As String
        Return Mid(r, 1, 8) & Mid(r, 13, 4) &
               Mid(r, 9, 8) & Mid(r, 1, 4) &
               Mid(r, 17, 8) & Mid(r, 29, 4) &
               Mid(r, 25, 8) & Mid(r, 17, 4)
    End Function
    Private Function XORStr(ByVal a As String, ByVal b As String) As String
        Dim r As String = ""
        For i = 1 To Len(a)
            r &= (CInt(Mid(a, i, 1)) Xor CInt(Mid(b, i, 1)))
        Next
        Return r
    End Function
    Private Function SBox(ByVal bits As String) As String
        Dim r As String = ""
        Dim i As Integer = 1
        Do While i + 5 <= Len(bits)
            Dim row As Integer = ToInt(Mid(bits, i, 2))
            Dim col As Integer = ToInt(Mid(bits, i + 2, 4))
            Dim val As Integer = (row Xor col) Mod 16
            r &= Bin4(val)
            i += 6
        Loop
        Return r
    End Function
    Private Function PBox(ByVal b As String) As String
        Return Mid(b, 17, 16) & Mid(b, 1, 16)
    End Function
    Private Function InvIP(ByVal b As String) As String
        Return Mid(b, 33, 32) & Mid(b, 1, 32)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim plain64 As String = ToBin64(TextBox1.Text)
        Dim after_ip As String = IP(plain64)
        Dim L As String = Mid(after_ip, 1, 32)
        Dim R As String = Mid(after_ip, 33, 32)
        Dim binKey As String = ""
        For i = 1 To 6
            binKey &= Bin8(Asc(Mid(keyText, i, 1)))
        Next
        Dim R_expanded As String = Expand(R)
        Dim xored As String = XORStr(R_expanded, binKey)
        Dim s As String = SBox(xored)
        Dim f_result As String = PBox(s)
        Dim newR As String = XORStr(L, f_result)
        Dim combined As String = R & newR
        Dim cipher_bin As String = InvIP(combined)
        Dim cipherText As String = ""
        For i = 1 To 64 Step 8
            cipherText &= Chr(ToInt(Mid(cipher_bin, i, 8)) Mod 95 + 32)
        Next
        Label2.Text = "Cipher: " & cipherText
    End Sub
End Class