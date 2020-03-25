Public Class Msg_Box_YesNo
    Private Sub DontAskAgain_cb_CheckedChanged(sender As CheckBox, e As EventArgs) Handles DontAskAgain_cb.CheckedChanged
        RemoveRowDontAskAgain = sender.Checked
    End Sub

    Sub New(Text As String)
        ' This is Required for the Designer.
        InitializeComponent()

        ' Add Initializing methods down here.
        Label1.Text = Text

        Dim NewWidth As Integer = Label1.Left * 2 + Label1.Width
        Me.SetClientSizeCore(IIf(NewWidth < 377, 377, NewWidth), ClientSize.Height)
        MinimumSize = Size
        MaximumSize = Size
    End Sub

    Private Sub Yes_btn_Click(sender As Object, e As EventArgs) Handles Yes_btn.Click
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub No_btn_Click(sender As Object, e As EventArgs) Handles No_btn.Click
        Me.DialogResult = DialogResult.No
    End Sub
End Class