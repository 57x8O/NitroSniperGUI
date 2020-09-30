Imports System.Runtime.InteropServices
Public Class HelpForm
    Dim HelpPageCounter As Integer = 0
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    Dim pos As Point = MainMdiContainerForm.Location
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Main Form to 0,0
        MainMdiContainerForm.Location = New Point(0, 0)

        'Hide everything first before showing Help
        MainMdiContainerForm.Panel1.Visible = False
        MainMdiContainerForm.Status.Visible = False
        MainMdiContainerForm.StatusBar.Visible = False
        MainMdiContainerForm.HelpToolStripDropDownButton.Visible = False
        MainMdiContainerForm.ControlBox = False
        MainMdiContainerForm.StatusStrip1.Visible = False
        MainMdiContainerForm.FormBorderStyle = FormBorderStyle.None
        MainMdiContainerForm.CheckForUpdatesBtn.Visible = False
        MainMdiContainerForm.LicenseToolStripDropDownButton.Visible = False

        HelpPageCounter = 0
        PictureBox1.Image = My.Resources.help1
    End Sub
    Private Sub PictureBox1_BackgroundImageChanged(sender As Object, e As EventArgs) Handles PictureBox1.BackgroundImageChanged
        If HelpPageCounter = 0 Then
            MainMdiContainerForm.FormBorderStyle = FormBorderStyle.Sizable
            MainMdiContainerForm.StatusStrip1.Visible = True
            MainMdiContainerForm.ToolToolStripDropDownButton.Visible = True
        ElseIf HelpPageCounter = 1 Then
            MainMdiContainerForm.ToolToolStripDropDownButton.Visible = False
            MainMdiContainerForm.ToolToolStripDropDownButton.HideDropDown()
            MainMdiContainerForm.Status.Visible = True
            MainMdiContainerForm.StatusBar.Visible = True
            MainMdiContainerForm.StatusBar.Style = ProgressBarStyle.Marquee
            MainMdiContainerForm.Status.Text = "Currently showing Help."
            MainMdiContainerForm.StatusBar.Value = 20
        ElseIf HelpPageCounter = 2 Then
            MainMdiContainerForm.CheckForUpdatesBtn.Visible = True
            MainMdiContainerForm.CheckForUpdatesBtn.BackColor = Color.Yellow
        ElseIf HelpPageCounter = 3 Then
            MainMdiContainerForm.CheckForUpdatesBtn.BackColor = Color.White

            MainMdiContainerForm.ToolToolStripDropDownButton.Visible = True
            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.Visible = False
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.Visible = False
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.Visible = False
            MainMdiContainerForm.WindowControlsToolStripMenuItem.Visible = False
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.Visible = False
            MainMdiContainerForm.ToolStripSeparator1.Visible = False
            MainMdiContainerForm.ToolStripSeparator2.Visible = False
            MainMdiContainerForm.ToolStripSeparator3.Visible = False

            MainMdiContainerForm.ExitToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.ControlBox = True

            MainMdiContainerForm.StatusBar.Value = 40
        ElseIf HelpPageCounter = 4 Then
            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.ExitToolStripMenuItem.BackColor = Color.White

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.WindowControlsToolStripMenuItem.Visible = False
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.Visible = False
            MainMdiContainerForm.ToolStripSeparator1.Visible = True
            MainMdiContainerForm.ToolStripSeparator2.Visible = False
            MainMdiContainerForm.ToolStripSeparator3.Visible = False

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow

            MainMdiContainerForm.StatusBar.Value = 55
        ElseIf HelpPageCounter = 5 Then
            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.BackColor = Color.White
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.BackColor = Color.White
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.BackColor = Color.White

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.WindowControlsToolStripMenuItem.Visible = True
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.Visible = False
            MainMdiContainerForm.ToolStripSeparator1.Visible = True
            MainMdiContainerForm.ToolStripSeparator2.Visible = True
            MainMdiContainerForm.ToolStripSeparator3.Visible = False

            MainMdiContainerForm.WindowControlsToolStripMenuItem.PerformClick()
            MainMdiContainerForm.WindowControlsToolStripMenuItem.ShowDropDown()
            MainMdiContainerForm.MinimizeAllWindowsToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.MaximizeAllWindowsToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.WindowControlsToolStripMenuItem.BackColor = Color.Yellow

            MainMdiContainerForm.StatusBar.Value = 75
        ElseIf HelpPageCounter = 6 Then
            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.MinimizeAllWindowsToolStripMenuItem.BackColor = Color.White
            MainMdiContainerForm.MaximizeAllWindowsToolStripMenuItem.BackColor = Color.White
            MainMdiContainerForm.WindowControlsToolStripMenuItem.BackColor = Color.White

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.WindowControlsToolStripMenuItem.Visible = True
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.Visible = True
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.BackColor = Color.Yellow
            MainMdiContainerForm.ToolStripSeparator1.Visible = True
            MainMdiContainerForm.ToolStripSeparator2.Visible = True
            MainMdiContainerForm.ToolStripSeparator3.Visible = False

            MainMdiContainerForm.StatusBar.Value = 90

        ElseIf HelpPageCounter = 7 Then
            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.StartGoBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartPythonBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.StartRustBasedNitroSniperToolStripMenuItem.Visible = True
            MainMdiContainerForm.WindowControlsToolStripMenuItem.Visible = True
            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.Visible = True
            MainMdiContainerForm.ToolStripSeparator1.Visible = True
            MainMdiContainerForm.ToolStripSeparator2.Visible = True
            MainMdiContainerForm.ToolStripSeparator3.Visible = True

            MainMdiContainerForm.WindowControlsToolStripMenuItem.HideDropDown()
            MainMdiContainerForm.StatusBar.Value = 100

            MainMdiContainerForm.ToolToolStripDropDownButton.ShowDropDown()

            MainMdiContainerForm.DefaultProgramSettingsToolStripMenuItem.BackColor = Color.White

            MainMdiContainerForm.ToolToolStripDropDownButton.HideDropDown()
            MainMdiContainerForm.LicenseToolStripDropDownButton.Visible = True
            MainMdiContainerForm.LicenseToolStripDropDownButton.BackColor = Color.Yellow
        ElseIf HelpPageCounter = 8 Then
            MainMdiContainerForm.LicenseToolStripDropDownButton.BackColor = Color.White

            MainMdiContainerForm.HelpToolStripDropDownButton.Visible = True
            MainMdiContainerForm.HelpToolStripDropDownButton.BackColor = Color.Yellow

            MainMdiContainerForm.Panel1.Visible = True
            MainMdiContainerForm.StatusBar.Value = 0
            MainMdiContainerForm.StatusBar.Style = ProgressBarStyle.Continuous
            MainMdiContainerForm.Status.Text = "Done"
            ForwardBtn.Size = New Size(75, 23)
            ForwardBtn.Location = New Point(447, 275)
            ForwardBtn.Text = "Close"
        End If
    End Sub
    Private Sub ForwardBtn_Click(sender As Object, e As EventArgs) Handles ForwardBtn.Click
        If HelpPageCounter = 0 Then
            PictureBox1.BackgroundImage = My.Resources.help2
            PictureBox1.Image = My.Resources.help2
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 1 Then
            PictureBox1.BackgroundImage = My.Resources.help3
            PictureBox1.Image = My.Resources.help3
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 2 Then
            PictureBox1.BackgroundImage = My.Resources.help4
            PictureBox1.Image = My.Resources.help4
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 3 Then
            PictureBox1.BackgroundImage = My.Resources.help5
            PictureBox1.Image = My.Resources.help5
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 4 Then
            PictureBox1.BackgroundImage = My.Resources.help6
            PictureBox1.Image = My.Resources.help6
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 5 Then
            PictureBox1.BackgroundImage = My.Resources.help8
            PictureBox1.Image = My.Resources.help8
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 6 Then
            PictureBox1.BackgroundImage = My.Resources.help9
            PictureBox1.Image = My.Resources.help9
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 7 Then
            PictureBox1.BackgroundImage = My.Resources.help10
            PictureBox1.Image = My.Resources.help10
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 8 Then
            PictureBox1.BackgroundImage = My.Resources.help11_v2
            PictureBox1.Image = My.Resources.help11
            HelpPageCounter += 1
        ElseIf HelpPageCounter = 9 Or HelpPageCounter = 10 Or HelpPageCounter >= 10 Then
            MainMdiContainerForm.HelpToolStripDropDownButton.BackColor = Color.Cyan
            MainMdiContainerForm.Location = New Point(pos)
            ForwardBtn.Size = New Size(27, 23)
            ForwardBtn.Location = New Point(494, 275)
            ForwardBtn.Text = ">"
            Me.Close()
        End If
    End Sub
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown, PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
End Class