Public Class CTabPageIndex
    Private pageIndex As Integer
    Private nowPageIndex As Integer

    Public Sub SetLockPage(ByVal index As Integer)
        pageIndex = index
    End Sub

    Public Sub SetNowPage(ByVal index As Integer)
        nowPageIndex = index
    End Sub

    Public Function IsChange() As Boolean
        If nowPageIndex = pageIndex Then
            Return True
        End If

        Return False
    End Function
End Class