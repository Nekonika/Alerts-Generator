Imports System.ComponentModel
Imports System.IO
Imports Newtonsoft.Json

Public Class Main_Form

    ReadOnly MyData As DataTable = New DataTable

    Private Sub SearchGo_btn_Click(sender As Object, e As EventArgs) Handles SearchGo_btn.Click
        'Start searching with the given criteria
        '(Search for "true" / "false" or text in the given column)

        DataGridView1.ClearSelection()
        FindRowByCriteria(SearchText_tb.Text.ToString(), SearchIn_cobo.Text.ToString())
    End Sub

    Private Sub RemoveRow_btn_Click(sender As Object, e As EventArgs) Handles RemoveRow_btn.Click
        'Ask user if he really wants to remove that row
        'Maybe add a "don't ask again" checkbox which restets when ever the program starts

        If DataGridView1.SelectedRows.Count <= 0 Then Return 'No rows selected, which could be removed

        If Not RemoveRowDontAskAgain Then
            If MsgBox($"Are you sure that you want to remove all selected rows ({DataGridView1.SelectedRows.Count})?", MsgBoxStyle.YesNo) <> DialogResult.Yes Then Return
        End If

        For Each Row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.RemoveAt(Row.Index)
        Next
    End Sub

    Private Sub Clear_btn_Click(sender As Object, e As EventArgs) Handles Clear_btn.Click
        'Remove all leaded entries and clear the entire DataGridView
        '(Required the User to answer a MessageBox in Okay-Cancel Style)

        If DataGridView1.Rows.Count <= 1 Then Return 'No rows, which could be removed

        If Not ClearRowsDontAskAgain Then
            If MsgBox($"Are you sure that you want to remove all rows ({DataGridView1.Rows.Count - 1})?", MsgBoxStyle.YesNo) <> DialogResult.Yes Then Return
        End If

        'Delete all existing rows
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub OpenConfig_btn_Click(sender As Object, e As EventArgs) Handles OpenConfig_btn.Click
        'This button opens the config where you can specify how the generated text should look
        '(Allows formatting just like in Alerts themselves)

        Config_Form.Show()
    End Sub

    Private Sub Check_btn_Click(sender As Object, e As EventArgs) Handles Check_btn.Click
        'Checks if every field that should be is filled in and there is nothing missing.
        'Make sure all rows in which the variable contains an "_" are marked as IsFormatted and remind user that the Bot might crash if any given translation with IsFormatted does not contain the right amount of variables.

        'Apply sorting before checking the data
        DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)

        Dim CheckDataResult As CheckDataResult = CheckData()

        If CheckDataResult.IsSuccess Then
            MsgBox("No issues found after checking tables contents.", MsgBoxStyle.Information)
        Else
            Debug.WriteLine("Seems like the was an error checking the data.")
            If MsgBox($"Do you want to see more informations about this?", MsgBoxStyle.YesNo, $"Found {CheckDataResult.Mismatches.Count} issues!") = MsgBoxResult.Yes Then
                For i = 0 To CheckDataResult.Mismatches.Count - 1
                    Dim Issue = CheckDataResult.Mismatches(i)
                    'Show Message, that the Current set is issued and where
                    MsgBox(Issue.ToString(), MsgBoxStyle.OkOnly, $"Issue [{i + 1}/{CheckDataResult.Mismatches.Count}]")
                Next
            End If
        End If
    End Sub

    Private Sub Generate_btn_Click(sender As Object, e As EventArgs) Handles Generate_btn.Click
        'Generate the Alerts.vb as well as the alerts.json file.
        '(Maybe also ask which of those files shall be generated)

        'Make sure all important files exist
        If Not Directory.Exists(Path.GetDirectoryName(My.Settings.AlertsScriptTemplatePath)) Then Directory.CreateDirectory(Path.GetDirectoryName(My.Settings.AlertsScriptTemplatePath))
        If Not Directory.Exists(Path.GetDirectoryName(My.Settings.AlertsScriptResultPath)) Then Directory.CreateDirectory(Path.GetDirectoryName(My.Settings.AlertsScriptResultPath))
        If Not Directory.Exists(Path.GetDirectoryName(My.Settings.AlertsJsonResultPath)) Then Directory.CreateDirectory(Path.GetDirectoryName(My.Settings.AlertsJsonResultPath))
        If Not IO.File.Exists(My.Settings.AlertsScriptTemplatePath) Then IO.File.WriteAllText(My.Settings.AlertsScriptTemplatePath, "")
        If Not IO.File.Exists(My.Settings.AlertsScriptResultPath) Then IO.File.WriteAllText(My.Settings.AlertsScriptResultPath, "")
        If Not IO.File.Exists(My.Settings.AlertsJsonResultPath) Then IO.File.WriteAllText(My.Settings.AlertsJsonResultPath, "")


        GenerateAlertsVB()
        GenerateAlertsJSON()

        MsgBox("Successfully Generated Files!")

        'TODO: Generate 'alerts.json'-File here!
        'Debug.WriteLine("Successfully generated 'Alerts.vb'-File.")
    End Sub

    Private Sub LoadFromAlertsJson_btn_Click(sender As Object, e As EventArgs) Handles LoadFromAlertsJson_btn.Click
        'Load data from alerts.json file

        Select Case MsgBox($"Do you want to import your 'alerts.vb' as translated?{vbNewLine}(Yes = Translated | No = Default Translation)", MsgBoxStyle.YesNoCancel)
            Case MsgBoxResult.Yes
                If Not TryImportAlertsJSON(AsTranslated:=True) Then MsgBox($"Seems like we could not import your 'alerts.vb' file!", MsgBoxStyle.Critical)

            Case MsgBoxResult.No
                If Not TryImportAlertsJSON(AsTranslated:=False) Then MsgBox($"Seems like we could not import your 'alerts.vb' file!", MsgBoxStyle.Critical)
        End Select
    End Sub

    Private Sub Load_btn_Click(sender As Object, e As EventArgs) Handles Load_btn.Click
        'Load data into the DataGridView using a JSON (or CSV) file.
        '(Just open some kind of File-Picker Window)

        If MsgBox($"Are you sure that you want to do that?{vbNewLine}All unsaved changed will be lost!", MsgBoxStyle.Question) = MsgBoxResult.Ok Then DataGridView1.Rows.Clear() : MyData.Load() : MyData.FillTable()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        'Save all the data from the DataGridView usin a JSON (or CSV) file.
        '(Maybe open some kind of File-Picker Window here aswell)

        MyData.ReadFromDataTable()
        MsgBox("Successfully saved table data.", MsgBoxStyle.Information)
    End Sub


    '
    'Functions
    '

    'Get the Index on the Row with the given header text.
    Function GetColumnIndexFromName(Name As String) As Integer
        For i = 0 To DataGridView1.ColumnCount - 1
            If DataGridView1.Columns(i).HeaderText = Name Then Return i
        Next

        Return -1
    End Function

    'Marks all rows in which the content in the given column (or column header name) contains the given search text
    Sub FindRowByCriteria(SearchText As String, SearchColumn As String)
        Dim SearchColumnIndex As Integer = GetColumnIndexFromName(SearchColumn)

        If SearchColumnIndex <> -1 Then
            FindRowByCriteria(SearchText, SearchColumnIndex)
        End If
    End Sub

    Sub FindRowByCriteria(SearchText As String, SearchColumn As Integer)
        For i = 0 To DataGridView1.Rows.Count - 2 '(-2 because last row is most likely empty)
            Dim Result = DataGridView1.Rows(i).Cells(SearchColumn)
            If Result.ValueType.Name = "Boolean" AndAlso IsNothing(Result.Value) Then Result.Value = "false"
            If (Not IsNothing(Result.Value)) AndAlso Result.Value.ToString().ToLower().Contains(SearchText.ToLower()) Then DataGridView1.Rows(i).Selected = True
        Next
    End Sub

    Function CheckData() As CheckDataResult
        Dim Mismatches As New List(Of Mismatch)

        For i = 0 To DataGridView1.Rows.Count - 2
            Dim Row = DataGridView1.Rows(i)

            '
            ' storing variables 
            '

            'Type
            Dim Type_Name_Val As String = If(Row.Cells(0).Value, "")

            'Filename
            Dim File_Name_Val As String = If(Row.Cells(1).Value, "")

            'Variable Name
            Dim Var_Name_Val As String = If(Row.Cells(2).Value, "")
            Var_Name_Val = Var_Name_Val.ToString().ToUpper() 'Make sure variable names are upper case only
            Row.Cells(2).Value = Var_Name_Val

            'Default Translation
            Dim Def_Tran_Val As String = If(Row.Cells(3).Value, "")

            'Custom Translation
            Dim Adv_Tran_Val As String = If(Row.Cells(4).Value, "")

            'Is Formatted
            Dim IsFormatted = DataGridView1.Rows(i).Cells(5)
            Dim IsFormatted_Val As Boolean = (Not IsNothing(IsFormatted.Value) AndAlso IsFormatted.Value = "true")


            '
            ' checking for issues
            '

            'type is not specified (cell 1)
            If String.IsNullOrWhiteSpace(Type_Name_Val) Then Mismatches.Add(New Mismatch(1, i, "Type_Missing", Type_Name_Val))

            'filename missing (cell 2)
            If String.IsNullOrWhiteSpace(File_Name_Val) Then Mismatches.Add(New Mismatch(2, i, "Filename_Missing", File_Name_Val))

            'default translation missing (cell 4)
            If String.IsNullOrWhiteSpace(Def_Tran_Val) Then Mismatches.Add(New Mismatch(4, i, "Default_Translation_Missing", Def_Tran_Val))

            'custom translation missing (cell 5)
            If String.IsNullOrWhiteSpace(Adv_Tran_Val) Then Mismatches.Add(New Mismatch(5, i, "Advanced_Translation_Missing", Adv_Tran_Val))

            If String.IsNullOrWhiteSpace(Var_Name_Val) Then
                'var name is missing (cell 3)
                Mismatches.Add(New Mismatch(3, i, "Var_Name_Missing", Var_Name_Val))
            Else
                'IsFormatted is true but the is no underscore in the variables name (cell 6)
                Dim Contains_Underscore As Boolean = Var_Name_Val.Contains("_")
                If IsFormatted_Val AndAlso Not Contains_Underscore Then
                    Mismatches.Add(New Mismatch(3, i, "Underscore_Missing", Var_Name_Val))
                ElseIf Contains_Underscore AndAlso Not IsFormatted_Val Then
                    Mismatches.Add(New Mismatch(6, i, "IsFormatted_Is_Set_Falsely", Var_Name_Val))
                Else
                    'Count underscores in Var-Name And compare to count of '{' & '}' in translations to make sure all variables are given
                    Dim RequiredVarCount As Integer = Var_Name_Val.Count(Function(X) X.Equals("_"c))

                    If RequiredVarCount > 0 Then
                        For c = 0 To RequiredVarCount - 1
                            Dim currentVar As String = $"{{{c}}}"
                            If Not Def_Tran_Val.Contains(currentVar) Then Mismatches.Add(New Mismatch(4, i, "Formatting_Not_Match", Def_Tran_Val))
                            If Not Adv_Tran_Val.Contains(currentVar) Then Mismatches.Add(New Mismatch(5, i, "Formatting_Not_Match", Adv_Tran_Val))
                        Next
                    End If
                End If
            End If
        Next

        Return New CheckDataResult(Mismatches.Count = 0, Mismatches)
    End Function

    Function TryImportAlertsJSON(Optional AsTranslated As Boolean = True) As Boolean
        Dim MyFileDialog As New OpenFileDialog() With {
            .CheckFileExists = True,
            .CheckPathExists = True,
            .DereferenceLinks = True,
            .FileName = "alerts.json",
            .Filter = "JSON-File (*.json)|*.json",
            .InitialDirectory = Directory.GetCurrentDirectory(),
            .Multiselect = False,
            .ShowReadOnly = False,
            .SupportMultiDottedExtensions = False,
            .Title = "Please select your old alerts.json file to import:"
        }

        If MyFileDialog.ShowDialog() = DialogResult.OK Then
            Dim MyDict As Dictionary(Of String, String)

            Try
                Dim Json As String = IO.File.ReadAllText(MyFileDialog.FileName.ToString())
                MyDict = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(Json)
            Catch ex As Exception
                Debug.WriteLine("Error while reading Json: " & ex.Message.ToString())
                MsgBox("Seems Like we could Not deserialize that JSON-File." & vbNewLine &
                       "Please make sure to select an actual alerts.json!",
                       MsgBoxStyle.Exclamation)
                Return False
            End Try

            If DataGridView1.Rows.Count > 2 Then
                If MsgBox("Your current table already contains data!" & vbNewLine &
                          "Do you want to override those rows?",
                          MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    DataGridView1.Rows.Clear()
                    MyDict.ToList().ForEach(Sub(x) DataGridView1.Rows.Add(String.Empty, String.Empty, x.Key.ToString(), IIf(AsTranslated, String.Empty, x.Value.ToString()), IIf(AsTranslated, x.Value.ToString(), String.Empty), x.Key.ToString().Contains("_")))
                Else
                    Dim AllTranslationsCount As Integer = MyDict.Count
                    Dim NoTranslFound As New List(Of String)
                    Dim TranslNotInDGV As New List(Of String)

                    For i = 0 To DataGridView1.Rows.Count - 2
                        Dim Row As DataGridViewRow = DataGridView1.Rows(i)

                        Dim VarName As String = If(Row.Cells(2).Value?.ToString(), "")
                        If String.IsNullOrWhiteSpace(VarName) Then Debug.WriteLine($"Seems Like we've got an issue with the variables name in line {i + 1}: '{VarName}'!") : Continue For

                        Dim MyDictEntry As KeyValuePair(Of String, String) = MyDict.FirstOrDefault(Function(X) X.Key.ToUpper() = VarName.ToUpper())
                        If String.IsNullOrEmpty(MyDictEntry.Key) Then NoTranslFound.Add(VarName) : Continue For

                        Row.Cells(IIf(AsTranslated, 4, 3)).Value = MyDictEntry.Value.ToString()
                        MyDict.Remove(MyDictEntry.Key)
                    Next

                    TranslNotInDGV = MyDict.Keys.ToList()
                    MyDict.ToList().ForEach(Sub(X) DataGridView1.Rows.Add(String.Empty, String.Empty, X.Key.ToUpper(), IIf(AsTranslated, String.Empty, X.Value), IIf(AsTranslated, X.Value, String.Empty), X.Key.Contains("_")))

                    Dim Successful_Translations As Integer = AllTranslationsCount - NoTranslFound.Count - TranslNotInDGV.Count

                    If Successful_Translations > 0 Then Debug.WriteLine($"Successfully translated {Successful_Translations} alerts!")
                    If NoTranslFound.Count > 0 Then Debug.WriteLine($"{NoTranslFound.Count} translations could not be found!")
                    If TranslNotInDGV.Count > 0 Then Debug.WriteLine($"{TranslNotInDGV.Count} were added to the table!")
                End If
            Else
                MyDict.ToList().ForEach(Sub(x) DataGridView1.Rows.Add(String.Empty, String.Empty, x.Key.ToString(), IIf(AsTranslated, String.Empty, x.Value.ToString()), IIf(AsTranslated, x.Value.ToString(), String.Empty), x.Key.ToString().Contains("_")))
            End If
        End If

        Return True
    End Function


    '
    ' Subs
    '

    Private Sub GenerateAlertsVB()
        Dim AlertsTemplateContent As String = IO.File.ReadAllText(My.Settings.AlertsScriptTemplatePath)
        Dim GeneratedAlertVBContent As String = String.Empty
        Dim GeneratedAlertVBContentVariables As String = String.Empty

        'Get current data from our object into a seperate variable
        Dim MyDataClone As DataTable = MyData.Clone()

        'Sort by alert-type (console/message)
        Dim ConsoleRows As List(Of RowData) = MyDataClone.Rows.FindAll(Function(x) x.Type = AlertType.Console)
        Dim MessageRows As List(Of RowData) = MyDataClone.Rows.FindAll(Function(x) x.Type = AlertType.Message)

        If ConsoleRows.Count > 0 Then
            GeneratedAlertVBContent += My.Settings.AlertTypeHeading.Replace("[ALERTTYPE]", "Console")
            GeneratedAlertVBContentVariables += My.Settings.AlertTypeHeading.Replace("[ALERTTYPE]", "Console")

            While ConsoleRows.Count > 0
                Dim FirstFileName As String = ConsoleRows.First.Filename.ToString()
                Dim SameFileRows As List(Of RowData) = ConsoleRows.FindAll(Function(x) x.Filename = FirstFileName)

                GeneratedAlertVBContent += My.Settings.FilenameHeading.Replace("[FILENAME]", FirstFileName)
                GeneratedAlertVBContentVariables += My.Settings.FilenameHeading.Replace("[FILENAME]", FirstFileName)

                Dim NormalRows As List(Of RowData) = SameFileRows.FindAll(Function(x) x.IsFormatted = False)
                Dim FormattedRows As List(Of RowData) = SameFileRows.FindAll(Function(x) x.IsFormatted = True)

                GeneratedAlertVBContent += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Normal") & vbNewLine
                GeneratedAlertVBContentVariables += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Normal") & vbNewLine
                For Each Row In NormalRows
                    GeneratedAlertVBContent += $"{vbTab}{vbTab}alert.{Row.VariableName} = ""{Row.DefaultTranslation.Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue").Replace("""", """""").Replace(vbNewLine, "\r\n")}""{vbNewLine}"
                    GeneratedAlertVBContentVariables += $"{vbTab}Public {Row.VariableName} As String{vbNewLine}"
                Next

                GeneratedAlertVBContent += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Formatted") & vbNewLine
                GeneratedAlertVBContentVariables += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Formatted") & vbNewLine
                For Each Row In FormattedRows
                    GeneratedAlertVBContent += $"{vbTab}{vbTab}alert.{Row.VariableName} = ""{Row.DefaultTranslation.Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue").Replace("""", """""").Replace(vbNewLine, "\r\n")}""{vbNewLine}"
                    GeneratedAlertVBContentVariables += $"{vbTab}Public {Row.VariableName} As String{vbNewLine}"
                Next

                ConsoleRows.RemoveAll(Function(x) SameFileRows.Contains(x))
            End While
        End If

        If MessageRows.Count > 0 Then
            GeneratedAlertVBContent += My.Settings.AlertTypeHeading.Replace("[ALERTTYPE]", "Message")
            GeneratedAlertVBContentVariables += My.Settings.AlertTypeHeading.Replace("[ALERTTYPE]", "Message")

            While MessageRows.Count > 0
                Dim FirstFileName As String = MessageRows.First.Filename.ToString()
                Dim SameFileRows As List(Of RowData) = MessageRows.FindAll(Function(x) x.Filename = FirstFileName)

                GeneratedAlertVBContent += My.Settings.FilenameHeading.Replace("[FILENAME]", FirstFileName)
                GeneratedAlertVBContentVariables += My.Settings.FilenameHeading.Replace("[FILENAME]", FirstFileName)

                Dim NormalRows As List(Of RowData) = SameFileRows.FindAll(Function(x) x.IsFormatted = False)
                Dim FormattedRows As List(Of RowData) = SameFileRows.FindAll(Function(x) x.IsFormatted = True)

                GeneratedAlertVBContent += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Normal") & vbNewLine
                GeneratedAlertVBContentVariables += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Normal") & vbNewLine
                For Each Row In NormalRows
                    GeneratedAlertVBContent += $"{vbTab}{vbTab}alert.{Row.VariableName} = ""{Row.DefaultTranslation.Replace("""", """""").Replace(vbNewLine, "\r\n")}""{vbNewLine}"
                    GeneratedAlertVBContentVariables += $"{vbTab}Public {Row.VariableName} As String{vbNewLine}"
                Next

                GeneratedAlertVBContent += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Formatted") & vbNewLine
                GeneratedAlertVBContentVariables += My.Settings.FormattedTitle.Replace("[FORMATTED]", "Formatted") & vbNewLine
                For Each Row In FormattedRows
                    GeneratedAlertVBContent += $"{vbTab}{vbTab}alert.{Row.VariableName} = ""{Row.DefaultTranslation.Replace("""", """""").Replace(vbNewLine, "\r\n")}""{vbNewLine}"
                    GeneratedAlertVBContentVariables += $"{vbTab}Public {Row.VariableName} As String{vbNewLine}"
                Next

                MessageRows.RemoveAll(Function(x) SameFileRows.Contains(x))
            End While
        End If

        IO.File.WriteAllText(My.Settings.AlertsScriptResultPath, AlertsTemplateContent.Replace("[ALERTS_VB]", GeneratedAlertVBContent).Replace("[ALERTS_VARS_VB]", GeneratedAlertVBContentVariables))
    End Sub

    Sub GenerateAlertsJSON()
        Dim JsonObject As New Dictionary(Of String, String)

        'Get current data from our object into a seperate variable
        Dim MyDataClone As DataTable = MyData.Clone()

        For Each Row In MyDataClone.Rows
            JsonObject.Add(Row.VariableName, Row.AdvancedTranslation)
        Next

        'OPTIONAL: Sort data by Key

        IO.File.WriteAllText(My.Settings.AlertsJsonResultPath, JsonConvert.SerializeObject(JsonObject, Formatting.Indented))
    End Sub


    '
    ' Events
    '

    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Load Fields to search
        For i = 0 To DataGridView1.ColumnCount - 1
            SearchIn_cobo.Items.Add(DataGridView1.Columns(i).HeaderText)
        Next

        'CheckPathVariables
        If String.IsNullOrWhiteSpace(My.Settings.MyDataPath) Then My.Settings.MyDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "data.json")
        If String.IsNullOrWhiteSpace(My.Settings.AlertsScriptTemplatePath) Then My.Settings.AlertsScriptTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "AlertsTemplate.vb")
        If String.IsNullOrWhiteSpace(My.Settings.AlertsScriptResultPath) Then My.Settings.AlertsScriptResultPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Alerts.vb")
        If String.IsNullOrWhiteSpace(My.Settings.AlertsJsonResultPath) Then My.Settings.AlertsJsonResultPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "alerts.json")

        'Check Placeholder Variables
        If String.IsNullOrWhiteSpace(My.Settings.AlertTypeHeading) Then My.Settings.AlertTypeHeading = $"{vbNewLine}{vbNewLine}'{vbNewLine}' [ALERTTYPE]{vbNewLine}'{vbNewLine}"
        If String.IsNullOrWhiteSpace(My.Settings.FilenameHeading) Then My.Settings.FilenameHeading = $"{vbNewLine}{vbNewLine}' ## [FILENAME] ##{vbNewLine}"
        If String.IsNullOrWhiteSpace(My.Settings.FormattedTitle) Then My.Settings.FormattedTitle = $"{vbNewLine}'[FORMATTED]"

        MyData.Load() 'Initialize MyData (As DataTable)
        MyData.FillTable() 'Fill table with the data from the data.json
    End Sub

    Private Sub Main_Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Ask the user if he really wants to quit without saving
        Dim Result As MsgBoxResult = MsgBox($"Do you want to save your recent changes?", MsgBoxStyle.YesNoCancel)
        If Result = MsgBoxResult.Yes Then MyData.Save()
        e.Cancel = (Result = MsgBoxResult.Cancel)
    End Sub

    Private Sub GetImplementationCode_btn_Click(sender As Object, e As EventArgs) Handles GetImplementationCode_btn.Click
        Dim SelectedRows = DataGridView1.SelectedRows
        Dim ThisRow As DataGridViewRow
        If SelectedRows.Count >= 1 Then ThisRow = SelectedRows(0) Else MsgBox("Plese make sure to select at least one row!", MsgBoxStyle.Information) : Return

        If ThisRow.Cells(5).Value?.ToString().ToLower() = "true" Then
            Dim Variables As List(Of String) = ThisRow.Cells(2).Value?.ToString().Split("_").ToList()
            Variables.Remove(Variables.First()) 'Ignore actual name of the entire placeholder
            Variables = Variables.ConvertAll(Of String)(Function(X) X.ToLower()) 'Make all variables lowercase only

            If Variables.Count <= 0 Then MsgBox("Make sure to check your table before using this feature!", MsgBoxStyle.Information) : Return
            Dim ResultString As String = $"Alerts.GetFormattedAlert(""{ThisRow.Cells(2).Value?.ToString()}"", {String.Join(", ", Variables)})"
            If ImplementCode_cb.Checked AndAlso ThisRow.Cells(0).Value?.ToString().ToLower() = "console" Then ResultString = $"$""[{ThisRow.Cells(1).Value?.ToString()}] {{{ResultString}}}"""
            Clipboard.SetText(ResultString)
        Else
            Dim ResultString As String = $"Alerts.GetAlert(""{ThisRow.Cells(2).Value?.ToString()}"")"
            If ImplementCode_cb.Checked AndAlso ThisRow.Cells(0).Value?.ToString().ToLower() = "console" Then ResultString = $"$""[{ThisRow.Cells(1).Value?.ToString()}] {{{ResultString}}}"""
            Clipboard.SetText(ResultString)
        End If
    End Sub
End Class


'TODO: Store path variables in DataTable (in Json)

'
' Classes
'

Public Class DataTable
    Property LastChanged As Date
    Property Rows As List(Of RowData)

    Sub New()
        LastChanged = Date.Now
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

        If Not Directory.Exists(My.Settings.MyDataPath) Then Directory.CreateDirectory(Path.GetDirectoryName(My.Settings.MyDataPath))
        File.WriteAllText(My.Settings.MyDataPath, json)
    End Sub

    Sub Load()
        If File.Exists(My.Settings.MyDataPath) Then
            Try
                Dim json = File.ReadAllText(My.Settings.MyDataPath)
                Dim Data As DataTable = JsonConvert.DeserializeObject(Of DataTable)(json)

                'Insert data into the object
                LastChanged = Data.LastChanged
                Main_Form.Text = $"{Application.ProductName} | Last changed: {LastChanged.ToString("dd.MM.yyyy HH:mm:ss")}"
                Rows = Data.Rows

            Catch ex As Exception
                MsgBox($"Unable to read 'data.json' file.{vbNewLine}Try deleting the File. (Remember to make a backup if needed!)", MsgBoxStyle.Critical)
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