<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMdiContainerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMdiContainerForm))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoNitroSniperConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RustNitroSniperConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartGoBasedNitroSniperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartRustBasedNitroSniperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MinimizeAllWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaximizeAllWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.InceptionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.DefaultProgramSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status, Me.StatusBar, Me.ToolStripDropDownButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(35, 17)
        Me.Status.Text = "Done"
        '
        'StatusBar
        '
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(152, 16)
        Me.StatusBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ConfigFilesToolStripMenuItem, Me.ToolStripSeparator1, Me.StartGoBasedNitroSniperToolStripMenuItem, Me.StartRustBasedNitroSniperToolStripMenuItem, Me.ToolStripSeparator2, Me.MinimizeAllWindowsToolStripMenuItem, Me.MaximizeAllWindowsToolStripMenuItem, Me.ToolStripSeparator3, Me.InceptionMenuItem, Me.ToolStripSeparator4, Me.DefaultProgramSettingsToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(63, 20)
        Me.ToolStripDropDownButton1.Text = "Tools"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ConfigFilesToolStripMenuItem
        '
        Me.ConfigFilesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoNitroSniperConfigToolStripMenuItem, Me.RustNitroSniperConfigToolStripMenuItem})
        Me.ConfigFilesToolStripMenuItem.Name = "ConfigFilesToolStripMenuItem"
        Me.ConfigFilesToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ConfigFilesToolStripMenuItem.Text = "Config Files"
        '
        'GoNitroSniperConfigToolStripMenuItem
        '
        Me.GoNitroSniperConfigToolStripMenuItem.Name = "GoNitroSniperConfigToolStripMenuItem"
        Me.GoNitroSniperConfigToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.GoNitroSniperConfigToolStripMenuItem.Text = "Go Nitro Sniper Config"
        '
        'RustNitroSniperConfigToolStripMenuItem
        '
        Me.RustNitroSniperConfigToolStripMenuItem.Name = "RustNitroSniperConfigToolStripMenuItem"
        Me.RustNitroSniperConfigToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.RustNitroSniperConfigToolStripMenuItem.Text = "Rust Nitro Sniper Config"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(221, 6)
        '
        'StartGoBasedNitroSniperToolStripMenuItem
        '
        Me.StartGoBasedNitroSniperToolStripMenuItem.Name = "StartGoBasedNitroSniperToolStripMenuItem"
        Me.StartGoBasedNitroSniperToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.StartGoBasedNitroSniperToolStripMenuItem.Text = "Start Go based Nitro Sniper"
        '
        'StartRustBasedNitroSniperToolStripMenuItem
        '
        Me.StartRustBasedNitroSniperToolStripMenuItem.Name = "StartRustBasedNitroSniperToolStripMenuItem"
        Me.StartRustBasedNitroSniperToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.StartRustBasedNitroSniperToolStripMenuItem.Text = "Start Rust based Nitro Sniper"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(221, 6)
        '
        'MinimizeAllWindowsToolStripMenuItem
        '
        Me.MinimizeAllWindowsToolStripMenuItem.Name = "MinimizeAllWindowsToolStripMenuItem"
        Me.MinimizeAllWindowsToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MinimizeAllWindowsToolStripMenuItem.Text = "Minimize all Windows"
        '
        'MaximizeAllWindowsToolStripMenuItem
        '
        Me.MaximizeAllWindowsToolStripMenuItem.Name = "MaximizeAllWindowsToolStripMenuItem"
        Me.MaximizeAllWindowsToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MaximizeAllWindowsToolStripMenuItem.Text = "Maximize all Windows"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(221, 6)
        '
        'InceptionMenuItem
        '
        Me.InceptionMenuItem.Name = "InceptionMenuItem"
        Me.InceptionMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.InceptionMenuItem.Text = "Inception"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(221, 6)
        '
        'DefaultProgramSettingsToolStripMenuItem
        '
        Me.DefaultProgramSettingsToolStripMenuItem.Name = "DefaultProgramSettingsToolStripMenuItem"
        Me.DefaultProgramSettingsToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.DefaultProgramSettingsToolStripMenuItem.Text = "Default Program Settings"
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
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ConfigFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RustNitroSniperConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoNitroSniperConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartGoBasedNitroSniperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartRustBasedNitroSniperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MinimizeAllWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaximizeAllWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents InceptionMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents DefaultProgramSettingsToolStripMenuItem As ToolStripMenuItem
End Class
