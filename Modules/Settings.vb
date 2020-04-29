Imports System.IO
Imports Newtonsoft.Json

Module Settings

    '
    ' Msg_Box (Form)
    '

    'Public Variables
    Public ReadOnly MyData As DataTable = New DataTable
    Public RemoveRowDontAskAgain As Boolean = False
    Public ClearRowsDontAskAgain As Boolean = False


    '
    ' Config_Form (Form)
    '

    'Public Variables

    'Translations for Issue Texts
    Public IssueTexts As New Dictionary(Of String, String) From {
        {"Underscore_Missing", "If IsFormatted is set to 'true', then the variable name requires to have an underscore in it!"},
        {"IsFormatted_Is_Set_Falsely", "IsFormatted is set to 'false', even tho the variable name has an underscore in it!"},
        {"Type_Missing", "You need to specify a type for this Alert!"},
        {"Filename_Missing", "Please add a Filename here (the file where the alert is used in)!"},
        {"Var_Name_Missing", "You are required to add a Variable name!"},
        {"Default_Translation_Missing", "You are required to add a default Tanslation (in english)!"},
        {"Advanced_Translation_Missing", "You seem to have missed a translation for a custom language."},
        {"Formatting_Not_Match", "The amount of variables in the var name an in the translations does not match!"}
    }


End Module


'
' Classes
'

Public Class DataTable
    Property LastChanged As Date
    Property PathVariables As PathVariables
    Property Rows As List(Of RowData)

    Sub New()
        LastChanged = Date.Now
        PathVariables = New PathVariables
        Rows = New List(Of RowData)
    End Sub

    Private Sub AddRow(RowData As RowData)
        Rows.Add(RowData)
    End Sub

    Sub ReadFromDataTable()
        Try
            Rows.Clear()

            For i = 0 To Main_Form.DataGridView1.Rows.Count - 2
                Dim Row As DataGridViewRow = Main_Form.DataGridView1.Rows(i)
                AddRow(New RowData([Enum].Parse(GetType(AlertType), Row.Cells(0).Value), Row.Cells(1).Value, Row.Cells(2).Value, Row.Cells(3).Value, Row.Cells(4).Value, Row.Cells(5).Value = "true"))
            Next

            Save()
        Catch ex As Exception
            MsgBox("Could not load data into 'DataTable'-Object.{vbNewLine}Try using Check button before Saving!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub Save()
        LastChanged = Date.Now
        Main_Form.Text = $"{Application.ProductName} | Last changed: {LastChanged.ToString("dd.MM.yyyy HH:mm:ss")}"
        Dim json As String = JsonConvert.SerializeObject(Me, Formatting.Indented)

        If Not Directory.Exists(Path.GetDirectoryName(My.Settings.DataPath)) Then Directory.CreateDirectory(Path.GetDirectoryName(My.Settings.DataPath))
        File.WriteAllText(My.Settings.DataPath, json)
    End Sub

    Sub Load()
        If File.Exists(My.Settings.DataPath) Then
            Try
                Dim json = File.ReadAllText(My.Settings.DataPath)
                Dim Data As DataTable = JsonConvert.DeserializeObject(Of DataTable)(json)

                'Insert data into the object
                LastChanged = Data.LastChanged
                Main_Form.Text = $"{Application.ProductName} | Last changed: {LastChanged.ToString("dd.MM.yyyy HH:mm:ss")}"
                Rows = Data.Rows

            Catch ex As Exception
                MsgBox($"Unable to read '{Path.GetFileName(My.Settings.DataPath)}' file.{vbNewLine}Try deleting the File. (Remember to make a backup if needed!)", MsgBoxStyle.Critical)
                Application.Exit()
            End Try
        Else
            Save()
        End If
    End Sub

    Sub FillTable()
        Main_Form.DataGridView1.Rows.Clear()

        For Each Row In Rows
            Main_Form.DataGridView1.Rows.Add([Enum].GetName(GetType(AlertType), Row.Type),
                                                Row.Filename,
                                                Row.VariableName,
                                                Row.DefaultTranslation,
                                                Row.AdvancedTranslation,
                                                Row.IsFormatted
            )
        Next
    End Sub

    Function Clone() As DataTable
        Return New DataTable With {
            .LastChanged = LastChanged,
            .Rows = Rows
        }
    End Function

End Class

Public Class PathVariables
    Property AlertsTemplatePath As String
    Property AlertsResultPath As String
    Property AlertsJsonPath As String

    Sub New(AlertsTemplatePath As String, AlertsResultPath As String, AlertsJsonPath As String)
        Me.AlertsTemplatePath = AlertsTemplatePath
        Me.AlertsResultPath = AlertsResultPath
        Me.AlertsJsonPath = AlertsJsonPath
    End Sub

    Sub New()
        Dim BaseDir As String = Path.GetDirectoryName(Reflection.Assembly.GetEntryAssembly.FullName)

        AlertsTemplatePath = Path.Combine(BaseDir, "Data", "AlertsTemplate.vb")
        AlertsResultPath = Path.Combine(BaseDir, "Result", "Alerts.vb")
        AlertsJsonPath = Path.Combine(BaseDir, "Result", "alerts.json")
    End Sub

End Class

Public Class RowData
    Property Type As AlertType
    Property Filename As String
    Property VariableName As String
    Property DefaultTranslation As String
    Property AdvancedTranslation As String
    Property IsFormatted As Boolean

    Sub New(Type As AlertType, Filename As String, VariableName As String, DefaultTranslation As String, AdvancedTranslation As String, IsFormatted As Boolean)
        Me.Type = Type
        Me.Filename = Filename
        Me.VariableName = VariableName
        Me.DefaultTranslation = DefaultTranslation
        Me.AdvancedTranslation = AdvancedTranslation
        Me.IsFormatted = IsFormatted
    End Sub
End Class

Public Enum AlertType
    Console
    Message
End Enum

Public Class Mismatch
    Property Column As Integer
    Property Row As Integer
    Property IssueText As String
    Property CellContent As String

    Sub New(Column As Integer, Row As Integer, IssueText As String, CellContent As String)
        Me.Column = Column
        Me.Row = Row
        Me.IssueText = IssueText
        Me.CellContent = CellContent
    End Sub

    Public Overloads Function ToString()
        Return _
            $"Row {Row} Column {Column} issued!" & vbNewLine &
            $"Context: ""{CellContent}""" & vbNewLine &
            $"Error Text: {IssueTexts(IssueText)}"
    End Function
End Class

Public Class CheckDataResult
    Property IsSuccess As Boolean
    Property Mismatches As List(Of Mismatch)

    Sub New(IsSuccess As Boolean, Mismatches As List(Of Mismatch))
        Me.IsSuccess = IsSuccess
        Me.Mismatches = Mismatches
    End Sub
End Class