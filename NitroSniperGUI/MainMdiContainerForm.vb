﻿Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices, System.Management, AutoUpdaterDotNET
Public Class MainMdiContainerForm
    'Initialize MDI Variables and import Functions
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MINIMIZE As Integer = &HF020
    Private Const SC_MAXIMIZE As Integer = &HF030
    Dim rct As RECT
    Dim p As Process
    Dim p2 As Process
    Dim c1 As Process
    Dim c2 As Process
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

                For Each prog As Process In Process.GetProcesses
                    If prog.ProcessName = "conhost" Then
                        prog.Kill()
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GoNitroSniperTitleBarWorkAround()
        'Kill sniper first
        Try
            If p Is Nothing Then
            Else
                p.Kill()
                KillChildrenProcessesOf(CUInt(p.Id))
            End If
        Catch ex As NullReferenceException
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
            Threading.Thread.Sleep(500)
            StatusBar.Value = 100
            Status.Text = "Loaded. To use additional Tools, open the Tools menu."

            Refresh()
        Catch ex As Exception
            MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
            Status.Text = ex.Message
            StatusBar.Value = 0
        End Try

    End Sub
    Private Sub StartRustNitroSniperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartRustBasedNitroSniperToolStripMenuItem.Click
        'Kill Sniper First
        Try
            If p2 Is Nothing Then
            Else
                p2.Kill()
                KillChildrenProcessesOf(CUInt(p2.Id))
            End If
        Catch ex As NullReferenceException
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
            Threading.Thread.Sleep(500)
            StatusBar.Value = 100
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
                MsgBox("Did you forgot to download the config files?" + Environment.NewLine + "Tip. Create them by first opening the Rust-based Nitro Sniper." + Environment.NewLine + ex.Message, vbExclamation, "Config Files Missing")
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
                StatusBar.Value = 100
                Status.Text = "Loaded. To use additional Tools, open the Tools menu."

                Refresh()
            Catch ex As Exception
                MsgBox("The application quit unexpectedly. Maybe you forgot to change the config files?" + Environment.NewLine + Environment.NewLine + ex.Message)
                Status.Text = ex.Message
                StatusBar.Value = 0
            End Try
        End If
    End Sub
    Private Sub GoNitroSniperConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoNitroSniperConfigToolStripMenuItem.Click
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
                MsgBox("Did you forgot to download the config files?" + Environment.NewLine + Environment.NewLine + ex.Message, vbExclamation, "Config Files Missing")
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
                Threading.Thread.Sleep(500)
                StatusBar.Value = 100
                Status.Text = "Loaded. To use additional Tools, open the Tools menu."

                Refresh()
            Catch ex As Exception
                Dim response As MsgBoxResult = MsgBox("Did you forgot to download the config files?" + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
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
        'Go-based Sniper
        Try
            If p Is Nothing Then
                Status.Text = "Command Minimize aborted. Window does not exist."
            Else
                StatusBar.Value = 50
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                StatusBar.Value = 100
                Status.Text = "Windows Minimized."
            End If

        Catch ex As Exception
            Status.Text = "Command Minimize aborted. Window does not exist."
        End Try

        'Rust based Sniper
        Try
            If p2 Is Nothing Then
                Status.Text = "Command Minimize aborted. Window does not exist."
            Else
                StatusBar.Value = 50
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
                StatusBar.Value = 100
                Status.Text = "Windows Minimized."
            End If
        Catch ex As Exception
            Status.Text = "Command Minimize aborted. Window does not exist."
        End Try
    End Sub
    Private Sub MaximizeAllWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaximizeAllWindowsToolStripMenuItem.Click
        'Go-based Sniper
        Try
            If p Is Nothing Then
                Status.Text = "Command Maximize aborted. Window does not exist."
            Else
                StatusBar.Value = 50
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
                StatusBar.Value = 100
                Status.Text = "Windows Maximized."
            End If

        Catch ex As Exception
            Status.Text = "Command Maximize aborted. Window does not exist."
        End Try

        'Rust based Sniper
        Try
            If p2 Is Nothing Then
                Status.Text = "Command Maximize aborted. Window does not exist."
            Else
                StatusBar.Value = 50
                SendMessage(p2.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
                StatusBar.Value = 100
                Status.Text = "Windows Maximized."
            End If
        Catch ex As Exception
            Status.Text = "Command Maximize aborted. Window does not exist."
        End Try
    End Sub

    Private Sub InceptionMenuItem_Click(sender As Object, e As EventArgs) Handles InceptionMenuItem.Click
        MsgBox("No")
        Status.Text = "No inceptions for you."
    End Sub

    Private Sub DefaultProgramSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultProgramSettingsToolStripMenuItem.Click
        DefaultProgramsSettings.Show()
        DefaultProgramsSettings.StartPosition = FormStartPosition.CenterParent
    End Sub
End Class
