Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices, System.Management, AutoUpdaterDotNET
Public Class MainMdiContainerForm
    'Initialize MDI Variables
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MINIMIZE As Integer = &HF020
    Private Const SC_MAXIMIZE As Integer = &HF030
    Dim rct As RECT

    'Initialize Process Variables
    Dim p As Process
    Dim p2 As Process
    Dim p3 As Process
    Dim c1 As Process
    Dim c2 As Process
    Dim c3 As Process
    <DllImport("user32.dll")>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetWindowRect(ByVal hWnd As HandleRef, ByRef lpRect As RECT) As Boolean
    End Function
    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public AppsLeft As Integer
        ' x position of upper-left corner
        Public AppsTop As Integer
        ' y position of upper-left corner
        Public AppsRight As Integer
        ' x position of lower-right corner
        Public AppsBottom As Integer
        ' y position of lower-right corner
    End Structure
#Disable Warning BC42359
    Private Async Function Form1_LoadAsync(sender As Object, e As EventArgs) As Task Handles MyBase.Load
        Application.DoEvents()

        'Initialize Updater
        Dim currentDirectory As New IO.DirectoryInfo(Environment.CurrentDirectory)
        If currentDirectory.Parent Is Nothing Then
            AutoUpdater.InstallationPath = currentDirectory.Parent.FullName
        End If
        AutoUpdater.LetUserSelectRemindLater = True
        AutoUpdater.DownloadPath = Environment.CurrentDirectory

        AutoUpdater.Start("https://github.com/PeterStrick/NitroSniperGUI/raw/master/UpdaterXML.xml")

        Await Task.Delay(1000)
    End Function
#Enable Warning BC42359
    Sub KillChildrenProcessesOf(ByVal parentProcessId As UInteger)
        Dim searcher As New ManagementObjectSearcher(
        "SELECT * " &
        "FROM Win32_Process " &
        "WHERE ParentProcessId=" & parentProcessId)
        Dim Collection As ManagementObjectCollection
        Collection = searcher.Get()
        If (Collection.Count > 0) Then
            For Each item In Collection
                Dim childProcessId As Int32
                childProcessId = Convert.ToInt32(item("ProcessId"))
                If Not (childProcessId = Process.GetCurrentProcess().Id) Then
                    KillChildrenProcessesOf(CUInt(childProcessId))
                    Dim childProcess As Process
                    childProcess = Process.GetProcessById(childProcessId)
                    childProcess.Kill()
                End If
            Next
        End If
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Not p Is Nothing Then
            Try
                'Go-based Sniper
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

                'Rust based Sniper
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

                'Python based Sniper
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Catch ex As Exception
                Status.Text = ex.Message
            End Try

        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If p Is Nothing Then
            Else
                'Kill remaining snipers
                p.Kill()
                KillChildrenProcessesOf(CUInt(Process.GetCurrentProcess.Id))
                KillChildrenProcessesOf(CUInt(p.Id))
                KillChildrenProcessesOf(CUInt(p2.Id))
                KillChildrenProcessesOf(CUInt(p3.Id))

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "conhost" Then
                        prog.Kill()
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Async Sub GoNitroSniperTitleBarWorkAround()
        'Kill sniper first
        Try
            If p Is Nothing Then
            Else
                p.Kill()
                KillChildrenProcessesOf(CUInt(p.Id))
            End If
        Catch ex As Exception
        End Try

        'Set ProcessStartInfo
        Dim pinfo As New ProcessStartInfo() With {
                .FileName = Application.StartupPath + "\go-nitro-sniper.exe",
                .WorkingDirectory = Application.StartupPath + "\", 'Working Dir Important since the App will crash without.
               .WindowStyle = ProcessWindowStyle.Normal
            }
        p = Process.Start(pinfo)
        Threading.Thread.Sleep(2000)
        StatusBar.Value = 55
        Status.Text = "Setting location and position..."

        Try
            'Set Application inside Form1's Window (Stage 1, Window outside application)
            SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
            GetWindowRect(New HandleRef(p, p.MainWindowHandle), rct)
            StatusBar.Value = 60

            'Set Application inside Form1's Window (Stage 2, Window inside application)
            SetParent(p.MainWindowHandle, Panel1.Handle)
            SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Panel1.Visible = True
            Panel1.Focus()
            StatusBar.Value = 70

            'Wait half a second
            'Threading.Thread.Sleep(500)
            Await Task.Delay(500)
            StatusBar.Value = 0
            Status.Text = "Loaded. To use additional Tools, open the Tools menu."

            Refresh()
        Catch ex As Exception
            MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
            Status.Text = ex.Message
            StatusBar.Value = 0
        End Try
    End Sub
    Private Async Sub StartRustNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartRustBasedNitroSniperToolStripMenuItem.Click
        'Kill Sniper First
        Try
            If p2 Is Nothing Then
            Else
                p2.Kill()
                KillChildrenProcessesOf(CUInt(p2.Id))
            End If
        Catch ex As Exception
        End Try

        'Set ProcessStartInfo
        Dim p2info As New ProcessStartInfo() With {
                .FileName = Application.StartupPath + "\rust-nitro-sniper.exe",
                .WorkingDirectory = Application.StartupPath + "\", 'Working Dir Important since the App will crash without.
               .WindowStyle = ProcessWindowStyle.Normal
            }
        p2 = Process.Start(p2info)

        Threading.Thread.Sleep(2000)
        StatusBar.Value = 55
        Status.Text = "Setting location and position..."

        Try
            'Set Application inside Form1's Window (Stage 1, Window outside application)
            SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
            GetWindowRect(New HandleRef(p2, p2.MainWindowHandle), rct)
            StatusBar.Value = 60

            'Set Application inside Form1's Window (Stage 2, Window inside application)
            SetParent(p2.MainWindowHandle, Panel1.Handle)
            SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, 0, 0)
            Panel1.Visible = True
            Panel1.Focus()
            StatusBar.Value = 70

            'Wait half a second
            Await Task.Delay(500)
            StatusBar.Value = 0
            Status.Text = "Loaded. To use additional Tools, open the Tools menu."

            Refresh()
        Catch ex As Exception
            MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
            Status.Text = ex.Message
            StatusBar.Value = 0

        End Try
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub StartGoBasedNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartGoBasedNitroSniperToolStripMenuItem.Click
        GoNitroSniperTitleBarWorkAround()
    End Sub
    Private Sub RustNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RustNitroSniperConfigToolStripMenuItem.Click
        If My.Settings.OpenOutside = True Then
            Try
                If My.Settings.UseSystem = True Then
                    Process.Start(Application.StartupPath + "\rns-config.json")
                ElseIf My.Settings.NotepadSystem32 = True Then
                    Process.Start("C:\Windows\System32\notepad.exe", Application.StartupPath + "\rns-config.json")
                ElseIf My.Settings.NotepadWin = True Then
                    Process.Start("C:\Windows\notepad.exe", Application.StartupPath + "\rns-config.json")
                ElseIf My.Settings.WriteWin = True Then
                    Process.Start("C:\Windows\write.exe", Application.StartupPath + "\rns-config.json")
                End If
            Catch ex As Exception
                MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Tip. Create them by first opening the Rust-based Nitro Sniper." + Environment.NewLine + Environment.NewLine + ex.Message, vbExclamation, "Config Files not created.")
            End Try
        ElseIf My.Settings.OpenInsde = True Then
            'Kill Notepad First
            Try
                If c1 Is Nothing Then
                Else
                    c1.Kill()
                    KillChildrenProcessesOf(CUInt(c1.Id))
                End If
            Catch ex As NullReferenceException
            End Try

            Dim Filename As String = ""
            Dim Arguments As String = ""

            If My.Settings.UseSystem = True Then
                Filename = Application.StartupPath + "\rns-config.json"
                Arguments = ""
            ElseIf My.Settings.NotepadSystem32 = True Then
                Filename = "C:\Windows\System32\notepad.exe"
                Arguments = Application.StartupPath + "\rns-config.json"
            ElseIf My.Settings.NotepadWin = True Then
                Filename = "C:\Windows\notepad.exe"
                Arguments = Application.StartupPath + "\rns-config.json"
            ElseIf My.Settings.WriteWin = True Then
                Filename = "C:\Windows\write.exe"
                Arguments = Application.StartupPath + "\rns-config.json"
            End If

            'Set ProcessStartInfo
            Dim c1info As New ProcessStartInfo() With {
                    .FileName = Filename,
                    .Arguments = Arguments,
                   .WindowStyle = ProcessWindowStyle.Normal
                }
            c1 = Process.Start(c1info)
            Threading.Thread.Sleep(2000)
            StatusBar.Value = 55
            Status.Text = "Setting location and position..."

            Try
                'Set Application inside Form1's Window (Stage 1, Window outside application)
                SendMessage(c1.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                GetWindowRect(New HandleRef(c1, c1.MainWindowHandle), rct)
                StatusBar.Value = 60

                'Set Application inside Form1's Window (Stage 2, Window inside application)
                SetParent(c1.MainWindowHandle, Panel1.Handle)
                SendMessage(c1.MainWindowHandle, WM_SYSCOMMAND, 0, 0)
                Panel1.Visible = True
                Panel1.Focus()
                StatusBar.Value = 70

                'Wait half a second
                Threading.Thread.Sleep(500)
                StatusBar.Value = 0
                Status.Text = "Loaded. To use additional Tools, open the Tools menu."

                Refresh()
            Catch ex As Exception
                MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
                Status.Text = ex.Message
                StatusBar.Value = 0
            End Try
        End If
    End Sub
    Private Async Sub GoNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoNitroSniperConfigToolStripMenuItem.Click
        If My.Settings.OpenOutside = True Then
            Try
                If My.Settings.UseSystem = True Then
                    Process.Start(Application.StartupPath + "\token.json")
                ElseIf My.Settings.NotepadSystem32 = True Then
                    Process.Start("C:\Windows\System32\notepad.exe", Application.StartupPath + "\token.json")
                ElseIf My.Settings.NotepadWin = True Then
                    Process.Start("C:\Windows\notepad.exe", Application.StartupPath + "\token.json")
                ElseIf My.Settings.WriteWin = True Then
                    Process.Start("C:\Windows\write.exe", Application.StartupPath + "\token.json")
                End If
            Catch ex As Exception
                'MsgBox("Did you forgot to download the config files?" + Environment.NewLine + Environment.NewLine + ex.Message, vbExclamation, "Config Files Missing")
                Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
                If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                    ' Create or overwrite the file.
                    IO.File.Create(Application.StartupPath + "\token.json").Dispose()

                    ' Add text to the file.
                    Dim objWriter As New IO.StreamWriter(Application.StartupPath + "\token.json", True)
                    objWriter.WriteLine("{ ""token"": ""token here"" }")
                    objWriter.Close()
                    MsgBox("Config File created. Try to open the config again.", CType(vbInformation + vbOKOnly, MsgBoxStyle), "Config File")

                End If

                If response = MsgBoxResult.No Then
                End If
            End Try
        ElseIf My.Settings.OpenInsde = True Then
            'Kill Notepad First
            Try
                If c2 Is Nothing Then
                Else
                    c2.Kill()
                    KillChildrenProcessesOf(CUInt(c2.Id))
                End If
            Catch ex As NullReferenceException
            End Try

            Dim Filename As String = ""
            Dim Arguments As String = ""

            If My.Settings.UseSystem = True Then
                Filename = Application.StartupPath + "\token.json"
                Arguments = ""
            ElseIf My.Settings.NotepadSystem32 = True Then
                Filename = "C:\Windows\System32\notepad.exe"
                Arguments = Application.StartupPath + "\token.json"
            ElseIf My.Settings.NotepadWin = True Then
                Filename = "C:\Windows\notepad.exe"
                Arguments = Application.StartupPath + "\token.json"
            ElseIf My.Settings.WriteWin = True Then
                Filename = "C:\Windows\write.exe"
                Arguments = Application.StartupPath + "\token.json"
            End If

            'Set ProcessStartInfo
            Dim c2info As New ProcessStartInfo() With {
                    .FileName = Filename,
                    .Arguments = Arguments,
                   .WindowStyle = ProcessWindowStyle.Normal
                }
            c2 = Process.Start(c2info)

            Threading.Thread.Sleep(2000)
            StatusBar.Value = 55
            Status.Text = "Setting location and position..."

            Try
                'Set Application inside Form1's Window (Stage 1, Window outside application)
                SendMessage(c2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                GetWindowRect(New HandleRef(c2, c2.MainWindowHandle), rct)
                StatusBar.Value = 60

                'Set Application inside Form1's Window (Stage 2, Window inside application)
                SetParent(c2.MainWindowHandle, Panel1.Handle)
                SendMessage(c2.MainWindowHandle, WM_SYSCOMMAND, 0, 0)
                Panel1.Visible = True
                Panel1.Focus()
                StatusBar.Value = 70

                'Wait half a second
                Await Task.Delay(500)
                StatusBar.Value = 0
                Status.Text = "Loaded. To use additional Tools, open the Tools menu."

                Refresh()
            Catch ex As Exception
                Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
                If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                    ' Create or overwrite the file.
                    IO.File.Create(Application.StartupPath + "\token.json").Dispose()

                    ' Add text to the file.
                    Dim objWriter As New IO.StreamWriter(Application.StartupPath + "\token.json", True)
                    objWriter.WriteLine("{ ""token"": ""token here"" }")
                    objWriter.Close()
                    MsgBox("Config File created. Try to open the config again.")

                End If

                If response = MsgBoxResult.No Then
                End If
            End Try
        End If
    End Sub
    Private Sub MinimizeAllWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeAllWindowsToolStripMenuItem.Click
        Dim config = "Config Window not minimized. Window does not exist."
        Dim abort = "Command Minimize aborted. Window does not exist."
        Dim success = "Windows minimized."
        Dim action = SC_MINIMIZE

        'Go-based Sniper
        Try
            If p Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If

        Catch ex As Exception
            Status.Text = abort
        End Try

        'Rust based Sniper
        Try
            If p2 Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = abort
        End Try

        'Python based Sniper
        Try
            If p3 Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = abort
        End Try

        'Go-based Sniper Config
        Try
            If c1 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c1.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If

        Catch ex As Exception
            Status.Text = config
        End Try

        'Rust based Sniper Config
        Try
            If c2 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c2.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = config
        End Try

        'Python based Sniper Config
        Try
            If c3 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c3.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = config
        End Try
    End Sub
    Private Sub MaximizeAllWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaximizeAllWindowsToolStripMenuItem.Click
        Dim config = "Config Window not maximized. Window does not exist."
        Dim abort = "Command Maximize aborted. Window does not exist."
        Dim success = "Windows maximized."
        Dim action = SC_MAXIMIZE

        'Go-based Sniper
        Try
            If p Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If

        Catch ex As Exception
            Status.Text = abort
        End Try

        'Rust based Sniper
        Try
            If p2 Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = abort
        End Try

        'Python based Sniper
        Try
            If p3 Is Nothing Then
                Status.Text = abort
            Else
                StatusBar.Value = 50
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 100
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = abort
        End Try

        'Go-based Sniper Config
        Try
            If c1 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c1.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If

        Catch ex As Exception
            Status.Text = config
        End Try

        'Rust based Sniper Config
        Try
            If c2 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c2.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = config
        End Try

        'Python based Sniper Config
        Try
            If c3 Is Nothing Then
                Status.Text = config
            Else
                StatusBar.Value = 50
                SendMessage(c3.MainWindowHandle, WM_SYSCOMMAND, action, 0)
                StatusBar.Value = 0
                Status.Text = success
            End If
        Catch ex As Exception
            Status.Text = config
        End Try
    End Sub
    Private Sub DefaultProgramSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultProgramSettingsToolStripMenuItem.Click
        DefaultProgramsSettings.Show()
        DefaultProgramsSettings.StartPosition = FormStartPosition.CenterParent
    End Sub
    Private Sub HelpToolStripDropDownButton_Click(sender As Object, e As EventArgs) Handles HelpToolStripDropDownButton.Click
        'Hide everything first before showing Help
        Panel1.Visible = False
        Status.Visible = False
        StatusBar.Visible = False
        HelpToolStripDropDownButton.Visible = False
        ControlBox = False
        StatusStrip1.Visible = False
        FormBorderStyle = FormBorderStyle.None
        CheckForUpdatesBtn.Visible = False
        LicenseToolStripDropDownButton.Visible = False

        'Welcome Message
        MsgBox("Welcome to the Nitro Sniper GUI Help! Im here to introduce you to the features and functions, that you can use.", vbInformation, "Help")
        FormBorderStyle = FormBorderStyle.Sizable

        'Menu Strip Help
        StatusStrip1.Visible = True
        ToolToolStripDropDownButton.PerformClick()
        ToolToolStripDropDownButton.ShowDropDown()
        MsgBox("The main feature is the ability to Start, Minimize, Maximize and Change Programs and Config Files.", vbInformation, "Menu Strip Help")

        'Status Text and Status Bar Help
        ToolToolStripDropDownButton.Visible = False
        ToolToolStripDropDownButton.HideDropDown()
        Status.Visible = True
        StatusBar.Visible = True
        StatusBar.Style = ProgressBarStyle.Marquee
        Status.Text = "Currently showing Help."
        MsgBox("You can get a Status of the current operation to know what´s happening. Error Messages will also be shown on the Status.", vbInformation, "Status Text/Bar Help")
        StatusBar.Value = 20

        'Check for updates manually
        CheckForUpdatesBtn.Visible = True
        MsgBox("If you want to check for updates manuually, press the 'Check for Updates' button.", vbInformation, "Manual Update Help")
        ToolToolStripDropDownButton.Visible = True
        ToolToolStripDropDownButton.ShowDropDown()

        'Exit Help
        ExitToolStripMenuItem.BackColor = Color.Yellow
        ControlBox = True
        MsgBox("You can exit the application at any time by either:" + Environment.NewLine + Environment.NewLine + "Pressing Exit in the Tools menu" + Environment.NewLine + Environment.NewLine + "Hitting the Close Button in the upper right corner" + Environment.NewLine + Environment.NewLine + "Or by pressing Alt + F4.", vbInformation, "Exit Help")
        ExitToolStripMenuItem.BackColor = Color.White
        StatusBar.Value = 40

        'Sniper Help
        StartGoBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow
        StartRustBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow
        StartPythonBasedNitroSniperToolStripMenuItem.BackColor = Color.Yellow
        MsgBox("The main feature is to start Nitro Snipers and have them inside the Nitro Sniper GUI.", vbInformation, "Nitro Sniper Help")
        StartGoBasedNitroSniperToolStripMenuItem.BackColor = Color.White
        StartRustBasedNitroSniperToolStripMenuItem.BackColor = Color.White
        StartPythonBasedNitroSniperToolStripMenuItem.BackColor = Color.White
        StatusBar.Value = 55

        'Config Help
        ConfigFilesToolStripMenuItem.PerformClick()
        ConfigFilesToolStripMenuItem.ShowDropDown()
        GoNitroSniperConfigToolStripMenuItem.BackColor = Color.Yellow
        RustNitroSniperConfigToolStripMenuItem.BackColor = Color.Yellow
        ConfigFilesToolStripMenuItem.BackColor = Color.Yellow
        PythonNitroSniperConfigToolStripMenuItem.BackColor = Color.Yellow
        MsgBox("You can also change the config files, to add sub-tokens or change settings.", vbInformation, "Config Help")
        GoNitroSniperConfigToolStripMenuItem.BackColor = Color.White
        RustNitroSniperConfigToolStripMenuItem.BackColor = Color.White
        ConfigFilesToolStripMenuItem.BackColor = Color.White
        PythonNitroSniperConfigToolStripMenuItem.BackColor = Color.White
        StatusBar.Value = 75

        'Window control help
        ConfigFilesToolStripMenuItem.HideDropDown()
        WindowControlsToolStripMenuItem.PerformClick()
        WindowControlsToolStripMenuItem.ShowDropDown()
        MinimizeAllWindowsToolStripMenuItem.BackColor = Color.Yellow
        MaximizeAllWindowsToolStripMenuItem.BackColor = Color.Yellow
        WindowControlsToolStripMenuItem.BackColor = Color.Yellow
        MsgBox("You can minimize the Snipers and Config Windows to save screen space and also maximize them.", vbInformation, "Window Control Help")
        MinimizeAllWindowsToolStripMenuItem.BackColor = Color.White
        MaximizeAllWindowsToolStripMenuItem.BackColor = Color.White
        WindowControlsToolStripMenuItem.BackColor = Color.White
        StatusBar.Value = 90

        'Settings Help
        WindowControlsToolStripMenuItem.HideDropDown()
        DefaultProgramSettingsToolStripMenuItem.BackColor = Color.Yellow
        StatusBar.Value = 100
        MsgBox("To change settings like if the config should be inside or outside the GUI, and what Config Editor to use, press on 'GUI Settings'", vbInformation, "Settings Help")
        DefaultProgramSettingsToolStripMenuItem.BackColor = Color.White

        'License Help
        ToolToolStripDropDownButton.HideDropDown()
        LicenseToolStripDropDownButton.Visible = True
        LicenseToolStripDropDownButton.BackColor = Color.Yellow
        MsgBox("Also NitroSniperGUI is licnese under the GNU GPL 3.0 License, so feel free to read it.", vbInformation, "Legal Stuff")
        LicenseToolStripDropDownButton.BackColor = Color.White

        'Help Done Msg
        HelpToolStripDropDownButton.Visible = True
        HelpToolStripDropDownButton.BackColor = Color.Yellow
        MsgBox("You can always go back and press on Help if you need it in the future again!" + Environment.NewLine + Environment.NewLine + "                                                                                           -Help", vbInformation, "Help")
        HelpToolStripDropDownButton.BackColor = Color.Cyan

        'Change to default
        Panel1.Visible = True
        StatusBar.Value = 0
        StatusBar.Style = ProgressBarStyle.Continuous
        Status.Text = "Done"
    End Sub
    Private Sub LicenseToolStripDropDownButton_Click(sender As Object, e As EventArgs) Handles LicenseToolStripDropDownButton.Click
        LicenseForm.ShowDialog()
    End Sub
    Private Async Sub StartPythonBasedNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartPythonBasedNitroSniperToolStripMenuItem.Click
        'Kill sniper first
        Try
            If p3 Is Nothing Then
            Else
                p3.Kill()
                KillChildrenProcessesOf(CUInt(p3.Id))
            End If
        Catch ex As Exception
        End Try

        'Set ProcessStartInfo
        Dim p3info As New ProcessStartInfo() With {
                .FileName = Application.StartupPath + "\dist\sniper\sniper.exe",
                .WorkingDirectory = Application.StartupPath + "\dist\sniper\", 'Working Dir Important since the App will crash without.
               .WindowStyle = ProcessWindowStyle.Normal
            }
        p3 = Process.Start(p3info)
        Threading.Thread.Sleep(2000)
        StatusBar.Value = 55
        Status.Text = "Setting location and position..."

        Try
            'Set Application inside Form1's Window (Stage 1, Window outside application)
            SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
            GetWindowRect(New HandleRef(p3, p3.MainWindowHandle), rct)
            StatusBar.Value = 60

            'Set Application inside Form1's Window (Stage 2, Window inside application)
            SetParent(p3.MainWindowHandle, Panel1.Handle)
            SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Panel1.Visible = True
            Panel1.Focus()
            StatusBar.Value = 70

            'Wait half a second
            'Threading.Thread.Sleep(500)
            Await Task.Delay(500)
            StatusBar.Value = 0
            Status.Text = "Loaded. To use additional Tools, open the Tools menu."

            Refresh()
        Catch ex As Exception
            MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
            Status.Text = ex.Message
            StatusBar.Value = 0
        End Try
    End Sub
    Private Async Sub PythonNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PythonNitroSniperConfigToolStripMenuItem.Click
        If My.Settings.OpenOutside = True Then
            Try
                If My.Settings.UseSystem = True Then
                    Process.Start(Application.StartupPath + "\dist\sniper\token.json")
                ElseIf My.Settings.NotepadSystem32 = True Then
                    Process.Start("C:\Windows\System32\notepad.exe", Application.StartupPath + "\dist\sniper\token.json")
                ElseIf My.Settings.NotepadWin = True Then
                    Process.Start("C:\Windows\notepad.exe", Application.StartupPath + "\dist\sniper\token.json")
                ElseIf My.Settings.WriteWin = True Then
                    Process.Start("C:\Windows\write.exe", Application.StartupPath + "\dist\sniper\token.json")
                End If
            Catch ex As Exception
                'MsgBox("Did you forgot to download the config files?" + Environment.NewLine + Environment.NewLine + ex.Message, vbExclamation, "Config Files Missing")
                Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
                If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                    ' Create or overwrite the file.
                    IO.File.Create(Application.StartupPath + "\dist\sniper\token.json").Dispose()

                    ' Add text to the file.
                    Dim objWriter As New IO.StreamWriter(Application.StartupPath + "\dist\sniper\token.json", True)
                    objWriter.WriteLine("{ ""token"": ""token here"" }")
                    objWriter.Close()
                    MsgBox("Config File created. Try to open the config again.", CType(vbInformation + vbOKOnly, MsgBoxStyle), "Config File")

                End If

                If response = MsgBoxResult.No Then
                End If
            End Try
        ElseIf My.Settings.OpenInsde = True Then
            'Kill Notepad First
            Try
                If c3 Is Nothing Then
                Else
                    c3.Kill()
                    KillChildrenProcessesOf(CUInt(c3.Id))
                End If
            Catch ex As NullReferenceException
            End Try

            Dim Filename As String = ""
            Dim Arguments As String = ""

            If My.Settings.UseSystem = True Then
                Filename = Application.StartupPath + "\dist\sniper\token.json"
                Arguments = ""
            ElseIf My.Settings.NotepadSystem32 = True Then
                Filename = "C:\Windows\System32\notepad.exe"
                Arguments = Application.StartupPath + "\dist\sniper\token.json"
            ElseIf My.Settings.NotepadWin = True Then
                Filename = "C:\Windows\notepad.exe"
                Arguments = Application.StartupPath + "\dist\sniper\token.json"
            ElseIf My.Settings.WriteWin = True Then
                Filename = "C:\Windows\write.exe"
                Arguments = Application.StartupPath + "\dist\sniper\token.json"
            End If

            'Set ProcessStartInfo
            Dim c3info As New ProcessStartInfo() With {
                    .FileName = Filename,
                    .Arguments = Arguments,
                   .WindowStyle = ProcessWindowStyle.Normal
                }
            c3 = Process.Start(c3info)

            Threading.Thread.Sleep(2000)
            StatusBar.Value = 55
            Status.Text = "Setting location and position..."

            Try
                'Set Application inside Form1's Window (Stage 1, Window outside application)
                SendMessage(c3.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                GetWindowRect(New HandleRef(c3, c3.MainWindowHandle), rct)
                StatusBar.Value = 60

                'Set Application inside Form1's Window (Stage 2, Window inside application)
                SetParent(c3.MainWindowHandle, Panel1.Handle)
                SendMessage(c3.MainWindowHandle, WM_SYSCOMMAND, 0, 0)
                Panel1.Visible = True
                Panel1.Focus()
                StatusBar.Value = 70

                'Wait half a second
                Await Task.Delay(500)
                StatusBar.Value = 0
                Status.Text = "Loaded. To use additional Tools, open the Tools menu."

                Refresh()
            Catch ex As Exception
                Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
                If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                    ' Create or overwrite the file.
                    IO.File.Create(Application.StartupPath + "\dist\sniper\token.json").Dispose()

                    ' Add text to the file.
                    Dim objWriter As New IO.StreamWriter(Application.StartupPath + "\dist\sniper\token.json", True)
                    objWriter.WriteLine("{ ""token"": ""token here"" }")
                    objWriter.Close()
                    MsgBox("Config File created. Try to open the config again.")

                End If

                If response = MsgBoxResult.No Then
                End If
            End Try
        End If
    End Sub

    Private Async Sub CheckForUpdatesBtn_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesBtn.Click
        'Initialize manual Updater
        Dim currentDirectory As New IO.DirectoryInfo(Environment.CurrentDirectory)
        If currentDirectory.Parent Is Nothing Then
            AutoUpdater.InstallationPath = currentDirectory.Parent.FullName
        End If
        AutoUpdater.LetUserSelectRemindLater = True
        AutoUpdater.DownloadPath = Environment.CurrentDirectory

        AutoUpdater.ReportErrors = True  'Show message if already up-to-date and show error messages
        AutoUpdater.Start("https://github.com/PeterStrick/NitroSniperGUI/raw/master/UpdaterXML.xml")

        Await Task.Delay(1000)
    End Sub
End Class
