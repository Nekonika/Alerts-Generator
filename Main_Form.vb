Imports System.IO

Public Class Main_Form
    'Variables

    'Translations for Issue Texts
    Public IssueTexts As New Dictionary(Of String, String) From {
        {"Underscore_Missing", "If IsFormatted is set to 'true', then the variable name requires to have an underscore in it!"},
        {"IsFormatted_Is_Set_Falsely", "IsFormatted is set to 'false', even tho the variable name has an underscore in it!"},
        {"Type_Missing", "You need to specify a type for this Alert!"},
        {"Filename_Missing", "Please add a Filename here (the file where the alert is used in)!"},
        {"Var_Name_Missing", "You are required to add a Variable name!"},
        {"Default_Translation_Missing", "You are required to add a default Tanslation (in english)!"},
        {"Advanced_Translation_Missing", "You seem to have missed a translation for a custom language."}
    }

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
            Dim Dialog = New Msg_Box($"Are you sure that you want to remove all selected rows ({DataGridView1.SelectedRows.Count})?")
            If Dialog.ShowDialog() <> DialogResult.Yes Then Return
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
            Dim Dialog = New Msg_Box($"Are you sure that you want to remove all rows ({DataGridView1.Rows.Count - 1})?")
            If Dialog.ShowDialog() <> DialogResult.Yes Then Return
        End If

        For i = 0 To DataGridView1.Rows.Count - 2
            DataGridView1.Rows.RemoveAt(i)
        Next
    End Sub

    Private Sub OpenConfig_btn_Click(sender As Object, e As EventArgs) Handles OpenConfig_btn.Click
        'This button opens the config where you can specify how the generated text should look
        '(Allows formatting just like in Alerts themselves)

        Config_Form.Show()
    End Sub

    Private Sub Check_btn_Click(sender As Object, e As EventArgs) Handles Check_btn.Click
        'Checks if every field that should be is filled in and there is nothing missing.
        'Make sure all rows in which the variable contains an "_" are marked as IsFormatted and remind user that the Bot might crash if any given translation with IsFormatted does not contain the right amount of variables.

        Dim CheckDataResult As CheckDataResult = CheckData()

        If CheckDataResult.IsSuccess Then
            Debug.WriteLine("No issues found while checking the table.")
        Else
            Debug.WriteLine("Seems like the was an error checking the data.")
            If MsgBox($"Do you want to see more informations about this?", MsgBoxStyle.YesNo, $"Found {CheckDataResult.Mismatches.Count} issues!") = MsgBoxResult.Yes Then
                For i = 0 To CheckDataResult.Mismatches.Count - 1
                    Dim Issue = CheckDataResult.Mismatches(i)
                    MsgBox(Issue.ToString(), MsgBoxStyle.OkOnly, $"Issue [{i + 1}/{CheckDataResult.Mismatches.Count}]")
                Next
            End If
        End If

        'Show Message, that the Current set is issued and where
    End Sub

    Private Sub Generate_btn_Click(sender As Object, e As EventArgs) Handles Generate_btn.Click
        'Generate the Alerts.vb as well as the alerts.json file.
        '(Maybe also ask which of those files shall be generated)

    End Sub

    Private Sub Load_btn_Click(sender As Object, e As EventArgs) Handles Load_btn.Click
        'Load data into the DataGridView using a JSON (or CSV) file.
        '(Just open some kind of File-Picker Window)

    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        'Save all the data from the DataGridView usin a JSON (or CSV) file.
        '(Maybe open some kind of File-Picker Window here aswell)

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
            Dim Type_Name_Val = If(Row.Cells(0).Value, "")

            'Filename
            Dim File_Name_Val = If(Row.Cells(1).Value, "")

            'Variable Name
            Dim Var_Name_Val = If(Row.Cells(2).Value.ToString.ToUpper(), "")
            Row.Cells(2).Value = Var_Name_Val 'Make sure variable names are upper case only

            'Default Translation
            Dim Def_Tran_Val = If(Row.Cells(3).Value, "")

            'Custom Translation
            Dim Adv_Tran_Val = If(Row.Cells(4).Value, "")

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
                Dim Contains_Underscore As Boolean = Var_Name_Val.ToString().Contains("_")
                If IsFormatted_Val AndAlso Not Contains_Underscore Then
                    Mismatches.Add(New Mismatch(3, i, "Underscore_Missing", Var_Name_Val))
                ElseIf Contains_Underscore AndAlso Not IsFormatted_Val Then
                    Mismatches.Add(New Mismatch(6, i, "IsFormatted_Is_Set_Falsely", Var_Name_Val))
                End If
            End If
        Next

        Return New CheckDataResult(Mismatches.Count = 0, Mismatches)
    End Function


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

        'Fill table with the data from the data.json


    End Sub

End Class

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
            $"Context: '{CellContent}'" & vbNewLine &
            $"Error Text: {Main_Form.IssueTexts(IssueText)}"
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