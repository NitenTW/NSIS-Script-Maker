Public Class CScriptText
    Public Function GetScriptText(ByRef comboBox As ComboBox, ByRef db As ArrayList, ByVal state As EScriptText, ByRef generalSetup As SGeneral)
        Dim result As String = String.Empty

        For index As Integer = 0 To comboBox.Items.Count - 1
            Select Case comboBox.Items(index)
                Case "通用"
                    result &= GetText(index, db, state, generalSetup)

                Case "English"
                    result &= GetText(index, "StrCmp $LANGUAGE ${LANG_ENGLISH} 0 +", db, state, generalSetup)

                Case "日本語"
                    result &= GetText(index, "StrCmp $LANGUAGE ${LANG_JAPANESE} 0 +", db, state, generalSetup)

                Case "繁體中文"
                    result &= GetText(index, "StrCmp $LANGUAGE ${LANG_TRADCHINESE} 0 +", db, state, generalSetup)
            End Select
        Next

        Return result
    End Function

    Private Function GetText(ByVal index As UInteger, ByRef db As ArrayList, ByVal state As EScriptText, ByRef generalSetup As SGeneral) As String
        Dim result As String = String.Empty

        Select Case state
            Case EScriptText.Install
                result = GetInstallText(index, 0, db)

            Case EScriptText.Shortcut
                result = GetShortcutText(index, 0, db, generalSetup)

            Case EScriptText.UnInstall
                result = GetUnInstallText(index, 0, db)

            Case EScriptText.RemoveShortcut
                result = GetRemoveShortcutText(index, 0, db, generalSetup)

            Case EScriptText.DelInstallDirectory
                result = GetDelInstallDirectoryText(index, 0, db)

            Case EScriptText.DelShortcutDirectory
                result = GetDelShortcutDirectoryText(index, 0, db, generalSetup)
        End Select

        Return result
    End Function

    Private Function GetText(ByVal index As UInteger, ByVal strcmp As String, ByRef db As ArrayList, ByVal state As EScriptText, ByRef generalSetup As SGeneral) As String
        Dim result As String = String.Empty
        Dim tmpText As String = String.Empty
        Dim count As String = 1

        Select Case state
            Case EScriptText.Install
                tmpText &= GetInstallText(index, count, db)

            Case EScriptText.Shortcut
                tmpText &= GetShortcutText(index, count, db, generalSetup)

            Case EScriptText.UnInstall
                tmpText &= GetUnInstallText(index, count, db)

            Case EScriptText.RemoveShortcut
                tmpText &= GetRemoveShortcutText(index, count, db, generalSetup)

            Case EScriptText.DelInstallDirectory
                tmpText &= GetDelInstallDirectoryText(index, count, db)

            Case EScriptText.DelShortcutDirectory
                tmpText &= GetDelShortcutDirectoryText(index, count, db, generalSetup)
        End Select

        If Not tmpText = String.Empty Then
            result &= strcmp & count & vbNewLine
            result &= tmpText
        End If

        Return result
    End Function

    Private Function GetInstallText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList) As String
        Dim result As String = String.Empty

        For Each i As String In db.Item(index)
            Dim outPath As New COutPath
            Dim tmpOutPath As String = outPath.GetOutPath(i)

            If outPath.outPath = tmpOutPath Then
                result &= "File """ & i & """" & vbNewLine
            Else
                result &= "SetOutPath $INSTDIR\" & tmpOutPath & vbNewLine
                result &= "File """ & i & """" & vbNewLine
                outPath.outPath = tmpOutPath
                count += 1
            End If

            count += 1
        Next

        Return result
    End Function

    Private Function GetShortcutText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList, ByRef generalSetup As SGeneral) As String
        Dim result As String = String.Empty

        For Each i As SShortcut In db.Item(index)
            Dim outPath As New COutPath
            Dim tmpOutPath As String = outPath.GetOutPath(i.Name)

            If outPath.outPath = tmpOutPath Then
                result &= "CreateShortCut ""$SMPROGRAMS\" & generalSetup.Name & "\" & i.Name & ".lnk"" ""$INSTDIR\" & i.Path & """" & vbNewLine
            Else
                result &= "CreateDirectory ""$SMPROGRAMS\" & generalSetup.Name & "\" & tmpOutPath & """" & vbNewLine
                result &= "CreateShortCut ""$SMPROGRAMS\" & generalSetup.Name & "\" & i.Name & ".lnk"" ""$INSTDIR\" & i.Path & """" & vbNewLine
                outPath.outPath = tmpOutPath
                count += 1
            End If

            count += 1
        Next

        Return result
    End Function

    Private Function GetUnInstallText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList) As String
        Dim result As String = String.Empty

        For Each i As String In db.Item(index)
            result &= "Delete ""$INSTDIR\" & i & """" & vbNewLine
            count += 1
        Next

        Return result
    End Function

    Private Function GetRemoveShortcutText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList, ByRef generalSetup As SGeneral) As String
        Dim result As String = String.Empty

        For Each i As SShortcut In db.Item(index)
            result &= "Delete ""$SMPROGRAMS\" & generalSetup.Name & "\" & i.Name & ".lnk""" & vbNewLine
            count += 1
        Next

        Return result
    End Function

    Private Function GetDelInstallDirectoryText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList) As String
        Dim result As String = String.Empty
        Dim path As ArrayList = GetInstallDirectory(index, db)
        Dim tmpPath As String = String.Empty
        'Todo: 如果是很多層目錄的情況
        If Not path.Count = 0 Then
            For Each i As String In path
                Debug.WriteLine(i)
                result &= "RMDir ""$INSTDIR\" & i & """" & vbNewLine
                count += 1
            Next
        End If

        Return result
    End Function

    Private Function GetInstallDirectory(ByVal index As Integer, ByRef db As ArrayList) As ArrayList
        Dim result As New ArrayList

        For Each i As String In db.Item(index)
            Dim outPath As New COutPath
            Dim path As String = outPath.GetOutPath(i)

            If Not path = String.Empty Then
                result.Add(path)
            End If
        Next

        result.Reverse()

        Return result
    End Function

    Private Function GetDelShortcutDirectoryText(ByVal index As Integer, ByRef count As Integer, ByRef db As ArrayList, ByRef generalSetup As SGeneral) As String
        Dim result As String = String.Empty
        Dim path As ArrayList = GetShortcutDirectory(index, db)
        'Todo: 如果是很多層目錄的情況
        If Not path.Count = 0 Then
            For Each i As String In path
                result &= "RMDir ""$SMPROGRAMS\" & generalSetup.Name & "\" & i & """" & vbNewLine
                count += 1
            Next
        End If

        Return result
    End Function

    Private Function GetShortcutDirectory(ByVal index As Integer, ByRef db As ArrayList) As ArrayList
        Dim result As New ArrayList

        For Each i As SShortcut In db.Item(index)
            Dim outPath As New COutPath
            Dim path As String = outPath.GetOutPath(i.Name)

            If Not path = String.Empty Then
                result.Add(path)
            End If
        Next

        result.Reverse()

        Return result
    End Function
End Class