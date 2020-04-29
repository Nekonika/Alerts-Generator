Imports System.IO

Public Class Config_Form
    Private Sub Config_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub Config_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveData()
    End Sub

    Private Sub DataPathBrowse_btn_Click(sender As Object, e As EventArgs) Handles DataPathBrowse_btn.Click
        Dim MyFileDialog As New OpenFileDialog() With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DereferenceLinks = True,
            .FileName = "data.json",
            .Filter = "JSON-File (*.json)|*.json",
            .InitialDirectory = Path.GetDirectoryName(DataPath_tb.Text),
            .Multiselect = False,
            .ShowReadOnly = False,
            .SupportMultiDottedExtensions = False,
            .Title = "Please select your data.json file path to store this applications data in:"
        }

        If MyFileDialog.ShowDialog() = DialogResult.OK Then
            DataPath_tb.Text = MyFileDialog.FileName.ToString()
            SaveData()
        End If
    End Sub

    Private Sub ALertsTemplatePathBrowse_btn_Click(sender As Object, e As EventArgs) Handles ALertsTemplatePathBrowse_btn.Click
        Dim MyFileDialog As New OpenFileDialog() With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DereferenceLinks = True,
            .FileName = "AlertsTemplate.vb",
            .Filter = "Visual Basic Source-File (*.vb)|*.vb",
            .InitialDirectory = Path.GetDirectoryName(AlertsTemplatePath_tb.Text),
            .Multiselect = False,
            .ShowReadOnly = False,
            .SupportMultiDottedExtensions = False,
            .Title = "Please select your AlertsTemplate.vb file path to load the alert template from:"
        }

        If MyFileDialog.ShowDialog() = DialogResult.OK Then
            AlertsTemplatePath_tb.Text = MyFileDialog.FileName.ToString()
            SaveData()
        End If
    End Sub

    Private Sub AlertsResultPathBrowse_btn_Click(sender As Object, e As EventArgs) Handles AlertsResultPathBrowse_btn.Click
        Dim MyFileDialog As New OpenFileDialog() With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DereferenceLinks = True,
            .FileName = "Alerts.vb",
            .Filter = "Visual Basic Source-File (*.vb)|*.vb",
            .InitialDirectory = Path.GetDirectoryName(AlertsResultPath_tb.Text),
            .Multiselect = False,
            .ShowReadOnly = False,
            .SupportMultiDottedExtensions = False,
            .Title = "Please select where the generated Alerts.vb should be saved in:"
        }

        If MyFileDialog.ShowDialog() = DialogResult.OK Then
            AlertsResultPath_tb.Text = MyFileDialog.FileName.ToString()
            SaveData()
        End If
    End Sub

    Private Sub AlertsJsonPathBrowse_btn_Click(sender As Object, e As EventArgs) Handles AlertsJsonPathBrowse_btn.Click
        Dim MyFileDialog As New OpenFileDialog() With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DereferenceLinks = True,
            .FileName = "alerts.json",
            .Filter = "JSON-File (*.json)|*.json",
            .InitialDirectory = Path.GetDirectoryName(AlertsJsonPath_tb.Text),
            .Multiselect = False,
            .ShowReadOnly = False,
            .SupportMultiDottedExtensions = False,
            .Title = "Please select where your alerts.json file should be saved at:"
        }

        If MyFileDialog.ShowDialog() = DialogResult.OK Then
            AlertsJsonPath_tb.Text = MyFileDialog.FileName.ToString()
            SaveData()
        End If
    End Sub

    Private Sub LoadData()
        'Load Path Settings
        DataPath_tb.Text = My.Settings.DataPath
        AlertsTemplatePath_tb.Text = MyData.PathVariables.AlertsTemplatePath
        AlertsResultPath_tb.Text = MyData.PathVariables.AlertsResultPath
        AlertsJsonPath_tb.Text = MyData.PathVariables.AlertsJsonPath

        'Load Formatting Settings
        AlertTypeHeading_tb.Text = My.Settings.AlertTypeHeading
        FilenameHeading_tb.Text = My.Settings.FilenameHeading
        FormattedTitle_tb.Text = My.Settings.FormattedTitle
    End Sub

    Private Sub SaveData()
        'Save Path Settings
        My.Settings.DataPath = DataPath_tb.Text
        MyData.PathVariables.AlertsTemplatePath = AlertsTemplatePath_tb.Text
        MyData.PathVariables.AlertsResultPath = AlertsResultPath_tb.Text
        MyData.PathVariables.AlertsJsonPath = AlertsJsonPath_tb.Text
        MyData.Save()

        'Save Formatting Settings
        My.Settings.AlertTypeHeading = AlertTypeHeading_tb.Text
        My.Settings.FilenameHeading = FilenameHeading_tb.Text
        My.Settings.FormattedTitle = FormattedTitle_tb.Text
        My.Settings.Save()
    End Sub
End Class