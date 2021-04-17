' 如果要新增語言，必需將四個Select Case都新增語言，和一個ListBox1

Imports System.IO
Imports System.Text

Public Structure SGeneral
    Dim Name As String              '安裝程式的名稱
    Dim CreateInstallFile As String '封裝後生成的檔案
    Dim SourceDirectory As String   '安裝程式的來源目錄
    Dim Icon As String              '安裝程式的圖示
    Dim LicenseFile As String       '安裝程式的授權文件
End Structure

Public Structure SShortcut
    Dim Name As String
    Dim Path As String
End Structure

Public Enum EScriptText
    Install = 0
    Shortcut
    UnInstall
    RemoveShortcut
    DelInstallDirectory
    DelShortcutDirectory
End Enum

Public Class Form1
    Private InstallDB As New ArrayList
    Private ShortcutDB As New ArrayList
    Private generalSetup As SGeneral
    Private tabPageIndex As New CTabPageIndex

    ''' <summary>
    ''' 生成script文字
    ''' </summary>
    ''' <returns>傳回script文字</returns>
    Private Function CreateScript() As String
        Dim result As String = String.Empty

        result &= GetSetupText()

        ' 加入語言設定
        If ComboBox1.Items.Count > 1 Then
            result &= InsertSeparateLine()
            result &= GetInstallLanguageText()
        End If

        If Not generalSetup.LicenseFile = String.Empty AndAlso ComboBox1.Items.Count > 1 Then
            result &= GetLicenseLanguageText()
        End If
        result &= vbNewLine

        result &= GetInstallText()
        result &= GetUnInstallText()

        ' 有語言選項的話，安裝程式啟動時的選擇語言視窗
        If Not ComboBox1.Items.Count <= 1 Then
            result &= InsertSeparateLine()
            result &= "Function .onInit" & vbNewLine
            result &= "Push """"" & vbNewLine
            result &= GetLanguageSetupText()
            result &= "Push A" & vbNewLine
            result &= vbNewLine
            result &= "LangDLL::LangDialog ""Installer Language"" ""Please select the language of the installer""" & vbNewLine
            result &= vbNewLine
            result &= "Pop $LANGUAGE" & vbNewLine
            result &= "StrCmp $LANGUAGE ""cancel"" 0 +2" & vbNewLine
            result &= "Abort" & vbNewLine
            result &= "FunctionEnd"
        End If

        Return result
    End Function

    Private Function GetLanguageSetupText() As String
        Dim result As String = String.Empty

        For Each i As String In ComboBox1.Items
            Select Case i
                Case "English"
                    result &= "Push ${LANG_ENGLISH}" & vbNewLine
                    result &= "Push ""English""" & vbNewLine

                Case "日本語"
                    result &= "Push ${LANG_JAPANESE}" & vbNewLine
                    result &= "Push ""日本語""" & vbNewLine

                Case "繁體中文"
                    result &= "Push ${LANG_TRADCHINESE}" & vbNewLine
                    result &= "Push ""繁體中文""" & vbNewLine
            End Select
        Next

        Return result
    End Function

    ''' <summary>
    ''' 取得語言選項的文字
    ''' </summary>
    Private Function GetInstallLanguageText() As String
        Dim result As String = String.Empty

        For Each i As String In ComboBox1.Items
            Select Case i
                Case "English"
                    result &= "LoadLanguageFile ""${NSISDIR}\Contrib\Language files\English.nlf""" & vbNewLine
                    result &= "LangString Sec1Name ${LANG_ENGLISH} """ & generalSetup.Name & """" & vbNewLine
                    result &= "LangString unint ${LANG_ENGLISH} ""UnInstall""" & vbNewLine

                Case "日本語"
                    result &= "LoadLanguageFile ""${NSISDIR}\Contrib\Language files\Japanese.nlf""" & vbNewLine
                    result &= "LangString Sec1Name ${LANG_JAPANESE} """ & generalSetup.Name & """" & vbNewLine
                    result &= "LangString unint ${LANG_JAPANESE} ""アンインストール""" & vbNewLine

                Case "繁體中文"
                    result &= "LoadLanguageFile ""${NSISDIR}\Contrib\Language files\TradChinese.nlf""" & vbNewLine
                    result &= "LangString Sec1Name ${LANG_TRADCHINESE} """ & generalSetup.Name & """" & vbNewLine
                    result &= "LangString unint ${LANG_TRADCHINESE} ""移除""" & vbNewLine
            End Select
        Next

        Return result
    End Function

    Private Function GetLicenseLanguageText() As String
        Dim result As String = String.Empty

        For Each i As String In ComboBox1.Items
            Select Case i
                Case "English"
                    result &= "LangString licenseHelp ${LANG_ENGLISH} ""Please review the licensse terms before installing $(Sec1Name)""" & vbNewLine
                    result &= "LangString licenseButton ${LANG_ENGLISH} ""I Agree""" & vbNewLine

                Case "日本語"
                    result &= "LangString licenseHelp ${LANG_JAPANESE} ""$(Sec1Name)をインストールする前に、ライセンス条件を確認してください""" & vbNewLine
                    result &= "LangString licenseButton ${LANG_JAPANESE} ""同意する""" & vbNewLine

                Case "繁體中文"
                    result &= "LangString licenseHelp ${LANG_TRADCHINESE} ""在安裝$(Sec1Name)前，請查閱授權條款""" & vbNewLine
                    result &= "LangString licenseButton ${LANG_TRADCHINESE} ""同意""" & vbNewLine
            End Select
        Next

        Return result
    End Function

    Private Function InsertSeparateLine() As String
        Dim result As String = String.Empty

        result &= vbNewLine
        result &= ";--------------------------------" & vbNewLine
        result &= vbNewLine

        Return result
    End Function

#Region "一般設定"
    Private Function GetSetupText() As String
        Dim result As String = String.Empty

        ' 加入一般設定
        result &= "Name """ & generalSetup.Name & """" & vbNewLine
        result &= "OutFile """ & generalSetup.CreateInstallFile & """" & vbNewLine
        result &= "InstallDir ""$PROGRAMFILES\" & generalSetup.Name & """" & vbNewLine

        ' 安裝程式的圖示
        If Not generalSetup.Icon = String.Empty Then
            result &= "icon """ & generalSetup.Icon & """" & vbNewLine
        End If

        ' 授權檔案
        If Not generalSetup.LicenseFile = String.Empty Then
            If ComboBox1.Items.Count > 1 Then
                result &= "LicenseText " & """$(licenseHelp)"" " & """$(licenseButton)""" & vbNewLine
                result &= "LicenseData """ & generalSetup.LicenseFile & """" & vbNewLine
            Else
                result &= "LicenseText " & """Please review the licensse terms before installing " & generalSetup.Name & """ " & """I Agree""" & vbNewLine
                result &= "LicenseData """ & generalSetup.LicenseFile & """" & vbNewLine
            End If
        End If

        ' 以管理員權限執行
        If cbAdmin.Checked Then
            result &= "RequestExecutionLevel admin" & vbNewLine
        End If

        result &= InsertSeparateLine()

        If Not generalSetup.LicenseFile = String.Empty Then
            result &= "Page license" & vbNewLine            '版權聲明視窗
        End If
        result &= "Page components" & vbNewLine             '選擇安裝項目視窗，反安裝必備
        result &= "Page directory" & vbNewLine              '選擇安裝目錄視窗
        result &= "Page instfiles" & vbNewLine              '安裝進度視窗
        result &= "UninstPage uninstConfirm" & vbNewLine    '反安裝目錄視窗，反安裝必備
        result &= "UninstPage instfiles" & vbNewLine        '反安裝進度視度

        Return result
    End Function
#End Region

#Region "安裝"
    Private Function GetInstallText() As String
        Dim result As String = String.Empty

        result &= InsertSeparateLine()

        ' 加入安裝設定
        If ComboBox1.Items.Count > 1 Then
            result &= "Section $(Sec1Name)" & vbNewLine
        Else
            result &= "Section ""Install""" & vbNewLine
        End If
        result &= "SetOutPath $INSTDIR" & vbNewLine

        ' 排序安裝檔案清單的資料庫
        For Each sortInstallDB As ArrayList In InstallDB
            Dim sort As New CSort
            sort.QuickSortInstallDB(sortInstallDB)
        Next

        ' 複製檔案
        Dim installFile As New CScriptText
        result &= installFile.GetScriptText(ComboBox1, InstallDB, EScriptText.Install, generalSetup)

        ' 登錄安裝註冊表
        result &= InsertSeparateLine()
        result &= "WriteUninstaller ""uninstall.exe""" & vbNewLine
        result &= "WriteRegStr HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """ ""DisplayName""" & " """ & generalSetup.Name & """" & vbNewLine
        result &= "WriteRegStr HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """ ""UninstallString"" '""$INSTDIR\uninstall.exe""'" & vbNewLine
        If Not generalSetup.Icon = String.Empty Then
            result &= "WriteRegStr HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """ ""DisplayIcon"" ""$INSTDIR\" & generalSetup.Icon & """" & vbNewLine
        End If
        result &= "WriteRegDWORD HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """ ""NoModify"" 1" & vbNewLine
        result &= "WriteRegDWORD HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """ ""NoRepair"" 1" & vbNewLine
        result &= "WriteRegStr HKCU ""Software\" & generalSetup.Name & """ ""InstallDir"" $INSTDIR" & vbNewLine

        ' 加入捷徑到開始功能表
        result &= InsertSeparateLine()

        result &= "CreateDirectory ""$SMPROGRAMS\" & generalSetup.Name & """" & vbNewLine
        If ComboBox1.Items.Count <= 1 Then
            result &= "CreateShortCut ""$SMPROGRAMS\" & generalSetup.Name & "\uninstall.lnk"" ""$INSTDIR\uninstall.exe""" & vbNewLine
        Else
            result &= "CreateShortCut ""$SMPROGRAMS\" & generalSetup.Name & "\$(unint).lnk"" ""$INSTDIR\uninstall.exe""" & vbNewLine
        End If

        ' 排序捷徑清單
        For Each sortShortcutDB As ArrayList In ShortcutDB
            Dim sort As New CSort
            sort.QuickSortShortcutDB(sortShortcutDB)
        Next

        ' 加入捷徑
        Dim shortcut As New CScriptText
        result &= shortcut.GetScriptText(ComboBox1, ShortcutDB, EScriptText.Shortcut, generalSetup)

        result &= "SectionEnd" & vbNewLine

        Return result
    End Function
#End Region

#Region "反安裝"
    Private Function GetUnInstallText() As String
        Dim result As String = String.Empty

        result &= InsertSeparateLine()
        result &= "Section ""Uninstall""" & vbNewLine

        ' 移除註冊表
        result &= "DeleteRegKey HKCR ""*\shell\" & generalSetup.Name & """" & vbNewLine
        result &= "DeleteRegKey HKCU ""Software\" & generalSetup.Name & """" & vbNewLine
        result &= "DeleteRegKey HKLM ""Software\Microsoft\Windows\CurrentVersion\Uninstall\" & generalSetup.Name & """" & vbNewLine

        ' 移除檔案
        result &= "Delete ""$INSTDIR\uninstall.exe""" & vbNewLine

        Dim unInstall As New CScriptText
        result &= unInstall.GetScriptText(ComboBox1, InstallDB, EScriptText.UnInstall, generalSetup)

        ' 移除捷徑
        If ComboBox1.Items.Count <= 1 Then
            result &= "Delete ""$SMPROGRAMS\" & generalSetup.Name & "\uninstall.lnk""" & vbNewLine
        Else
            result &= "Delete ""$SMPROGRAMS\" & generalSetup.Name & "\$(unint).lnk""" & vbNewLine
        End If

        Dim removeShortcut As New CScriptText
        result &= removeShortcut.GetScriptText(ComboBox2, ShortcutDB, EScriptText.RemoveShortcut, generalSetup)

        ' 刪除所有目錄
        Dim delInstallDirectory As New CScriptText
        result &= delInstallDirectory.GetScriptText(ComboBox1, InstallDB, EScriptText.DelInstallDirectory, generalSetup)
        result &= "RMDir ""$INSTDIR""" & vbNewLine

        Dim delShortcutDirectory As New CScriptText
        result &= delShortcutDirectory.GetScriptText(ComboBox2, ShortcutDB, EScriptText.DelShortcutDirectory, generalSetup)
        result &= "RMdir ""$SMPROGRAMS\" & generalSetup.Name & """" & vbNewLine

        result &= "SectionEnd" & vbNewLine

        Return result
    End Function
#End Region

#Region "表單控制項"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvGeneral.Rows.Add(My.Resources.Language.ProgramName)
        dgvGeneral.Rows.Add(My.Resources.Language.MakeFilename, "Setup.exe")
        dgvGeneral.Rows.Add(My.Resources.Language.SourceDirectory, Application.StartupPath)
        dgvGeneral.Rows.Add(My.Resources.Language.Icon)
        dgvGeneral.Rows.Add(My.Resources.Language.License)
        'Todo: 多國語言
        dgvShortcut.Rows.Add()
        tabPageIndex.SetLockPage(1)

        generalSetup.CreateInstallFile = "Setup.exe"
        generalSetup.SourceDirectory = Application.StartupPath
        cbAdmin.Checked = True
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        InstallDB.Add(DbFactory)
        ShortcutDB.Add(DbFactory)
    End Sub

    Private Sub btnMake_Click(sender As Object, e As EventArgs) Handles btnMake.Click
        If CheckData() Then
            Using saveFile As New SaveFileDialog
                saveFile.FileName = generalSetup.Name
                saveFile.Filter = "NISI Script File(*.nsi)|*.nsi"
                If saveFile.ShowDialog = DialogResult.OK Then
                    Dim script As String = CreateScript()
                    File.WriteAllText(saveFile.FileName, script, Encoding.Unicode)
                    MsgBox(My.Resources.Language.File & saveFile.FileName & My.Resources.Language.Saved)
                End If
            End Using
        End If
    End Sub

    Private Function CheckData() As Boolean
        Dim result As Boolean = True

        If generalSetup.Name = String.Empty Then
            MsgBox(My.Resources.Language.EnterProgramName)
            Return False
        End If

        If generalSetup.CreateInstallFile = String.Empty Then
            MsgBox(My.Resources.Language.EnterProgramName)
            Return False
        End If

        If generalSetup.SourceDirectory = String.Empty Then
            MsgBox(My.Resources.Language.EnterSourceDirectoryName)
            Return False
        End If

        If Not generalSetup.Icon = String.Empty AndAlso File.Exists(generalSetup.SourceDirectory & "\" & generalSetup.Icon) Then
            MsgBox(My.Resources.Language.ICONnotExist)
            Return False
        End If

        If Not generalSetup.LicenseFile = String.Empty AndAlso File.Exists(generalSetup.SourceDirectory & "\" & generalSetup.LicenseFile) Then
            MsgBox(My.Resources.Language.LicenseNotExist)
            Return False
        End If

        Return result
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, ListBox1.DoubleClick
        If Not ListBox1.SelectedIndices.Count = 0 Then
            ListBox2.Items.Add(ListBox1.SelectedItems(0))
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, ListBox2.DoubleClick
        If Not ListBox2.SelectedIndices.Count = 0 Then
            ListBox1.Items.Add(ListBox2.SelectedItems(0))
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each i As String In ListBox1.Items
            ListBox2.Items.Add(i)
        Next
        ListBox1.Items.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For Each i As String In ListBox2.Items
            ListBox1.Items.Add(i)
        Next
        ListBox2.Items.Clear()
    End Sub

    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        Using getFilenames As New OpenFileDialog
            getFilenames.Multiselect = True

            If getFilenames.ShowDialog = DialogResult.OK Then
                For Each i As String In getFilenames.FileNames
                    Dim installFilename As String = GetInstallFilename(i)
                    If installFilename = String.Empty Then
                        Exit Sub
                    End If
                    dgvInstall.Rows.Add(installFilename)
                    InstallDB.Item(ComboBox1.SelectedIndex).Add(installFilename)
                Next
            End If
        End Using
    End Sub

    Private Function GetInstallFilename(ByVal filename As String) As String
        Dim result As String = String.Empty
        Dim directoryName As String = Strings.Left(filename, generalSetup.SourceDirectory.Length)

        If directoryName = generalSetup.SourceDirectory Then
            result = Strings.Right(filename, filename.Length - generalSetup.SourceDirectory.Length)
        Else
            MsgBox(My.Resources.Language.SourceDirectoryIsDifferent)
            Return result
        End If

        If Strings.Left(result, 1) = "\" Then
            result = Strings.Right(result, result.Length - 1)
        End If

        Return result
    End Function

    Private Sub delInstallItem_Click(sender As Object, e As EventArgs) Handles delInstallItem.Click
        If Not dgvInstall.SelectedRows.Count = 0 Then    '要讓 SelecteRows 有記錄需將 dgvInstall.SelectionMode 設為 DataGridViewSelectionMode.FullRowSelect
            For Each i As DataGridViewRow In dgvInstall.SelectedRows
                If Not i.IsNewRow Then
                    Dim delValue As String = i.Cells(0).Value
                    dgvInstall.Rows.Remove(i)
                    InstallDB.Item(ComboBox1.SelectedIndex).Remove(delValue)
                End If
            Next
        End If
    End Sub

    Private Sub delShortcutItem_Click(sender As Object, e As EventArgs) Handles delShortcutItem.Click
        If Not dgvShortcut.SelectedRows.Count = 0 Then
            For Each i As DataGridViewRow In dgvShortcut.SelectedRows
                If Not i.Index = dgvShortcut.Rows.Count - 1 Then    '因為 dgvShortcut 沒有開啟 AllowUserToAddRows (自動加入Row)，所以不會設定 IsNewRow。只能自已判定
                    Dim delValue As SShortcut
                    delValue.Name = ConvertNothingToEmpty(i.Cells(0).Value)
                    delValue.Path = ConvertNothingToEmpty(i.Cells(1).Value)
                    dgvShortcut.Rows.Remove(i)
                    ShortcutDB(ComboBox2.SelectedIndex).Remove(delValue)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' 清除安裝資料庫的內容
    ''' </summary>
    Private Sub InitilizeDB(ByRef source As ArrayList)
        For Each i As ArrayList In source
            i.Clear()
        Next
        source.Clear()
        source.Add(DbFactory())  '加入最初的空白資料庫
    End Sub

    ''' <summary>
    ''' 建立資料庫的工廠
    ''' </summary>
    Private Function DbFactory() As ArrayList
        Return New ArrayList
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dgvInstall.Rows.Clear()

        If Not InstallDB.Count = 0 Then
            For Each i As String In InstallDB.Item(ComboBox1.SelectedIndex)
                dgvInstall.Rows.Add(i)
            Next
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        dgvShortcut.Rows.Clear()

        If Not ShortcutDB.Count = 0 Then
            For Each i As SShortcut In ShortcutDB.Item(ComboBox2.SelectedIndex)
                dgvShortcut.Rows.Add(i.Name, i.Path)
            Next
        End If

        dgvShortcut.Rows.Add()
    End Sub

    Private Sub dgvGeneral_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGeneral.CellEndEdit
        Select Case e.RowIndex
            Case 0
                generalSetup.Name = dgvGeneral.Rows.Item(0).Cells(1).Value

            Case 1
                generalSetup.CreateInstallFile = dgvGeneral.Rows.Item(1).Cells(1).Value

            Case 2
                generalSetup.SourceDirectory = dgvGeneral.Rows.Item(2).Cells(1).Value

            Case 3
                generalSetup.Icon = dgvGeneral.Rows.Item(3).Cells(1).Value

            Case 4
                generalSetup.LicenseFile = dgvGeneral.Rows.Item(4).Cells(1).Value
        End Select
    End Sub

    Private Sub dgvInstall_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInstall.CellEndEdit
        If dgvInstall.Rows.Item(e.RowIndex).Cells(0).Value = String.Empty Then
            Exit Sub
        End If

        If InstallDB.Item(ComboBox1.SelectedIndex).Count + 1 = dgvInstall.Rows.Count Then    '因為DataGridView會新增一行，所以InstallDB要+1
            InstallDB.Item(ComboBox1.SelectedIndex).RemoveAt(e.RowIndex)
            InstallDB.Item(ComboBox1.SelectedIndex).Insert(e.RowIndex, dgvInstall.Rows(e.RowIndex).Cells(0).Value)
        Else
            InstallDB.Item(ComboBox1.SelectedIndex).Add(dgvInstall.Rows(dgvInstall.Rows.Count - 2).Cells(0).Value)
        End If
    End Sub

    Private Sub dgvShortcut_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShortcut.CellContentClick
        If Not e.ColumnIndex = 2 Then
            Exit Sub
        End If

        Using getFilename As New OpenFileDialog
            If getFilename.ShowDialog = DialogResult.OK Then
                For Each i As String In getFilename.FileNames
                    Dim shortcutFilename As String = GetInstallFilename(i)

                    If shortcutFilename = String.Empty Then
                        Exit Sub
                    End If

                    If e.RowIndex < ShortcutDB.Item(ComboBox2.SelectedIndex).Count Then '不是新的一行就取代原本的資料
                        Dim tmpShortcut As SShortcut
                        tmpShortcut.Name = dgvShortcut.Rows(e.RowIndex).Cells(0).Value
                        tmpShortcut.Path = shortcutFilename
                        ShortcutDB.Item(ComboBox2.SelectedIndex).RemoveAt(e.RowIndex)
                        ShortcutDB.Item(ComboBox2.SelectedIndex).Insert(e.RowIndex, tmpShortcut)
                        dgvShortcut.Rows(e.RowIndex).Cells(1).Value = shortcutFilename
                    Else
                        dgvShortcut.Rows.Item(e.RowIndex).Cells(1).Value = shortcutFilename
                        dgvShortcut.Rows.Add()

                        Dim tmpShortcut As SShortcut
                        tmpShortcut.Name = String.Empty
                        tmpShortcut.Path = shortcutFilename
                        ShortcutDB.Item(ComboBox2.SelectedIndex).Add(tmpShortcut)
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub dgvShortcut_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShortcut.CellEndEdit
        Dim tmpShortcut As SShortcut

        tmpShortcut.Name = ConvertNothingToEmpty(dgvShortcut.Rows.Item(e.RowIndex).Cells(0).Value)
        tmpShortcut.Path = ConvertNothingToEmpty(dgvShortcut.Rows.Item(e.RowIndex).Cells(1).Value)

        If e.RowIndex >= ShortcutDB.Item(ComboBox2.SelectedIndex).Count Then
            dgvShortcut.Rows.Add()
            ShortcutDB.Item(ComboBox2.SelectedIndex).Add(tmpShortcut)
        Else
            ShortcutDB.Item(ComboBox2.SelectedIndex).RemoveAt(e.RowIndex)
            ShortcutDB.Item(ComboBox2.SelectedIndex).Insert(e.RowIndex, tmpShortcut)
        End If
    End Sub

    Private Function ConvertNothingToEmpty(ByVal value As String) As String
        If value = Nothing Then
            Return String.Empty
        End If
        Return value
    End Function

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If tabPageIndex.IsChange() Then
            InitilizeDB(InstallDB)
            InitilizeDB(ShortcutDB)
            dgvInstall.Rows.Clear()
            dgvShortcut.Rows.Clear()
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox1.Items.Add("通用")
            ComboBox2.Items.Add("通用")
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0

            For Each i As String In ListBox2.Items
                ComboBox1.Items.Add(i)
                ComboBox2.Items.Add(i)
                InstallDB.Add(DbFactory())
                ShortcutDB.Add(DbFactory())
            Next
        End If

        tabPageIndex.SetNowPage(e.TabPageIndex)
    End Sub
#End Region
End Class