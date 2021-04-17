<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnMake = New System.Windows.Forms.Button()
        Me.Install = New System.Windows.Forms.TabPage()
        Me.btnAddFile = New System.Windows.Forms.Button()
        Me.dgvInstall = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.popupInstall = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.delInstallItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Language = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.General = New System.Windows.Forms.TabPage()
        Me.cbAdmin = New System.Windows.Forms.CheckBox()
        Me.dgvGeneral = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Shortcut = New System.Windows.Forms.TabPage()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.dgvShortcut = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.popupShortcut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.delShortcutItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Install.SuspendLayout()
        CType(Me.dgvInstall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupInstall.SuspendLayout()
        Me.Language.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Shortcut.SuspendLayout()
        CType(Me.dgvShortcut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupShortcut.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMake
        '
        resources.ApplyResources(Me.btnMake, "btnMake")
        Me.btnMake.Name = "btnMake"
        Me.btnMake.UseVisualStyleBackColor = True
        '
        'Install
        '
        Me.Install.Controls.Add(Me.btnAddFile)
        Me.Install.Controls.Add(Me.dgvInstall)
        Me.Install.Controls.Add(Me.ComboBox1)
        resources.ApplyResources(Me.Install, "Install")
        Me.Install.Name = "Install"
        Me.Install.UseVisualStyleBackColor = True
        '
        'btnAddFile
        '
        resources.ApplyResources(Me.btnAddFile, "btnAddFile")
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.UseVisualStyleBackColor = True
        '
        'dgvInstall
        '
        Me.dgvInstall.AllowUserToDeleteRows = False
        Me.dgvInstall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInstall.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3})
        Me.dgvInstall.ContextMenuStrip = Me.popupInstall
        resources.ApplyResources(Me.dgvInstall, "dgvInstall")
        Me.dgvInstall.Name = "dgvInstall"
        Me.dgvInstall.RowHeadersVisible = False
        Me.dgvInstall.RowTemplate.Height = 24
        Me.dgvInstall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'popupInstall
        '
        Me.popupInstall.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.delInstallItem})
        Me.popupInstall.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.popupInstall, "popupInstall")
        '
        'delInstallItem
        '
        Me.delInstallItem.Name = "delInstallItem"
        resources.ApplyResources(Me.delInstallItem, "delInstallItem")
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items")})
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Language
        '
        Me.Language.Controls.Add(Me.Button4)
        Me.Language.Controls.Add(Me.Button3)
        Me.Language.Controls.Add(Me.Button2)
        Me.Language.Controls.Add(Me.Button1)
        Me.Language.Controls.Add(Me.ListBox2)
        Me.Language.Controls.Add(Me.ListBox1)
        resources.ApplyResources(Me.Language, "Language")
        Me.Language.Name = "Language"
        Me.Language.UseVisualStyleBackColor = True
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.Name = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        resources.ApplyResources(Me.ListBox2, "ListBox2")
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Name = "ListBox2"
        '
        'ListBox1
        '
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {resources.GetString("ListBox1.Items"), resources.GetString("ListBox1.Items1"), resources.GetString("ListBox1.Items2")})
        Me.ListBox1.Name = "ListBox1"
        '
        'General
        '
        Me.General.Controls.Add(Me.cbAdmin)
        Me.General.Controls.Add(Me.dgvGeneral)
        resources.ApplyResources(Me.General, "General")
        Me.General.Name = "General"
        Me.General.UseVisualStyleBackColor = True
        '
        'cbAdmin
        '
        resources.ApplyResources(Me.cbAdmin, "cbAdmin")
        Me.cbAdmin.Name = "cbAdmin"
        Me.cbAdmin.UseVisualStyleBackColor = True
        '
        'dgvGeneral
        '
        Me.dgvGeneral.AllowUserToAddRows = False
        Me.dgvGeneral.AllowUserToDeleteRows = False
        Me.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGeneral.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        resources.ApplyResources(Me.dgvGeneral, "dgvGeneral")
        Me.dgvGeneral.Name = "dgvGeneral"
        Me.dgvGeneral.RowHeadersVisible = False
        Me.dgvGeneral.RowTemplate.Height = 24
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.General)
        Me.TabControl1.Controls.Add(Me.Language)
        Me.TabControl1.Controls.Add(Me.Install)
        Me.TabControl1.Controls.Add(Me.Shortcut)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'Shortcut
        '
        Me.Shortcut.Controls.Add(Me.ComboBox2)
        Me.Shortcut.Controls.Add(Me.dgvShortcut)
        resources.ApplyResources(Me.Shortcut, "Shortcut")
        Me.Shortcut.Name = "Shortcut"
        Me.Shortcut.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {resources.GetString("ComboBox2.Items")})
        resources.ApplyResources(Me.ComboBox2, "ComboBox2")
        Me.ComboBox2.Name = "ComboBox2"
        '
        'dgvShortcut
        '
        Me.dgvShortcut.AllowUserToAddRows = False
        Me.dgvShortcut.AllowUserToDeleteRows = False
        Me.dgvShortcut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortcut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5, Me.Column6})
        Me.dgvShortcut.ContextMenuStrip = Me.popupShortcut
        resources.ApplyResources(Me.dgvShortcut, "dgvShortcut")
        Me.dgvShortcut.Name = "dgvShortcut"
        Me.dgvShortcut.RowHeadersVisible = False
        Me.dgvShortcut.RowTemplate.Height = 24
        Me.dgvShortcut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.Column4, "Column4")
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.Column5, "Column5")
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        resources.ApplyResources(Me.Column6, "Column6")
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.Text = "追加"
        Me.Column6.UseColumnTextForButtonValue = True
        '
        'popupShortcut
        '
        Me.popupShortcut.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.delShortcutItem})
        Me.popupShortcut.Name = "popupShortcut"
        resources.ApplyResources(Me.popupShortcut, "popupShortcut")
        '
        'delShortcutItem
        '
        Me.delShortcutItem.Name = "delShortcutItem"
        resources.ApplyResources(Me.delShortcutItem, "delShortcutItem")
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnMake)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Install.ResumeLayout(False)
        CType(Me.dgvInstall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupInstall.ResumeLayout(False)
        Me.Language.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Shortcut.ResumeLayout(False)
        CType(Me.dgvShortcut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupShortcut.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMake As Button
    Friend WithEvents Install As TabPage
    Friend WithEvents Language As TabPage
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents General As TabPage
    Friend WithEvents dgvGeneral As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents cbAdmin As CheckBox
    Friend WithEvents dgvInstall As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnAddFile As Button
    Friend WithEvents popupInstall As ContextMenuStrip
    Friend WithEvents delInstallItem As ToolStripMenuItem
    Friend WithEvents Shortcut As TabPage
    Friend WithEvents dgvShortcut As DataGridView
    Friend WithEvents popupShortcut As ContextMenuStrip
    Friend WithEvents delShortcutItem As ToolStripMenuItem
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewButtonColumn
End Class
