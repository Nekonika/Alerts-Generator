<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Msg_Box_YesNo
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DontAskAgain_cb = New System.Windows.Forms.CheckBox()
        Me.No_btn = New System.Windows.Forms.Button()
        Me.Yes_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Are you sure that you want to remove all selected rows?"
        '
        'DontAskAgain_cb
        '
        Me.DontAskAgain_cb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DontAskAgain_cb.AutoSize = True
        Me.DontAskAgain_cb.Location = New System.Drawing.Point(12, 39)
        Me.DontAskAgain_cb.Name = "DontAskAgain_cb"
        Me.DontAskAgain_cb.Size = New System.Drawing.Size(120, 17)
        Me.DontAskAgain_cb.TabIndex = 0
        Me.DontAskAgain_cb.TabStop = False
        Me.DontAskAgain_cb.Text = "Don't ask me again."
        Me.DontAskAgain_cb.UseVisualStyleBackColor = True
        '
        'No_btn
        '
        Me.No_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.No_btn.Location = New System.Drawing.Point(272, 33)
        Me.No_btn.Name = "No_btn"
        Me.No_btn.Size = New System.Drawing.Size(75, 23)
        Me.No_btn.TabIndex = 1
        Me.No_btn.Text = "No"
        Me.No_btn.UseVisualStyleBackColor = True
        '
        'Yes_btn
        '
        Me.Yes_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Yes_btn.Location = New System.Drawing.Point(191, 33)
        Me.Yes_btn.Name = "Yes_btn"
        Me.Yes_btn.Size = New System.Drawing.Size(75, 23)
        Me.Yes_btn.TabIndex = 2
        Me.Yes_btn.Text = "Yes"
        Me.Yes_btn.UseVisualStyleBackColor = True
        '
        'Msg_Box_YesNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 67)
        Me.Controls.Add(Me.Yes_btn)
        Me.Controls.Add(Me.No_btn)
        Me.Controls.Add(Me.DontAskAgain_cb)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(377, 106)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(377, 106)
        Me.Name = "Msg_Box_YesNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Attention!"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DontAskAgain_cb As CheckBox
    Friend WithEvents No_btn As Button
    Friend WithEvents Yes_btn As Button
End Class
