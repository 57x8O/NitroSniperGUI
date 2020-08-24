<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefaultProgramsSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SystemDefinedBtn = New System.Windows.Forms.RadioButton()
        Me.NotepadSystem32Btn = New System.Windows.Forms.RadioButton()
        Me.NotepadWinBtn = New System.Windows.Forms.RadioButton()
        Me.Writebtn = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.DefaultProgramsTab = New System.Windows.Forms.TabPage()
        Me.WindowMgmntTab = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OutsideAppBtn = New System.Windows.Forms.RadioButton()
        Me.InsideAppBtn = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.DefaultProgramsTab.SuspendLayout()
        Me.WindowMgmntTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Default Program for JSON files"
        '
        'SystemDefinedBtn
        '
        Me.SystemDefinedBtn.AutoSize = True
        Me.SystemDefinedBtn.Checked = True
        Me.SystemDefinedBtn.Location = New System.Drawing.Point(9, 39)
        Me.SystemDefinedBtn.Name = "SystemDefinedBtn"
        Me.SystemDefinedBtn.Size = New System.Drawing.Size(278, 17)
        Me.SystemDefinedBtn.TabIndex = 1
        Me.SystemDefinedBtn.TabStop = True
        Me.SystemDefinedBtn.Tag = "i"
        Me.SystemDefinedBtn.Text = "System defined (System chooses what to open it with)"
        Me.SystemDefinedBtn.UseVisualStyleBackColor = True
        '
        'NotepadSystem32Btn
        '
        Me.NotepadSystem32Btn.AutoSize = True
        Me.NotepadSystem32Btn.Enabled = False
        Me.NotepadSystem32Btn.Location = New System.Drawing.Point(9, 62)
        Me.NotepadSystem32Btn.Name = "NotepadSystem32Btn"
        Me.NotepadSystem32Btn.Size = New System.Drawing.Size(195, 17)
        Me.NotepadSystem32Btn.TabIndex = 2
        Me.NotepadSystem32Btn.Text = "Notepad in C:\Windows\System32\"
        Me.NotepadSystem32Btn.UseVisualStyleBackColor = True
        '
        'NotepadWinBtn
        '
        Me.NotepadWinBtn.AutoSize = True
        Me.NotepadWinBtn.Enabled = False
        Me.NotepadWinBtn.Location = New System.Drawing.Point(9, 85)
        Me.NotepadWinBtn.Name = "NotepadWinBtn"
        Me.NotepadWinBtn.Size = New System.Drawing.Size(144, 17)
        Me.NotepadWinBtn.TabIndex = 3
        Me.NotepadWinBtn.Text = "Notepad in C:\Windows\"
        Me.NotepadWinBtn.UseVisualStyleBackColor = True
        '
        'Writebtn
        '
        Me.Writebtn.AutoSize = True
        Me.Writebtn.Enabled = False
        Me.Writebtn.Location = New System.Drawing.Point(9, 108)
        Me.Writebtn.Name = "Writebtn"
        Me.Writebtn.Size = New System.Drawing.Size(178, 17)
        Me.Writebtn.TabIndex = 4
        Me.Writebtn.Text = "Write/WordPad in C:\Windows\"
        Me.Writebtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Restart NitroSniperGUI to apply changes"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.DefaultProgramsTab)
        Me.TabControl1.Controls.Add(Me.WindowMgmntTab)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(316, 194)
        Me.TabControl1.TabIndex = 6
        '
        'DefaultProgramsTab
        '
        Me.DefaultProgramsTab.Controls.Add(Me.Label1)
        Me.DefaultProgramsTab.Controls.Add(Me.Label2)
        Me.DefaultProgramsTab.Controls.Add(Me.SystemDefinedBtn)
        Me.DefaultProgramsTab.Controls.Add(Me.Writebtn)
        Me.DefaultProgramsTab.Controls.Add(Me.NotepadSystem32Btn)
        Me.DefaultProgramsTab.Controls.Add(Me.NotepadWinBtn)
        Me.DefaultProgramsTab.Location = New System.Drawing.Point(4, 4)
        Me.DefaultProgramsTab.Name = "DefaultProgramsTab"
        Me.DefaultProgramsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DefaultProgramsTab.Size = New System.Drawing.Size(308, 168)
        Me.DefaultProgramsTab.TabIndex = 0
        Me.DefaultProgramsTab.Text = "Default Programs"
        Me.DefaultProgramsTab.UseVisualStyleBackColor = True
        '
        'WindowMgmntTab
        '
        Me.WindowMgmntTab.Controls.Add(Me.Label4)
        Me.WindowMgmntTab.Controls.Add(Me.Label3)
        Me.WindowMgmntTab.Controls.Add(Me.OutsideAppBtn)
        Me.WindowMgmntTab.Controls.Add(Me.InsideAppBtn)
        Me.WindowMgmntTab.Location = New System.Drawing.Point(4, 4)
        Me.WindowMgmntTab.Name = "WindowMgmntTab"
        Me.WindowMgmntTab.Padding = New System.Windows.Forms.Padding(3)
        Me.WindowMgmntTab.Size = New System.Drawing.Size(308, 168)
        Me.WindowMgmntTab.TabIndex = 1
        Me.WindowMgmntTab.Text = "MDI Container Managment Settings"
        Me.WindowMgmntTab.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Restart NitroSniperGUI to apply changes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Config Editor Window Placement"
        '
        'OutsideAppBtn
        '
        Me.OutsideAppBtn.AutoSize = True
        Me.OutsideAppBtn.Location = New System.Drawing.Point(11, 85)
        Me.OutsideAppBtn.Name = "OutsideAppBtn"
        Me.OutsideAppBtn.Size = New System.Drawing.Size(215, 17)
        Me.OutsideAppBtn.TabIndex = 1
        Me.OutsideAppBtn.Text = "Open Editor Window outside Application"
        Me.OutsideAppBtn.UseVisualStyleBackColor = True
        '
        'InsideAppBtn
        '
        Me.InsideAppBtn.AutoSize = True
        Me.InsideAppBtn.Checked = True
        Me.InsideAppBtn.Location = New System.Drawing.Point(11, 51)
        Me.InsideAppBtn.Name = "InsideAppBtn"
        Me.InsideAppBtn.Size = New System.Drawing.Size(208, 17)
        Me.InsideAppBtn.TabIndex = 0
        Me.InsideAppBtn.TabStop = True
        Me.InsideAppBtn.Text = "Open Editor Window inside Application"
        Me.InsideAppBtn.UseVisualStyleBackColor = True
        '
        'DefaultProgramsSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(316, 194)
        Me.Controls.Add(Me.TabControl1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "DefaultProgramsSettings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.DefaultProgramsTab.ResumeLayout(False)
        Me.DefaultProgramsTab.PerformLayout()
        Me.WindowMgmntTab.ResumeLayout(False)
        Me.WindowMgmntTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SystemDefinedBtn As RadioButton
    Friend WithEvents NotepadSystem32Btn As RadioButton
    Friend WithEvents NotepadWinBtn As RadioButton
    Friend WithEvents Writebtn As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents DefaultProgramsTab As TabPage
    Friend WithEvents WindowMgmntTab As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents OutsideAppBtn As RadioButton
    Friend WithEvents InsideAppBtn As RadioButton
    Friend WithEvents Label4 As Label
End Class
