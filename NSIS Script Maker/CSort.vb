Public Class CSort
    Public Enum Mode
        Install = 0
        Shortcut
    End Enum

    Private Structure Range
        Dim start As Integer
        Dim [end] As Integer
    End Structure

    Private Function new_Range(ByVal s As Integer, ByVal e As Integer) As Range
        Dim r As Range

        r.start = s
        r.end = e

        Return r
    End Function

    Private Sub swap(ByRef arr As ArrayList, ByVal x As Integer, ByVal y As Integer)
        Dim t As Object = arr(x)

        arr.Insert(x, arr(y))
        arr.RemoveAt(x + 1)
        arr.Insert(y, t)
        arr.RemoveAt(y + 1)
    End Sub

    Private Function GetDirectoryCount(ByVal source As String) As Integer
        Dim result As Integer = 0

        For Each i As Char In source
            If i = "\" Then
                result += 1
            End If
        Next

        Return result
    End Function

    ''' <summary>
    ''' 對資料庫進行排序
    ''' </summary>
    ''' <param name="sourceDB">來源資料庫</param>
    Public Sub QuickSortInstallDB(ByRef sourceDB As ArrayList)
        If sourceDB.Count <= 0 Then Exit Sub

        Dim r(sourceDB.Count) As Range
        Dim p As Integer = 0

        r(p) = new_Range(0, sourceDB.Count - 1)
        p += 1

        Do While p
            Dim range As Range
            p -= 1
            range = r(p)

            If range.start < range.end Then
                Dim mid As Integer = GetDirectoryCount(sourceDB((range.start + range.end) / 2))
                Dim left As Integer = range.start
                Dim right As Integer = range.end

                Do
                    Do While GetDirectoryCount(sourceDB(left)) < mid
                        left += 1
                    Loop

                    Do While GetDirectoryCount(sourceDB(right)) > mid
                        right -= 1
                    Loop

                    If left <= right Then
                        swap(sourceDB, left, right)
                        left += 1
                        right -= 1
                    End If
                Loop While left <= right

                If range.start < right Then
                    r(p) = new_Range(range.start, right)
                    p += 1
                End If

                If range.end > left Then
                    r(p) = new_Range(left, range.end)
                    p += 1
                End If
            End If
        Loop
    End Sub

    Public Sub QuickSortShortcutDB(ByRef sourceDB As ArrayList)
        If sourceDB.Count <= 0 Then Exit Sub

        Dim r(sourceDB.Count) As Range
        Dim p As Integer = 0

        r(p) = new_Range(0, sourceDB.Count - 1)
        p += 1

        Do While p
            Dim range As Range
            p -= 1
            range = r(p)

            If range.start < range.end Then
                Dim mid As Integer = GetDirectoryCount(sourceDB((range.start + range.end) / 2).Path)
                Dim left As Integer = range.start
                Dim right As Integer = range.end

                Do
                    Do While GetDirectoryCount(sourceDB(left).Path) < mid
                        left += 1
                    Loop

                    Do While GetDirectoryCount(sourceDB(right).Path) > mid
                        right -= 1
                    Loop

                    If left <= right Then
                        swap(sourceDB, left, right)
                        left += 1
                        right -= 1
                    End If
                Loop While left <= right

                If range.start < right Then
                    r(p) = new_Range(range.start, right)
                    p += 1
                End If

                If range.end > left Then
                    r(p) = new_Range(left, range.end)
                    p += 1
                End If
            End If
        Loop
    End Sub
End Class