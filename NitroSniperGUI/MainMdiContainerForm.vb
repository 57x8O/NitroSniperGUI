Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices, System.Management, AutoUpdaterDotNET, Newtonsoft.Json, Newtonsoft.Json.Linq
Public Class MainMdiContainerForm
    'Initialize MDI Variables
    Public Const WM_SYSCOMMAND As Integer = &H112
    Public Const SC_MINIMIZE As Integer = &HF020
    Public Const SC_MAXIMIZE As Integer = &HF030
    Public rct As RECT

    'Initialize Process Variables
    Private p As Process
    Private p2 As Process
    Private p3 As Process
    Public c1 As Process 'Rust Sniper Config
    Public c2 As Process 'Go Sniper Config
    Public c3 As Process 'Python Sniper Config
    <DllImport("user32.dll")>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function GetWindowRect(ByVal hWnd As HandleRef, ByRef lpRect As RECT) As Boolean
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

        'Set Theme
        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAreaEnabled

        'Set and Show BallonTip
        StatusIcon.BalloonTipIcon = ToolTipIcon.Info
        StatusIcon.BalloonTipTitle = "Newtonsoft.JSON initialized."
        StatusIcon.BalloonTipText = "Version: " + FileVersionInfo.GetVersionInfo(Application.StartupPath + "\Newtonsoft.Json.dll").FileVersion.ToString
        StatusIcon.ShowBalloonTip(7000)

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
    Public Sub KillChildrenProcessesOf(ByVal parentProcessId As UInteger)
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
        'Resize and Maximize Nitro Snipers when the GUI get's resized
        If Not p Is Nothing Then
            Try
                'Go-based Sniper
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Catch ex As Exception
                Status.Text = ex.Message
            End Try
        End If
        If Not p2 Is Nothing Then
            Try
                'Rust based Sniper
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Catch ex As Exception
                Status.Text = ex.Message
            End Try
        End If
        If Not p3 Is Nothing Then
            Try
                'Python based Sniper
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                SendMessage(p3.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Catch ex As Exception
                Status.Text = ex.Message
            End Try
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Get rid of the Icon in the systray
        StatusIcon.Dispose()

        'Try to kill Sniper with Process p
        Try
            If p Is Nothing Then
            Else
                'Kill remaining snipers
                p.Kill()
                KillChildrenProcessesOf(CUInt(p.Id))

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "conhost" Then
                        prog.Kill()
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        'Try to kill Sniper with Process p2
        Try
            If p2 Is Nothing Then
            Else
                'Kill remaining snipers
                p2.Kill()
                KillChildrenProcessesOf(CUInt(p2.Id))

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "conhost" Then
                        prog.Kill()
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        'Try to kill Sniper with Process p3
        Try
            If p3 Is Nothing Then
            Else
                'Kill remaining snipers
                p3.Kill()

                KillChildrenProcessesOf(CUInt(p3.Id))

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "conhost" Then
                        prog.Kill()
                    End If
                Next
            End If


        Catch ex As Exception
        End Try

        'Try to kill the GUI Process
        Try
            KillChildrenProcessesOf(CUInt(Process.GetCurrentProcess.Id))
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
        Try
            p = Process.Start(pinfo)
        Catch ex As Exception
            MsgBox("Cannot start the Sniper. Maybe your Antivirus deleted it?" + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbExclamation + vbOKOnly, MsgBoxStyle), "Nitro Sniper")
        End Try

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
        Try
            p2 = Process.Start(p2info)
        Catch ex As Exception
            MsgBox("Cannot start the Sniper. Maybe your Antivirus deleted it?" + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbExclamation + vbOKOnly, MsgBoxStyle), "Nitro Sniper")
        End Try


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
        HelpForm.ShowDialog()
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
        Try
            p3 = Process.Start(p3info)
        Catch ex As Exception
            MsgBox("Cannot start the Sniper. Maybe your Antivirus deleted it?" + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbExclamation + vbOKOnly, MsgBoxStyle), "Nitro Sniper")
        End Try


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
    Private Sub Status_DoubleClick(sender As Object, e As EventArgs) Handles Status.DoubleClick, Status.Click
        CheckIfVisualStudioIsRunning()
    End Sub
    Private Sub CheckIfVisualStudioIsRunning()
        Dim p() As Process
        p = Process.GetProcessesByName("devenv")
        If p.Count > 0 Then
            StartDebugMode()
        Else
        End If
    End Sub
    Private Sub StartDebugMode()
        MsgBox("Debug mode activated.")
        MsgBox("Showing JSON Test Form", CType(vbInformation + vbOKOnly, MsgBoxStyle), "testfrom")
        Testform.Show()
        Close()
    End Sub
    Private Sub StatusIcon_DoubleClick(sender As Object, e As EventArgs) Handles StatusIcon.DoubleClick
        MsgBox(FileVersionInfo.GetVersionInfo(Application.StartupPath + "\Newtonsoft.Json.dll").ToString, CType(vbInformation + vbOKOnly, MsgBoxStyle), "JSON.Net - Newtonsoft.JSON")
    End Sub
    Private Sub StatusIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles StatusIcon.BalloonTipClicked
        TopMost = True
        TopMost = False
    End Sub
End Class
