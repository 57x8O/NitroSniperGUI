Imports Newtonsoft.Json, Newtonsoft.Json.Linq

Public Class Testform

    Public JSONFileNameFromOpenFileDialog As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        'Disable Set JSON File Button
        Button7.Enabled = False

        'Disable Get JSON Object from File Button
        Button2.Enabled = False

        'Disable Set JSON Object from TextBox Button
        Button5.Enabled = False

        'Load JSON into Textbox1
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        ' Test result.
        If result = DialogResult.OK Then

            JSONFileNameFromOpenFileDialog = OpenFileDialog1.FileName
            TextBox1.Text = IO.File.ReadAllText(OpenFileDialog1.FileName)
            TextBox2.Text = IO.File.ReadAllText(OpenFileDialog1.FileName)

            'Enable Set JSON File Button
            Button7.Enabled = True

            'Enable Get JSON Object from File Button
            Button2.Enabled = True

            'Enable Set JSON Object from TextBox Button
            Button5.Enabled = True
        End If

    End Sub

    Private Sub Testform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""

            'Create sample JSON
            IO.File.Create(Application.StartupPath + "\sampleJSON.json").Dispose()

            'Add JSON data
            Dim objWriter As New IO.StreamWriter(Application.StartupPath + "\sampleJSON.json", False)
            objWriter.WriteLine("{""sample"":""sample text here"", ""name"":""Peter"",""sample2"":""sample text here 2 1!111!!!!!11""}")
            objWriter.Close()

            MsgBox(Application.StartupPath + "\sampleJSON.json Created")

            'Show updated JSON in Textboxes
            TextBox1.Text = IO.File.ReadAllText(Application.StartupPath + "\sampleJSON.json")
            TextBox2.Text = IO.File.ReadAllText(Application.StartupPath + "\sampleJSON.json")
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            'Delete sample JSON Button
            IO.File.Delete(Application.StartupPath + "\sampleJSON.json")

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""

            MsgBox(Application.StartupPath + "\sampleJSON.json deleted")
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Get JSON Object from loaded JSON File using Textbox3

        Try
            Dim JSONFile As String = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
            Dim JSONObject As JObject = JObject.Parse(JSONFile)
            MsgBox(JSONObject.SelectToken(TextBox3.Text).ToString)
        Catch ex As Exception
            MsgBox("Error while getting the JSON object. Did you write the object correctly?" + Environment.NewLine + Environment.NewLine + ex.ToString)
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            'Set JSON File Button
            Dim objWriter As New IO.StreamWriter(JSONFileNameFromOpenFileDialog, False)
            objWriter.WriteLine(TextBox2.Text)
            objWriter.Close()

            'Show updated JSON in Textboxes
            TextBox1.Text = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
            TextBox2.Text = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Set JSON Object from Textbox Button

        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim value As JValue = JSONObject.SelectToken(TextBox4.Text)

            'Replace it with the Text of Textbox5
            value.Replace(TextBox5.Text)

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(JSONFileNameFromOpenFileDialog, Formatting.Indented)
            IO.File.WriteAllText(JSONFileNameFromOpenFileDialog, JsonConvert.SerializeObject(JSONObject))

            'Show updated JSON in Textboxes
            TextBox1.Text = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
            TextBox2.Text = IO.File.ReadAllText(JSONFileNameFromOpenFileDialog)
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MainMdiContainerForm.Show()
        Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MsgBox(FileVersionInfo.GetVersionInfo(Application.StartupPath + "\Newtonsoft.Json.dll").ToString)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)
            'MsgBox(JSONObject.SelectToken(TextBox3.Text).ToString)

            If JSONObject.SelectToken("snipe_on_main_token").ToString = True Then
                Button9.BackColor = Color.Green
            Else
                Button9.BackColor = Color.Red
            End If


        Catch ex As Exception
            MsgBox("Error while getting the JSON object. Did you write the object correctly?" + Environment.NewLine + Environment.NewLine + ex.ToString)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim value As JValue = JSONObject.SelectToken("snipe_on_main_token")

            'Replace it with the Text of Textbox5
            value.Replace(True)

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Application.StartupPath + "\rns-config.json", Formatting.Indented)
            IO.File.WriteAllText(Application.StartupPath + "\rns-config.json", JsonConvert.SerializeObject(JSONObject))

            Button9.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim value As JValue = JSONObject.SelectToken("snipe_on_main_token")

            'Replace it with the Text of Textbox5
            value.Replace(False)

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Application.StartupPath + "\rns-config.json", Formatting.Indented)
            IO.File.WriteAllText(Application.StartupPath + "\rns-config.json", JsonConvert.SerializeObject(JSONObject))
            Button9.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)
            'MsgBox(JSONObject.SelectToken(TextBox3.Text).ToString)

            If JSONObject.SelectToken("main_token").ToString = "example" Then
                Button14.BackColor = Color.Green
            Else
                Button14.BackColor = Color.Red
            End If


        Catch ex As Exception
            MsgBox("Error while getting the JSON object. Did you write the object correctly?" + Environment.NewLine + Environment.NewLine + ex.ToString)
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim value As JValue = JSONObject.SelectToken("main_token")

            'Replace it with the Text of Textbox5
            value.Replace("example")

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Application.StartupPath + "\rns-config.json", Formatting.Indented)
            IO.File.WriteAllText(Application.StartupPath + "\rns-config.json", JsonConvert.SerializeObject(JSONObject))

            Button14.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            'Read and Parse JSON
            Dim JSONFile As String = IO.File.ReadAllText(Application.StartupPath + "\rns-config.json")
            Dim JSONObject As JObject = JObject.Parse(JSONFile)

            'Select JSON Property
            Dim value As JValue = JSONObject.SelectToken("main_token")

            'Replace it with the Text of Textbox5
            value.Replace("something else")

            'Save and Serialize the JSON
            Dim output = JsonConvert.SerializeObject(Application.StartupPath + "\rns-config.json", Formatting.Indented)
            IO.File.WriteAllText(Application.StartupPath + "\rns-config.json", JsonConvert.SerializeObject(JSONObject))

            Button14.BackColor = Color.Transparent
        Catch ex As Exception
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine + ex.ToString, vbCritical + vbOKOnly)
        End Try
    End Sub
End Class