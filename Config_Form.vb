Public Class Config_Form
    Private Sub Config_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Path Settings
        DataPath_tb.Text = My.Settings.MyDataPath
        AlertsTemplatePath_tb.Text = My.Settings.AlertsScriptTemplatePath
        AlertsResultPath_tb.Text = My.Settings.AlertsScriptResultPath
        AlertsJsonPath_tb.Text = My.Settings.AlertsJsonResultPath

        'Load Formatting Settings
        AlertTypeHeading_tb.Text = My.Settings.AlertTypeHeading
        FilenameHeading_tb.Text = My.Settings.FilenameHeading
        FormattedTitle_tb.Text = My.Settings.FormattedTitle
    End Sub

    Private Sub Config_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Save Path Settings
        My.Settings.MyDataPath = DataPath_tb.Text
        My.Settings.AlertsScriptTemplatePath = AlertsTemplatePath_tb.Text
        My.Settings.AlertsScriptResultPath = AlertsResultPath_tb.Text
        My.Settings.AlertsJsonResultPath = AlertsJsonPath_tb.Text

        'Save Formatting Settings
        My.Settings.AlertTypeHeading = AlertTypeHeading_tb.Text
        My.Settings.FilenameHeading = FilenameHeading_tb.Text
        My.Settings.FormattedTitle = FormattedTitle_tb.Text
    End Sub
End Class