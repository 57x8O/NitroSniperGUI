Imports System.Runtime.InteropServices, Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class DefaultProgramsSettings
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    Public Go_JSON As String = "{ ""token"": ""token here"", ""nitro_max"": 2, ""cooldown"": 24, ""giveaway_sniper"": true }"
    Public Go_JSONFilePath As String = Application.StartupPath + "\settings.json"
    Public Rust_JSON As String = "{ ""main_token"": ""token here"", ""snipe_on_main_token"": true, ""sub_tokens"": [], ""webhook"": """", ""guild_blacklist"": [] }"
    Public Rust_JSONFilePath As String = Application.StartupPath + "\rns-config.json"
    Public Python_JSON As String = "{ ""token"": ""token here"" }"
    Public Python_JSONFilePath As String = Application.StartupPath + "\dist\sniper\token.json"

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Private Sub DefaultProgramsSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Theme
        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAreaEnabled

        'load Go based JSON Settings
        Try
            Dim Go_JSONFile As String = IO.File.ReadAllText(Go_JSONFilePath)
            Dim Go_JSONObject As JObject = JObject.Parse(Go_JSONFile)
            Go_Token.Text = Go_JSONObject.SelectToken("token")
            Go_MaxNitroBeforeCooldown.Text = Go_JSONObject.SelectToken("nitro_max")
            Go_EnableGiveaway.Checked = Go_JSONObject.SelectToken("giveaway_sniper")
            Go_CooldownInHours.Text = Go_JSONObject.SelectToken("cooldown")
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Go_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Go_JSONFilePath, True)
                objWriter.WriteLine(Go_JSON)
                objWriter.Close()

                MsgBox("Config File created. Reopen Settings to change the config.", CType(vbInformation + vbOKOnly, MsgBoxStyle), "Config File")
                Close()
            End If
        End Try

        'load Rust based JSON Settings
        Try

            Dim Rust_JSONFile As String = IO.File.ReadAllText(Rust_JSONFilePath)
            Dim Rust_JSONObject As JObject = JObject.Parse(Rust_JSONFile)
            Rust_EnableSnipe.Checked = Rust_JSONObject.SelectToken("snipe_on_main_token")
            Rust_Token.Text = Rust_JSONObject.SelectToken("main_token")
            Rust_WebHook.Text = Rust_JSONObject.SelectToken("webhook")
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Rust_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Rust_JSONFilePath, True)
                objWriter.WriteLine(Rust_JSON)
                objWriter.Close()

                MsgBox("Config File created. Reopen Settings to change the config.", CType(vbInformation + vbOKOnly, MsgBoxStyle), "Config File")
                Close()
            End If
        End Try

        'load Python based JSON Settings
        Try

            Dim Python_JSONFile As String = IO.File.ReadAllText(Python_JSONFilePath)
            Dim Python_JSONObject As JObject = JObject.Parse(Python_JSONFile)
            Python_Token.Text = Python_JSONObject.SelectToken("token")
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, CType(vbYesNo + vbExclamation, MsgBoxStyle), "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Python_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Python_JSONFilePath, True)
                objWriter.WriteLine(Python_JSON)
                objWriter.Close()

                MsgBox("Config File created. Reopen Settings to change the config.", CType(vbInformation + vbOKOnly, MsgBoxStyle), "Config File")
                Close()
            End If
        End Try

    End Sub
    Private Sub InisdeAppBtn_CheckedChanged(sender As Object, e As EventArgs)
        My.Settings.OpenInsde = True
        My.Settings.OpenOutside = False
        My.Settings.Save()
    End Sub
    Private Sub OutsideAppBtn_CheckedChanged(sender As Object, e As EventArgs)
        My.Settings.OpenInsde = False
        My.Settings.OpenOutside = True
        My.Settings.Save()
    End Sub
    Private Sub CloseSettingsBtn_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button3.Click, Button2.Click
        'Save Rust Settings
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Rust_JSONFilePath)
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim rust_snipe_on_main_token As JValue = JSONObject.SelectToken("snipe_on_main_token")
            Dim rust_main_token As JValue = JSONObject.SelectToken("main_token")
            Dim rust_webhookvar As JValue = JSONObject.SelectToken("webhook")

            'Replace it with the Text of the Text Boxes and etc
            rust_snipe_on_main_token.Replace(Rust_EnableSnipe.Checked)
            rust_main_token.Replace(Rust_Token.Text)
            rust_webhookvar.Replace(Rust_WebHook.Text)

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Rust_JSONFilePath, Formatting.Indented)
            IO.File.WriteAllText(Rust_JSONFilePath, JsonConvert.SerializeObject(JSONObject))

        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try

        'Save Go Settings
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Go_JSONFilePath)
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim go_tokenvar As JValue = JSONObject.SelectToken("token")
            Dim go_nitro_maxvar As JValue = JSONObject.SelectToken("nitro_max")
            Dim go_cooldownvar As JValue = JSONObject.SelectToken("cooldown")
            Dim go_giveawaysnipervar As JValue = JSONObject.SelectToken("giveaway_sniper")

            'Replace it with the Text of the Text Boxes and etc
            go_tokenvar.Replace(Go_Token.Text)
            go_giveawaysnipervar.Replace(Go_EnableGiveaway.Checked)
            go_cooldownvar.Replace(Convert.ToInt32(Go_CooldownInHours.Text))
            go_nitro_maxvar.Replace(Convert.ToInt32(Go_MaxNitroBeforeCooldown.Text))

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Go_JSONFilePath, Formatting.Indented)
            IO.File.WriteAllText(Go_JSONFilePath, JsonConvert.SerializeObject(JSONObject))

        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try

        'Save Python Settings
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Python_JSONFilePath)
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim python_tokenvar As JValue = JSONObject.SelectToken("token")

            'Replace it with the Text of the Text Boxes and etc
            python_tokenvar.Replace(Python_Token.Text)

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Python_JSONFilePath, Formatting.Indented)
            IO.File.WriteAllText(Python_JSONFilePath, JsonConvert.SerializeObject(JSONObject))

        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try

        Close()

    End Sub
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown, PictureBox7.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Rust - c1
        Try
            Dim Filename As String = "C:\Windows\system32\rundll32.exe"
            Dim Arguments As String = "shell32.dll,OpenAs_RunDLL " + Rust_JSONFilePath

            'Set ProcessStartInfo
            Dim c1info As New ProcessStartInfo() With {
                        .FileName = Filename,
                        .Arguments = Arguments,
                       .WindowStyle = ProcessWindowStyle.Normal
                    }
            MainMdiContainerForm.c1 = Process.Start(c1info)
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to create or download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, vbYesNo + vbExclamation, "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Rust_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Rust_JSONFilePath, True)
                objWriter.WriteLine(Rust_JSON)
                objWriter.Close()
                MsgBox("Config File created. Reopen Settings to change the config.", vbInformation + vbOKOnly, "Config File")
            End If
            If response = MsgBoxResult.No Then
            End If
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Go - c2
        Try
            Dim Filename As String = "C:\Windows\system32\rundll32.exe"
            Dim Arguments As String = "shell32.dll,OpenAs_RunDLL " + Go_JSONFilePath

            'Set ProcessStartInfo
            Dim c2info As New ProcessStartInfo() With {
                        .FileName = Filename,
                        .Arguments = Arguments,
                       .WindowStyle = ProcessWindowStyle.Normal
                    }
            MainMdiContainerForm.c2 = Process.Start(c2info)
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to create or download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, vbYesNo + vbExclamation, "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Go_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Go_JSONFilePath, True)
                objWriter.WriteLine(Go_JSON)
                objWriter.Close()
                MsgBox("Config File created. Reopen Settings to change the config.", vbInformation + vbOKOnly, "Config File")
            End If
            If response = MsgBoxResult.No Then
            End If
        End Try
    End Sub

    Public Async Function Wait(ByVal MillisecondsToWait As Integer) As Task
        Await Task.Delay(MillisecondsToWait)
    End Function
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'PYthon - c3
        Try
            Dim Filename As String = "C:\Windows\system32\rundll32.exe"
            Dim Arguments As String = "shell32.dll,OpenAs_RunDLL " + Python_JSONFilePath

            'Set ProcessStartInfo
            Dim c3info As New ProcessStartInfo() With {
                        .FileName = Filename,
                        .Arguments = Arguments,
                       .WindowStyle = ProcessWindowStyle.Normal
                    }
            MainMdiContainerForm.c3 = Process.Start(c3info)
        Catch ex As Exception
            Dim response As MsgBoxResult = MsgBox("Did you forget to create or download the config files?" + Environment.NewLine + Environment.NewLine + "Press Yes to create them now, Press No to close this message." + Environment.NewLine + Environment.NewLine + ex.Message, vbYesNo + vbExclamation, "Config Files Missing")
            If response = Global.Microsoft.VisualBasic.MsgBoxResult.Yes Then

                ' Create or overwrite the file.
                IO.File.Create(Python_JSONFilePath).Dispose()

                ' Add text to the file.
                Dim objWriter As New IO.StreamWriter(Python_JSONFilePath, True)
                objWriter.WriteLine(Python_JSON)
                objWriter.Close()
                MsgBox("Config File created. Reopen Settings to change the config.", vbInformation + vbOKOnly, "Config File")
            End If
            If response = MsgBoxResult.No Then
            End If
        End Try
    End Sub

End Class