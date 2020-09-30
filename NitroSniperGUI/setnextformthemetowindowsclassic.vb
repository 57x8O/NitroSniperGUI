Public Class setnextformthemetowindowsclassic
    'Sets the next Forms Themes to the Windows Classic theme/Windows 2000 look
    'It accomplishes this by setting the Application theme on the load event and then showing a new form for the theme to take affect
    'Also the Newtonsoft.JSON Version is shown here aswell as a error handler if it doesn´t exist

    Private Sub Setnextformthemetowindowsclassic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAreaEnabled

        'Initialize JSON and get Ver
        'MsgBox(" Version: " + FileVersionInfo.GetVersionInfo(Application.StartupPath + "\Newtonsoft.Json.dll").FileVersion.ToString)


        'Show main Form and close the workaround window
        MainMdiContainerForm.Show()
        Close()
    End Sub
End Class