Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices, System.Management, AutoUpdaterDotNET
Public Class Form1

    'Initialize MDI Variables and import Functions
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MINIMIZE As Integer = &HF020
    Private Const SC_MAXIMIZE As Integer = &HF030
    Dim rct As RECT
    Dim p As Process
    Dim p2 As Process
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
#Enable Warning BC42359
        Application.DoEvents()

        'Updater
        Dim currentDirectory As New IO.DirectoryInfo(Environment.CurrentDirectory)
        If currentDirectory.Parent Is Nothing Then
            AutoUpdater.InstallationPath = currentDirectory.Parent.FullName
        End If
        AutoUpdater.LetUserSelectRemindLater = True
        AutoUpdater.DownloadPath = Environment.CurrentDirectory
        AutoUpdater.Start("https://github.com/PeterStrick/NitroSniperGUI/raw/master/UpdaterXML.xml")

        Await Task.Delay(1000)
        ' GoNitroSniperTitleBarWorkAround()
    End Function
    Sub killChildrenProcessesOf(ByVal parentProcessId As UInt32)
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
                    killChildrenProcessesOf(CUInt(childProcessId))
                    Dim childProcess As Process
                    childProcess = Process.GetProcessById(childProcessId)
                    childProcess.Kill()
                End If
            Next
        End If
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Not p Is Nothing Then
            SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
            SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            p.Kill()
            killChildrenProcessesOf(CUInt(Process.GetCurrentProcess.Id))
            killChildrenProcessesOf(CUInt(p.Id))
            killChildrenProcessesOf(CUInt(p2.Id))
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GoNitroSniperTitleBarWorkAround()
        Try
            p.Kill()
            killChildrenProcessesOf(CUInt(p.Id))
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

        'Set Application inside Form1's Window
        SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
        GetWindowRect(New HandleRef(p, p.MainWindowHandle), rct)
        StatusBar.Value = 60

        'Set Application inside Form1's Window
        SetParent(p.MainWindowHandle, Panel1.Handle)
        SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        Panel1.Visible = True
        Panel1.Focus()
        StatusBar.Value = 70

        'Wait half a second
        Threading.Thread.Sleep(500)
        StatusBar.Value = 100
        Status.Text = "Loaded. To use additional Tools, open the Tools menu."

        Refresh()
    End Sub
    Private Sub StartRustNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartRustBasedNitroSniperToolStripMenuItem.Click
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

        'Set Application inside Form1's Window
        SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
        GetWindowRect(New HandleRef(p2, p2.MainWindowHandle), rct)
        StatusBar.Value = 60

        'Set Application inside Form1's Window
        SetParent(p2.MainWindowHandle, Panel1.Handle)
        SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        Panel1.Visible = True
        Panel1.Focus()
        StatusBar.Value = 70

        'Wait half a second
        Threading.Thread.Sleep(500)
        StatusBar.Value = 100
        Status.Text = "Loaded. To use additional Tools, open the Tools menu."

        Refresh()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub StartGoBasedNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartGoBasedNitroSniperToolStripMenuItem.Click
        GoNitroSniperTitleBarWorkAround()
    End Sub
    Private Sub RustNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RustNitroSniperConfigToolStripMenuItem.Click
        Process.Start(Application.StartupPath + "\rns-config.json")
    End Sub

    Private Sub GoNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoNitroSniperConfigToolStripMenuItem.Click
        Process.Start(Application.StartupPath + "\token.json")
    End Sub
End Class
