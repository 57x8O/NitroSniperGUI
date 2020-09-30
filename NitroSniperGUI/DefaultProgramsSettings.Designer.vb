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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.SniperSettingTabs = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.GoSniperTab = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Go_EnableGiveaway = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Go_CooldownInHours = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Go_MaxNitroBeforeCooldown = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Go_Token = New System.Windows.Forms.TextBox()
        Me.RustSniperTab = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Rust_EnableSnipe = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Rust_WebHook = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Rust_Token = New System.Windows.Forms.TextBox()
        Me.PythonSniperTab = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Python_Token = New System.Windows.Forms.TextBox()
        Me.SettingsTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.SniperSettingTabs.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.GoSniperTab.SuspendLayout()
        Me.RustSniperTab.SuspendLayout()
        Me.PythonSniperTab.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.SniperSettingTabs)
        Me.TabControl1.Location = New System.Drawing.Point(168, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(361, 258)
        Me.TabControl1.TabIndex = 6
        '
        'SniperSettingTabs
        '
        Me.SniperSettingTabs.Controls.Add(Me.TabControl2)
        Me.SniperSettingTabs.Location = New System.Drawing.Point(4, 22)
        Me.SniperSettingTabs.Name = "SniperSettingTabs"
        Me.SniperSettingTabs.Padding = New System.Windows.Forms.Padding(3)
        Me.SniperSettingTabs.Size = New System.Drawing.Size(353, 232)
        Me.SniperSettingTabs.TabIndex = 2
        Me.SniperSettingTabs.Text = "Sniper Settings"
        Me.SniperSettingTabs.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.GoSniperTab)
        Me.TabControl2.Controls.Add(Me.RustSniperTab)
        Me.TabControl2.Controls.Add(Me.PythonSniperTab)
        Me.TabControl2.Location = New System.Drawing.Point(0, 1)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(357, 235)
        Me.TabControl2.TabIndex = 0
        '
        'GoSniperTab
        '
        Me.GoSniperTab.Controls.Add(Me.Label1)
        Me.GoSniperTab.Controls.Add(Me.Button6)
        Me.GoSniperTab.Controls.Add(Me.Button3)
        Me.GoSniperTab.Controls.Add(Me.Go_EnableGiveaway)
        Me.GoSniperTab.Controls.Add(Me.Label10)
        Me.GoSniperTab.Controls.Add(Me.Go_CooldownInHours)
        Me.GoSniperTab.Controls.Add(Me.Label9)
        Me.GoSniperTab.Controls.Add(Me.Go_MaxNitroBeforeCooldown)
        Me.GoSniperTab.Controls.Add(Me.Label7)
        Me.GoSniperTab.Controls.Add(Me.Go_Token)
        Me.GoSniperTab.Location = New System.Drawing.Point(4, 22)
        Me.GoSniperTab.Name = "GoSniperTab"
        Me.GoSniperTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GoSniperTab.Size = New System.Drawing.Size(349, 209)
        Me.GoSniperTab.TabIndex = 1
        Me.GoSniperTab.Text = "Go based Sniper"
        Me.GoSniperTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Restart the Nitro Sniper to apply changes"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(9, 180)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(140, 23)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Edit manually"
        Me.SettingsTip.SetToolTip(Me.Button6, "Let's you change the config file manually, by opening notepad or any program of y" &
        "our choice.")
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(241, 180)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 23)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Close and Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Go_EnableGiveaway
        '
        Me.Go_EnableGiveaway.AutoSize = True
        Me.Go_EnableGiveaway.Location = New System.Drawing.Point(9, 91)
        Me.Go_EnableGiveaway.Name = "Go_EnableGiveaway"
        Me.Go_EnableGiveaway.Size = New System.Drawing.Size(140, 17)
        Me.Go_EnableGiveaway.TabIndex = 8
        Me.Go_EnableGiveaway.Text = "Enable Giveaway Joiner"
        Me.Go_EnableGiveaway.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Cooldown in hours"
        '
        'Go_CooldownInHours
        '
        Me.Go_CooldownInHours.Location = New System.Drawing.Point(123, 61)
        Me.Go_CooldownInHours.Name = "Go_CooldownInHours"
        Me.Go_CooldownInHours.Size = New System.Drawing.Size(49, 20)
        Me.Go_CooldownInHours.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Max Nitro to snipe"
        '
        'Go_MaxNitroBeforeCooldown
        '
        Me.Go_MaxNitroBeforeCooldown.Location = New System.Drawing.Point(123, 35)
        Me.Go_MaxNitroBeforeCooldown.Name = "Go_MaxNitroBeforeCooldown"
        Me.Go_MaxNitroBeforeCooldown.Size = New System.Drawing.Size(49, 20)
        Me.Go_MaxNitroBeforeCooldown.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Token"
        '
        'Go_Token
        '
        Me.Go_Token.Location = New System.Drawing.Point(50, 9)
        Me.Go_Token.Name = "Go_Token"
        Me.Go_Token.Size = New System.Drawing.Size(293, 20)
        Me.Go_Token.TabIndex = 2
        '
        'RustSniperTab
        '
        Me.RustSniperTab.Controls.Add(Me.Label2)
        Me.RustSniperTab.Controls.Add(Me.Button5)
        Me.RustSniperTab.Controls.Add(Me.Button2)
        Me.RustSniperTab.Controls.Add(Me.Rust_EnableSnipe)
        Me.RustSniperTab.Controls.Add(Me.Label6)
        Me.RustSniperTab.Controls.Add(Me.Rust_WebHook)
        Me.RustSniperTab.Controls.Add(Me.Label5)
        Me.RustSniperTab.Controls.Add(Me.Rust_Token)
        Me.RustSniperTab.Location = New System.Drawing.Point(4, 22)
        Me.RustSniperTab.Name = "RustSniperTab"
        Me.RustSniperTab.Padding = New System.Windows.Forms.Padding(3)
        Me.RustSniperTab.Size = New System.Drawing.Size(349, 209)
        Me.RustSniperTab.TabIndex = 0
        Me.RustSniperTab.Text = "Rust based Sniper"
        Me.RustSniperTab.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Restart the Nitro Sniper to apply changes"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(9, 180)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(140, 23)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "Edit manually (advanced)"
        Me.SettingsTip.SetToolTip(Me.Button5, "Let's you change the config file manually, aswell as add sub tokens and guild bla" &
        "cklists. See documentation for details.")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(241, 180)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Close and Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Rust_EnableSnipe
        '
        Me.Rust_EnableSnipe.AutoSize = True
        Me.Rust_EnableSnipe.Location = New System.Drawing.Point(9, 65)
        Me.Rust_EnableSnipe.Name = "Rust_EnableSnipe"
        Me.Rust_EnableSnipe.Size = New System.Drawing.Size(209, 17)
        Me.Rust_EnableSnipe.TabIndex = 4
        Me.Rust_EnableSnipe.Text = "Snipe on main Token / Enable Sniping"
        Me.Rust_EnableSnipe.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Webhook (advanced)"
        '
        'Rust_WebHook
        '
        Me.Rust_WebHook.Location = New System.Drawing.Point(123, 35)
        Me.Rust_WebHook.Name = "Rust_WebHook"
        Me.Rust_WebHook.Size = New System.Drawing.Size(220, 20)
        Me.Rust_WebHook.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Token"
        '
        'Rust_Token
        '
        Me.Rust_Token.Location = New System.Drawing.Point(50, 9)
        Me.Rust_Token.Name = "Rust_Token"
        Me.Rust_Token.Size = New System.Drawing.Size(293, 20)
        Me.Rust_Token.TabIndex = 0
        '
        'PythonSniperTab
        '
        Me.PythonSniperTab.Controls.Add(Me.Label11)
        Me.PythonSniperTab.Controls.Add(Me.Button7)
        Me.PythonSniperTab.Controls.Add(Me.Button4)
        Me.PythonSniperTab.Controls.Add(Me.Label8)
        Me.PythonSniperTab.Controls.Add(Me.Python_Token)
        Me.PythonSniperTab.Location = New System.Drawing.Point(4, 22)
        Me.PythonSniperTab.Name = "PythonSniperTab"
        Me.PythonSniperTab.Size = New System.Drawing.Size(349, 209)
        Me.PythonSniperTab.TabIndex = 2
        Me.PythonSniperTab.Text = "Python based Sniper"
        Me.PythonSniperTab.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(201, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Restart the Nitro Sniper to apply changes"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(9, 180)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(140, 23)
        Me.Button7.TabIndex = 17
        Me.Button7.Text = "Edit manually"
        Me.SettingsTip.SetToolTip(Me.Button7, "Let's you change the config file manually, by opening notepad or any program of y" &
        "our choice." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(241, 180)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Close and Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Token"
        '
        'Python_Token
        '
        Me.Python_Token.Location = New System.Drawing.Point(50, 9)
        Me.Python_Token.Name = "Python_Token"
        Me.Python_Token.Size = New System.Drawing.Size(293, 20)
        Me.Python_Token.TabIndex = 2
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
        'PictureBox7
        '
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox7.Image = Global.NitroSniperGUI.My.Resources.Resources.win95inst_Nitro_Sniper_GUI_Settings
        Me.PictureBox7.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(544, 319)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox7.TabIndex = 7
        Me.PictureBox7.TabStop = False
        '
        'DefaultProgramsSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(544, 319)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox7)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "DefaultProgramsSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.SniperSettingTabs.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.GoSniperTab.ResumeLayout(False)
        Me.GoSniperTab.PerformLayout()
        Me.RustSniperTab.ResumeLayout(False)
        Me.RustSniperTab.PerformLayout()
        Me.PythonSniperTab.ResumeLayout(False)
        Me.PythonSniperTab.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SettingsTip As ToolTip
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents SniperSettingTabs As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents RustSniperTab As TabPage
    Friend WithEvents Rust_EnableSnipe As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Rust_WebHook As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Rust_Token As TextBox
    Friend WithEvents GoSniperTab As TabPage
    Friend WithEvents Go_EnableGiveaway As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Go_CooldownInHours As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Go_MaxNitroBeforeCooldown As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Go_Token As TextBox
    Friend WithEvents PythonSniperTab As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents Python_Token As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
End Class
