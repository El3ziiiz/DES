Public Class Form1

    Dim key64 As String = "1010101111001101111001101010101111001101010101011110001111000011"

    Private Sub bttn_Click(sender As Object, e As EventArgs) Handles bttn.Click

        Dim inputText As String = txtBox.Text.Trim()
        Dim parts() As String = inputText.Split(",")

        If parts.Length <> 6 Then
            MsgBox("Enter exactly 6 numbers separated by commas")
            Return
        End If

        Dim binaryBlock As String = ""

        For Each p In parts
            If Not IsNumeric(p) Then
                MsgBox("Invalid number")
                Return
            End If

            Dim n As Integer = CInt(p)

            If n < 0 Or n > 255 Then
                MsgBox("Numbers must be between 0 and 255")
                Return
            End If

            binaryBlock &= Convert.ToString(n, 2).PadLeft(8, "0"c)
        Next

        binaryBlock = binaryBlock.PadRight(64, "0"c)

        Dim ip As String = InitialPermutation(binaryBlock)

        Dim L As String = ip.Substring(0, 32)
        Dim R As String = ip.Substring(32, 32)

        Dim expandedR As String = Expansion(R)

        Dim key48 As String = key64.Substring(0, 48)
        Dim xorResult As String = Xoring(expandedR, key48)

        MsgBox(
            "Input 64-bit:" & vbCrLf & binaryBlock & vbCrLf & vbCrLf &
            "After IP:" & vbCrLf & ip & vbCrLf & vbCrLf &
            "Left:" & vbCrLf & L & vbCrLf & vbCrLf &
            "Right:" & vbCrLf & R & vbCrLf & vbCrLf &
            "Expanded Right:" & vbCrLf & expandedR & vbCrLf & vbCrLf &
            "After XOR with Key:" & vbCrLf & xorResult
        )

    End Sub
    Function InitialPermutation(input64 As String) As String

        Dim ipTable As Integer() = {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        }

        Dim result As String = ""

        For i As Integer = 0 To 63
            result &= input64(ipTable(i) - 1)
        Next

        Return result

    End Function
    Function Expansion(r As String) As String

        Dim eTable As Integer() = {
            32, 1, 2, 3, 4, 5,
            4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        }

        Dim result As String = ""

        For i As Integer = 0 To 47
            result &= r(eTable(i) - 1)
        Next

        Return result

    End Function

    Function XORing(a As String, b As String) As String

        Dim result As String = ""

        For i As Integer = 0 To a.Length - 1
            If a(i) = b(i) Then
                result &= "0"
            Else
                result &= "1"
            End If
        Next

        Return result

    End Function

End Class