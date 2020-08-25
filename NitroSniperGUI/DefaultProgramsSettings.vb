Public Class DefaultProgramsSettings
    Dim msg As String = "Restart to apply changes."
    Private Sub DefaultProgramsSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAreaEnabled

        If IO.File.Exists("C:\Windows\notepad.exe") Then
            NotepadWinBtn.Enabled = True
            PictureBox3.Visible = True
        ElseIf IO.File.Exists("C:\Windows\System32\notepad.exe") Then
            NotepadSystem32Btn.Enabled = True
            PictureBox2.Visible = True
        ElseIf IO.File.Exists("C:\Windows\write.exe") Then
            Writebtn.Enabled = True
            PictureBox4.Visible = True
        End If

        'Checkboxes
        SystemDefinedBtn.Checked = My.Settings.UseSystem
        NotepadSystem32Btn.Checked = My.Settings.NotepadSystem32
        NotepadWinBtn.Checked = My.Settings.NotepadWin
        Writebtn.Checked = My.Settings.WriteWin
        InsideAppBtn.Checked = My.Settings.OpenInsde
        OutsideAppBtn.Checked = My.Settings.OpenOutside

    End Sub

    Private Sub SystemDefinedBtn_CheckedChanged(sender As Object, e As EventArgs) Handles SystemDefinedBtn.CheckedChanged
        My.Settings.UseSystem = True
        My.Settings.NotepadSystem32 = False
        My.Settings.NotepadWin = False
        My.Settings.WriteWin = False
        My.Settings.Save()
    End Sub

    Private Sub NotepadSystem32Btn_CheckedChanged(sender As Object, e As EventArgs) Handles NotepadSystem32Btn.CheckedChanged
        My.Settings.UseSystem = False
        My.Settings.NotepadSystem32 = True
        My.Settings.NotepadWin = False
        My.Settings.WriteWin = False
        My.Settings.Save()
    End Sub

    Private Sub NotepadWinBtn_CheckedChanged(sender As Object, e As EventArgs) Handles NotepadWinBtn.CheckedChanged
        My.Settings.UseSystem = False
        My.Settings.NotepadSystem32 = False
        My.Settings.NotepadWin = True
        My.Settings.WriteWin = False
        My.Settings.Save()
    End Sub

    Private Sub Writebtn_CheckedChanged(sender As Object, e As EventArgs) Handles Writebtn.CheckedChanged
        My.Settings.UseSystem = False
        My.Settings.NotepadSystem32 = False
        My.Settings.NotepadWin = False
        My.Settings.WriteWin = True
        My.Settings.Save()
    End Sub

    Private Sub InisdeAppBtn_CheckedChanged(sender As Object, e As EventArgs) Handles InsideAppBtn.CheckedChanged
        My.Settings.OpenInsde = True
        My.Settings.OpenOutside = False
        My.Settings.Save()
    End Sub

    Private Sub OutsideAppBtn_CheckedChanged(sender As Object, e As EventArgs) Handles OutsideAppBtn.CheckedChanged
        My.Settings.OpenInsde = False
        My.Settings.OpenOutside = True
        My.Settings.Save()
    End Sub
End Class