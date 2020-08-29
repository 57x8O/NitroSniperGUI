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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefaultProgramsSettings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SystemDefinedBtn = New System.Windows.Forms.RadioButton()
        Me.NotepadSystem32Btn = New System.Windows.Forms.RadioButton()
        Me.NotepadWinBtn = New System.Windows.Forms.RadioButton()
        Me.Writebtn = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.DefaultProgramsTab = New System.Windows.Forms.TabPage()
        Me.NF3 = New System.Windows.Forms.Label()
        Me.NF2 = New System.Windows.Forms.Label()
        Me.NF1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.WindowMgmntTab = New System.Windows.Forms.TabPage()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OutsideAppBtn = New System.Windows.Forms.RadioButton()
        Me.InsideAppBtn = New System.Windows.Forms.RadioButton()
        Me.SettingsTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.DefaultProgramsTab.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WindowMgmntTab.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.NotepadWinBtn.Size = New System.Drawing.Size(179, 17)
        Me.NotepadWinBtn.TabIndex = 3
        Me.NotepadWinBtn.Text = "Notepad (32-bit) in C:\Windows\"
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
        Me.TabControl1.Size = New System.Drawing.Size(329, 194)
        Me.TabControl1.TabIndex = 6
        '
        'DefaultProgramsTab
        '
        Me.DefaultProgramsTab.Controls.Add(Me.NF3)
        Me.DefaultProgramsTab.Controls.Add(Me.NF2)
        Me.DefaultProgramsTab.Controls.Add(Me.NF1)
        Me.DefaultProgramsTab.Controls.Add(Me.PictureBox4)
        Me.DefaultProgramsTab.Controls.Add(Me.PictureBox3)
        Me.DefaultProgramsTab.Controls.Add(Me.PictureBox2)
        Me.DefaultProgramsTab.Controls.Add(Me.PictureBox1)
        Me.DefaultProgramsTab.Controls.Add(Me.Label1)
        Me.DefaultProgramsTab.Controls.Add(Me.Label2)
        Me.DefaultProgramsTab.Controls.Add(Me.SystemDefinedBtn)
        Me.DefaultProgramsTab.Controls.Add(Me.Writebtn)
        Me.DefaultProgramsTab.Controls.Add(Me.NotepadSystem32Btn)
        Me.DefaultProgramsTab.Controls.Add(Me.NotepadWinBtn)
        Me.DefaultProgramsTab.Location = New System.Drawing.Point(4, 4)
        Me.DefaultProgramsTab.Name = "DefaultProgramsTab"
        Me.DefaultProgramsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DefaultProgramsTab.Size = New System.Drawing.Size(321, 168)
        Me.DefaultProgramsTab.TabIndex = 0
        Me.DefaultProgramsTab.Text = "Default Programs"
        Me.DefaultProgramsTab.UseVisualStyleBackColor = True
        '
        'NF3
        '
        Me.NF3.AutoSize = True
        Me.NF3.Location = New System.Drawing.Point(241, 112)
        Me.NF3.Name = "NF3"
        Me.NF3.Size = New System.Drawing.Size(68, 13)
        Me.NF3.TabIndex = 13
        Me.NF3.Text = "Not installed."
        Me.SettingsTip.SetToolTip(Me.NF3, "Install WordPad in order to use this option.")
        '
        'NF2
        '
        Me.NF2.AutoSize = True
        Me.NF2.Location = New System.Drawing.Point(241, 89)
        Me.NF2.Name = "NF2"
        Me.NF2.Size = New System.Drawing.Size(68, 13)
        Me.NF2.TabIndex = 12
        Me.NF2.Text = "Not installed."
        Me.SettingsTip.SetToolTip(Me.NF2, "Install Notepad in order to use this option.")
        '
        'NF1
        '
        Me.NF1.AutoSize = True
        Me.NF1.Location = New System.Drawing.Point(241, 66)
        Me.NF1.Name = "NF1"
        Me.NF1.Size = New System.Drawing.Size(68, 13)
        Me.NF1.TabIndex = 11
        Me.NF1.Text = "Not installed."
        Me.SettingsTip.SetToolTip(Me.NF1, "Install Notepad in order to use this option.")
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(193, 109)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox4, "Opens the config file with Wordpad.")
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(193, 85)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox3, "Opens the config file with C:\Windows\Notepad.exe")
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(210, 63)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox2, "Opens the config file with C:\Windows\System32\Notepad.exe")
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(293, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox1, "Let's the System choose, what to open JSON files with. You may be asked to choose" &
        " a application yourself.")
        '
        'WindowMgmntTab
        '
        Me.WindowMgmntTab.Controls.Add(Me.PictureBox5)
        Me.WindowMgmntTab.Controls.Add(Me.PictureBox6)
        Me.WindowMgmntTab.Controls.Add(Me.Label4)
        Me.WindowMgmntTab.Controls.Add(Me.Label3)
        Me.WindowMgmntTab.Controls.Add(Me.OutsideAppBtn)
        Me.WindowMgmntTab.Controls.Add(Me.InsideAppBtn)
        Me.WindowMgmntTab.Location = New System.Drawing.Point(4, 4)
        Me.WindowMgmntTab.Name = "WindowMgmntTab"
        Me.WindowMgmntTab.Padding = New System.Windows.Forms.Padding(3)
        Me.WindowMgmntTab.Size = New System.Drawing.Size(321, 168)
        Me.WindowMgmntTab.TabIndex = 1
        Me.WindowMgmntTab.Text = "MDI Container Managment Settings"
        Me.WindowMgmntTab.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(232, 85)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 12
        Me.PictureBox5.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox5, "Opens the Editor Window outside Nitro Sniper GUI.")
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(225, 51)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox6.TabIndex = 11
        Me.PictureBox6.TabStop = False
        Me.SettingsTip.SetToolTip(Me.PictureBox6, "Opens the Editor Window inside Nitro Sniper GUI.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 137)
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
        Me.OutsideAppBtn.Checked = True
        Me.OutsideAppBtn.Location = New System.Drawing.Point(11, 85)
        Me.OutsideAppBtn.Name = "OutsideAppBtn"
        Me.OutsideAppBtn.Size = New System.Drawing.Size(215, 17)
        Me.OutsideAppBtn.TabIndex = 1
        Me.OutsideAppBtn.TabStop = True
        Me.OutsideAppBtn.Text = "Open Editor Window outside Application"
        Me.OutsideAppBtn.UseVisualStyleBackColor = True
        '
        'InsideAppBtn
        '
        Me.InsideAppBtn.AutoSize = True
        Me.InsideAppBtn.Location = New System.Drawing.Point(11, 51)
        Me.InsideAppBtn.Name = "InsideAppBtn"
        Me.InsideAppBtn.Size = New System.Drawing.Size(208, 17)
        Me.InsideAppBtn.TabIndex = 0
        Me.InsideAppBtn.Text = "Open Editor Window inside Application"
        Me.InsideAppBtn.UseVisualStyleBackColor = True
        '
        'SettingsTip
        '
        Me.SettingsTip.AutomaticDelay = 0
        Me.SettingsTip.AutoPopDelay = 32767
        Me.SettingsTip.InitialDelay = 100
        Me.SettingsTip.IsBalloon = True
        Me.SettingsTip.ReshowDelay = 350
        Me.SettingsTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'DefaultProgramsSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(329, 194)
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
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WindowMgmntTab.ResumeLayout(False)
        Me.WindowMgmntTab.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SettingsTip As ToolTip
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents NF3 As Label
    Friend WithEvents NF2 As Label
    Friend WithEvents NF1 As Label
End Class
