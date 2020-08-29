<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMdiContainerForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMdiContainerForm))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PythonNitroSniperConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoNitroSniperConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RustNitroSniperConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartPythonBasedNitroSniperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartGoBasedNitroSniperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartRustBasedNitroSniperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.WindowControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaximizeAllWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizeAllWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DefaultProgramSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LicenseToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status, Me.StatusBar, Me.ToolToolStripDropDownButton, Me.HelpToolStripDropDownButton, Me.LicenseToolStripDropDownButton})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusBar
        '
        Me.StatusBar.BackColor = System.Drawing.SystemColors.Control
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(152, 16)
        Me.StatusBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 707)
        Me.Panel1.TabIndex = 1
        Me.Panel1.TabStop = True
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        Me.Status.Image = CType(resources.GetObject("Status.Image"), System.Drawing.Image)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(51, 17)
        Me.Status.Text = "Done"
        '
        'ToolToolStripDropDownButton
        '
        Me.ToolToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ConfigFilesToolStripMenuItem, Me.ToolStripSeparator1, Me.StartPythonBasedNitroSniperToolStripMenuItem, Me.StartGoBasedNitroSniperToolStripMenuItem, Me.StartRustBasedNitroSniperToolStripMenuItem, Me.ToolStripSeparator2, Me.WindowControlsToolStripMenuItem, Me.ToolStripSeparator3, Me.DefaultProgramSettingsToolStripMenuItem})
        Me.ToolToolStripDropDownButton.Image = CType(resources.GetObject("ToolToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.ToolToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolToolStripDropDownButton.Name = "ToolToolStripDropDownButton"
        Me.ToolToolStripDropDownButton.Size = New System.Drawing.Size(63, 20)
        Me.ToolToolStripDropDownButton.Text = "Tools"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ConfigFilesToolStripMenuItem
        '
        Me.ConfigFilesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PythonNitroSniperConfigToolStripMenuItem, Me.GoNitroSniperConfigToolStripMenuItem, Me.RustNitroSniperConfigToolStripMenuItem})
        Me.ConfigFilesToolStripMenuItem.Image = CType(resources.GetObject("ConfigFilesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigFilesToolStripMenuItem.Name = "ConfigFilesToolStripMenuItem"
        Me.ConfigFilesToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ConfigFilesToolStripMenuItem.Text = "Config Files"
        '
        'PythonNitroSniperConfigToolStripMenuItem
        '
        Me.PythonNitroSniperConfigToolStripMenuItem.Image = CType(resources.GetObject("PythonNitroSniperConfigToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PythonNitroSniperConfigToolStripMenuItem.Name = "PythonNitroSniperConfigToolStripMenuItem"
        Me.PythonNitroSniperConfigToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PythonNitroSniperConfigToolStripMenuItem.Text = "Python Nitro Sniper Config"
        '
        'GoNitroSniperConfigToolStripMenuItem
        '
        Me.GoNitroSniperConfigToolStripMenuItem.Image = CType(resources.GetObject("GoNitroSniperConfigToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GoNitroSniperConfigToolStripMenuItem.Name = "GoNitroSniperConfigToolStripMenuItem"
        Me.GoNitroSniperConfigToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.GoNitroSniperConfigToolStripMenuItem.Text = "Go Nitro Sniper Config"
        '
        'RustNitroSniperConfigToolStripMenuItem
        '
        Me.RustNitroSniperConfigToolStripMenuItem.Image = CType(resources.GetObject("RustNitroSniperConfigToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RustNitroSniperConfigToolStripMenuItem.Name = "RustNitroSniperConfigToolStripMenuItem"
        Me.RustNitroSniperConfigToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.RustNitroSniperConfigToolStripMenuItem.Text = "Rust Nitro Sniper Config"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(236, 6)
        '
        'StartPythonBasedNitroSniperToolStripMenuItem
        '
        Me.StartPythonBasedNitroSniperToolStripMenuItem.AutoToolTip = True
        Me.StartPythonBasedNitroSniperToolStripMenuItem.Image = Global.NitroSniperGUI.My.Resources.Resources.python_language_logo
        Me.StartPythonBasedNitroSniperToolStripMenuItem.Name = "StartPythonBasedNitroSniperToolStripMenuItem"
        Me.StartPythonBasedNitroSniperToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.StartPythonBasedNitroSniperToolStripMenuItem.Text = "Start Python based Nitro Sniper"
        Me.StartPythonBasedNitroSniperToolStripMenuItem.ToolTipText = resources.GetString("StartPythonBasedNitroSniperToolStripMenuItem.ToolTipText")
        '
        'StartGoBasedNitroSniperToolStripMenuItem
        '
        Me.StartGoBasedNitroSniperToolStripMenuItem.AutoToolTip = True
        Me.StartGoBasedNitroSniperToolStripMenuItem.Image = Global.NitroSniperGUI.My.Resources.Resources._10
        Me.StartGoBasedNitroSniperToolStripMenuItem.Name = "StartGoBasedNitroSniperToolStripMenuItem"
        Me.StartGoBasedNitroSniperToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.StartGoBasedNitroSniperToolStripMenuItem.Text = "Start Go based Nitro Sniper"
        Me.StartGoBasedNitroSniperToolStripMenuItem.ToolTipText = "A pre-compiled Nitro Sniper that is based on Go." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Features:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shows you the Nitr" &
    "o Code and from who it came from." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Automatically redeems Nitro Codes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detects f" &
    "ake codes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Joins Giveaways." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'StartRustBasedNitroSniperToolStripMenuItem
        '
        Me.StartRustBasedNitroSniperToolStripMenuItem.AutoToolTip = True
        Me.StartRustBasedNitroSniperToolStripMenuItem.Image = Global.NitroSniperGUI.My.Resources.Resources._10
        Me.StartRustBasedNitroSniperToolStripMenuItem.Name = "StartRustBasedNitroSniperToolStripMenuItem"
        Me.StartRustBasedNitroSniperToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.StartRustBasedNitroSniperToolStripMenuItem.Text = "Start Rust based Nitro Sniper"
        Me.StartRustBasedNitroSniperToolStripMenuItem.ToolTipText = "A Nitro Sniper that is based on Rust." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Features:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shows you the Nitro Code and " &
    "from who it came from." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Automatically redeems Nitro Codes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detects fake codes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Joins Giveaways." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(236, 6)
        '
        'WindowControlsToolStripMenuItem
        '
        Me.WindowControlsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaximizeAllWindowsToolStripMenuItem, Me.MinimizeAllWindowsToolStripMenuItem})
        Me.WindowControlsToolStripMenuItem.Image = CType(resources.GetObject("WindowControlsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WindowControlsToolStripMenuItem.Name = "WindowControlsToolStripMenuItem"
        Me.WindowControlsToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.WindowControlsToolStripMenuItem.Text = "Window Controls"
        '
        'MaximizeAllWindowsToolStripMenuItem
        '
        Me.MaximizeAllWindowsToolStripMenuItem.Image = CType(resources.GetObject("MaximizeAllWindowsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MaximizeAllWindowsToolStripMenuItem.Name = "MaximizeAllWindowsToolStripMenuItem"
        Me.MaximizeAllWindowsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MaximizeAllWindowsToolStripMenuItem.Text = "Maximize all Windows"
        '
        'MinimizeAllWindowsToolStripMenuItem
        '
        Me.MinimizeAllWindowsToolStripMenuItem.Image = CType(resources.GetObject("MinimizeAllWindowsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MinimizeAllWindowsToolStripMenuItem.Name = "MinimizeAllWindowsToolStripMenuItem"
        Me.MinimizeAllWindowsToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MinimizeAllWindowsToolStripMenuItem.Text = "Minimize all Windows"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(236, 6)
        '
        'DefaultProgramSettingsToolStripMenuItem
        '
        Me.DefaultProgramSettingsToolStripMenuItem.Image = CType(resources.GetObject("DefaultProgramSettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DefaultProgramSettingsToolStripMenuItem.Name = "DefaultProgramSettingsToolStripMenuItem"
        Me.DefaultProgramSettingsToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.DefaultProgramSettingsToolStripMenuItem.Text = "GUI  Settings"
        '
        'HelpToolStripDropDownButton
        '
        Me.HelpToolStripDropDownButton.Image = CType(resources.GetObject("HelpToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.HelpToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripDropDownButton.Name = "HelpToolStripDropDownButton"
        Me.HelpToolStripDropDownButton.ShowDropDownArrow = False
        Me.HelpToolStripDropDownButton.Size = New System.Drawing.Size(52, 20)
        Me.HelpToolStripDropDownButton.Text = "Help"
        '
        'LicenseToolStripDropDownButton
        '
        Me.LicenseToolStripDropDownButton.Image = CType(resources.GetObject("LicenseToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.LicenseToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LicenseToolStripDropDownButton.Name = "LicenseToolStripDropDownButton"
        Me.LicenseToolStripDropDownButton.ShowDropDownArrow = False
        Me.LicenseToolStripDropDownButton.Size = New System.Drawing.Size(66, 20)
        Me.LicenseToolStripDropDownButton.Text = "License"
        '
        'MainMdiContainerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MainMdiContainerForm"
        Me.Text = "(MDI)  Nitro Sniper : User Interface"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Status As ToolStripStatusLabel
    Friend WithEvents StatusBar As ToolStripProgressBar
    Public WithEvents Panel1 As Panel
    Friend WithEvents ToolToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ConfigFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RustNitroSniperConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoNitroSniperConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartGoBasedNitroSniperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartRustBasedNitroSniperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents DefaultProgramSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents WindowControlsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaximizeAllWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MinimizeAllWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LicenseToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents StartPythonBasedNitroSniperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PythonNitroSniperConfigToolStripMenuItem As ToolStripMenuItem
End Class
