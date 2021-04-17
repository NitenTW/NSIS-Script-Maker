Public Class COutPath
    Public outPath As String = String.Empty

    Public Function GetOutPath(ByVal path As String) As String
        For i As Integer = path.Length - 1 To 0 Step -1
            If path(i) = "\" Then
                Dim result As String = Strings.Left(path, i)
                Return Strings.Left(path, i)
            End If
        Next

        Return String.Empty
    End Function
End Class