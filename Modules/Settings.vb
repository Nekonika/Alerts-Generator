Imports System.IO

Module Settings

    '
    ' Msg_Box (Form)
    '

    'Public Variables
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
        {"Advanced_Translation_Missing", "You seem to have missed a translation for a custom language."}
    }


End Module
