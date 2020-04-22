<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config_Form))
        Me.AlertsTemplatePath_tb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ALertsTemplatePathBrowse_btn = New System.Windows.Forms.Button()
        Me.AlertsResultPathBrowse_btn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AlertsResultPath_tb = New System.Windows.Forms.TextBox()
        Me.AlertsJsonPathBrowse_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AlertsJsonPath_tb = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataPath_tb = New System.Windows.Forms.TextBox()
        Me.DataPathBrowse_btn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FormattedTitle_tb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FilenameHeading_tb = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AlertTypeHeading_tb = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'AlertsTemplatePath_tb
        '
        Me.AlertsTemplatePath_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertsTemplatePath_tb.Location = New System.Drawing.Point(9, 91)
        Me.AlertsTemplatePath_tb.Name = "AlertsTemplatePath_tb"
        Me.AlertsTemplatePath_tb.ReadOnly = True
        Me.AlertsTemplatePath_tb.Size = New System.Drawing.Size(421, 20)
        Me.AlertsTemplatePath_tb.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Where is the ""Alerts.vb"" script template saved?:"
        '
        'ALertsTemplatePathBrowse_btn
        '
        Me.ALertsTemplatePathBrowse_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ALertsTemplatePathBrowse_btn.Location = New System.Drawing.Point(436, 89)
        Me.ALertsTemplatePathBrowse_btn.Name = "ALertsTemplatePathBrowse_btn"
        Me.ALertsTemplatePathBrowse_btn.Size = New System.Drawing.Size(75, 23)
        Me.ALertsTemplatePathBrowse_btn.TabIndex = 2
        Me.ALertsTemplatePathBrowse_btn.Text = "Browse"
        Me.ALertsTemplatePathBrowse_btn.UseVisualStyleBackColor = True
        '
        'AlertsResultPathBrowse_btn
        '
        Me.AlertsResultPathBrowse_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertsResultPathBrowse_btn.Location = New System.Drawing.Point(436, 138)
        Me.AlertsResultPathBrowse_btn.Name = "AlertsResultPathBrowse_btn"
        Me.AlertsResultPathBrowse_btn.Size = New System.Drawing.Size(75, 23)
        Me.AlertsResultPathBrowse_btn.TabIndex = 5
        Me.AlertsResultPathBrowse_btn.Text = "Browse"
        Me.AlertsResultPathBrowse_btn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Where should the generated ""Alerts.vb"" result be saved?:"
        '
        'AlertsResultPath_tb
        '
        Me.AlertsResultPath_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertsResultPath_tb.Location = New System.Drawing.Point(9, 140)
        Me.AlertsResultPath_tb.Name = "AlertsResultPath_tb"
        Me.AlertsResultPath_tb.ReadOnly = True
        Me.AlertsResultPath_tb.Size = New System.Drawing.Size(421, 20)
        Me.AlertsResultPath_tb.TabIndex = 3
        '
        'AlertsJsonPathBrowse_btn
        '
        Me.AlertsJsonPathBrowse_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertsJsonPathBrowse_btn.Location = New System.Drawing.Point(436, 187)
        Me.AlertsJsonPathBrowse_btn.Name = "AlertsJsonPathBrowse_btn"
        Me.AlertsJsonPathBrowse_btn.Size = New System.Drawing.Size(75, 23)
        Me.AlertsJsonPathBrowse_btn.TabIndex = 8
        Me.AlertsJsonPathBrowse_btn.Text = "Browse"
        Me.AlertsJsonPathBrowse_btn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(235, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Where should the ""alerts.json"" result be saved?:"
        '
        'AlertsJsonPath_tb
        '
        Me.AlertsJsonPath_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertsJsonPath_tb.Location = New System.Drawing.Point(10, 189)
        Me.AlertsJsonPath_tb.Name = "AlertsJsonPath_tb"
        Me.AlertsJsonPath_tb.ReadOnly = True
        Me.AlertsJsonPath_tb.Size = New System.Drawing.Size(420, 20)
        Me.AlertsJsonPath_tb.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DataPath_tb)
        Me.GroupBox1.Controls.Add(Me.DataPathBrowse_btn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.AlertsJsonPathBrowse_btn)
        Me.GroupBox1.Controls.Add(Me.AlertsTemplatePath_tb)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ALertsTemplatePathBrowse_btn)
        Me.GroupBox1.Controls.Add(Me.AlertsJsonPath_tb)
        Me.GroupBox1.Controls.Add(Me.AlertsResultPath_tb)
        Me.GroupBox1.Controls.Add(Me.AlertsResultPathBrowse_btn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 215)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Path Settings"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(290, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Where is the all the Table data (""data.json"") beeing saved?:"
        '
        'DataPath_tb
        '
        Me.DataPath_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPath_tb.Location = New System.Drawing.Point(9, 42)
        Me.DataPath_tb.Name = "DataPath_tb"
        Me.DataPath_tb.ReadOnly = True
        Me.DataPath_tb.Size = New System.Drawing.Size(421, 20)
        Me.DataPath_tb.TabIndex = 9
        '
        'DataPathBrowse_btn
        '
        Me.DataPathBrowse_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataPathBrowse_btn.Location = New System.Drawing.Point(436, 40)
        Me.DataPathBrowse_btn.Name = "DataPathBrowse_btn"
        Me.DataPathBrowse_btn.Size = New System.Drawing.Size(75, 23)
        Me.DataPathBrowse_btn.TabIndex = 11
        Me.DataPathBrowse_btn.Text = "Browse"
        Me.DataPathBrowse_btn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(517, 83)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info Box"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(7, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(504, 53)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.FormattedTitle_tb)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.FilenameHeading_tb)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.AlertTypeHeading_tb)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(535, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(353, 305)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Formatting Settings"
        '
        'FormattedTitle_tb
        '
        Me.FormattedTitle_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FormattedTitle_tb.Location = New System.Drawing.Point(9, 239)
        Me.FormattedTitle_tb.Multiline = True
        Me.FormattedTitle_tb.Name = "FormattedTitle_tb"
        Me.FormattedTitle_tb.Size = New System.Drawing.Size(338, 54)
        Me.FormattedTitle_tb.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Normal / Formatted Title:"
        '
        'FilenameHeading_tb
        '
        Me.FilenameHeading_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilenameHeading_tb.Location = New System.Drawing.Point(9, 157)
        Me.FilenameHeading_tb.Multiline = True
        Me.FilenameHeading_tb.Name = "FilenameHeading_tb"
        Me.FilenameHeading_tb.Size = New System.Drawing.Size(338, 54)
        Me.FilenameHeading_tb.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Filename Heading:"
        '
        'AlertTypeHeading_tb
        '
        Me.AlertTypeHeading_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AlertTypeHeading_tb.Location = New System.Drawing.Point(9, 42)
        Me.AlertTypeHeading_tb.Multiline = True
        Me.AlertTypeHeading_tb.Name = "AlertTypeHeading_tb"
        Me.AlertTypeHeading_tb.Size = New System.Drawing.Size(338, 86)
        Me.AlertTypeHeading_tb.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Alerts Type Heading:"
        '
        'Config_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 329)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Config_Form"
        Me.Text = "Configuration Page"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AlertsTemplatePath_tb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ALertsTemplatePathBrowse_btn As Button
    Friend WithEvents AlertsResultPathBrowse_btn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents AlertsResultPath_tb As TextBox
    Friend WithEvents AlertsJsonPathBrowse_btn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents AlertsJsonPath_tb As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataPath_tb As TextBox
    Friend WithEvents DataPathBrowse_btn As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents FormattedTitle_tb As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents FilenameHeading_tb As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents AlertTypeHeading_tb As TextBox
    Friend WithEvents Label6 As Label
End Class
