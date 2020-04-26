<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_Form
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Type = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VarName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DefaultVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TranslatedValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFormatted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SearchText_tb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchIn_cobo = New System.Windows.Forms.ComboBox()
        Me.SearchGo_btn = New System.Windows.Forms.Button()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Load_btn = New System.Windows.Forms.Button()
        Me.OpenConfig_btn = New System.Windows.Forms.Button()
        Me.Clear_btn = New System.Windows.Forms.Button()
        Me.RemoveRow_btn = New System.Windows.Forms.Button()
        Me.Generate_btn = New System.Windows.Forms.Button()
        Me.Check_btn = New System.Windows.Forms.Button()
        Me.LoadFromAlertsJson_btn = New System.Windows.Forms.Button()
        Me.GetImplementationCode_btn = New System.Windows.Forms.Button()
        Me.ImplementCode_cb = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type, Me.File, Me.VarName, Me.DefaultVal, Me.TranslatedValue, Me.IsFormatted})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 43)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1158, 447)
        Me.DataGridView1.TabIndex = 0
        '
        'Type
        '
        Me.Type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Type.HeaderText = "Type"
        Me.Type.Items.AddRange(New Object() {"Console", "Message"})
        Me.Type.Name = "Type"
        Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'File
        '
        Me.File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.File.HeaderText = "File"
        Me.File.Name = "File"
        Me.File.Width = 48
        '
        'VarName
        '
        Me.VarName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.VarName.FillWeight = 20.0!
        Me.VarName.HeaderText = "Variable Name"
        Me.VarName.Name = "VarName"
        '
        'DefaultVal
        '
        Me.DefaultVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DefaultVal.FillWeight = 40.0!
        Me.DefaultVal.HeaderText = "Default Value"
        Me.DefaultVal.Name = "DefaultVal"
        '
        'TranslatedValue
        '
        Me.TranslatedValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TranslatedValue.FillWeight = 40.0!
        Me.TranslatedValue.HeaderText = "Translated Value"
        Me.TranslatedValue.Name = "TranslatedValue"
        '
        'IsFormatted
        '
        Me.IsFormatted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IsFormatted.FalseValue = "false"
        Me.IsFormatted.HeaderText = "Is Formatted"
        Me.IsFormatted.IndeterminateValue = "false"
        Me.IsFormatted.Name = "IsFormatted"
        Me.IsFormatted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IsFormatted.TrueValue = "true"
        Me.IsFormatted.Width = 90
        '
        'SearchText_tb
        '
        Me.SearchText_tb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchText_tb.Location = New System.Drawing.Point(74, 12)
        Me.SearchText_tb.Name = "SearchText_tb"
        Me.SearchText_tb.Size = New System.Drawing.Size(856, 20)
        Me.SearchText_tb.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search for"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(936, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "in"
        '
        'SearchIn_cobo
        '
        Me.SearchIn_cobo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchIn_cobo.FormattingEnabled = True
        Me.SearchIn_cobo.Location = New System.Drawing.Point(957, 12)
        Me.SearchIn_cobo.Name = "SearchIn_cobo"
        Me.SearchIn_cobo.Size = New System.Drawing.Size(171, 21)
        Me.SearchIn_cobo.TabIndex = 4
        '
        'SearchGo_btn
        '
        Me.SearchGo_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchGo_btn.Location = New System.Drawing.Point(1134, 10)
        Me.SearchGo_btn.Name = "SearchGo_btn"
        Me.SearchGo_btn.Size = New System.Drawing.Size(36, 23)
        Me.SearchGo_btn.TabIndex = 5
        Me.SearchGo_btn.Text = "Go!"
        Me.SearchGo_btn.UseVisualStyleBackColor = True
        '
        'Save_btn
        '
        Me.Save_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_btn.ForeColor = System.Drawing.Color.Green
        Me.Save_btn.Location = New System.Drawing.Point(1095, 496)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(75, 23)
        Me.Save_btn.TabIndex = 6
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Load_btn
        '
        Me.Load_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Load_btn.Location = New System.Drawing.Point(1014, 496)
        Me.Load_btn.Name = "Load_btn"
        Me.Load_btn.Size = New System.Drawing.Size(75, 23)
        Me.Load_btn.TabIndex = 7
        Me.Load_btn.Text = "Load"
        Me.Load_btn.UseVisualStyleBackColor = True
        '
        'OpenConfig_btn
        '
        Me.OpenConfig_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpenConfig_btn.Location = New System.Drawing.Point(202, 496)
        Me.OpenConfig_btn.Name = "OpenConfig_btn"
        Me.OpenConfig_btn.Size = New System.Drawing.Size(101, 23)
        Me.OpenConfig_btn.TabIndex = 8
        Me.OpenConfig_btn.Text = "Open Config"
        Me.OpenConfig_btn.UseVisualStyleBackColor = True
        '
        'Clear_btn
        '
        Me.Clear_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Clear_btn.ForeColor = System.Drawing.Color.DarkRed
        Me.Clear_btn.Location = New System.Drawing.Point(121, 496)
        Me.Clear_btn.Name = "Clear_btn"
        Me.Clear_btn.Size = New System.Drawing.Size(75, 23)
        Me.Clear_btn.TabIndex = 9
        Me.Clear_btn.Text = "Clear"
        Me.Clear_btn.UseVisualStyleBackColor = True
        '
        'RemoveRow_btn
        '
        Me.RemoveRow_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RemoveRow_btn.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.RemoveRow_btn.Location = New System.Drawing.Point(12, 496)
        Me.RemoveRow_btn.Name = "RemoveRow_btn"
        Me.RemoveRow_btn.Size = New System.Drawing.Size(103, 23)
        Me.RemoveRow_btn.TabIndex = 10
        Me.RemoveRow_btn.Text = "Remove Row"
        Me.RemoveRow_btn.UseVisualStyleBackColor = True
        '
        'Generate_btn
        '
        Me.Generate_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Generate_btn.ForeColor = System.Drawing.Color.Green
        Me.Generate_btn.Location = New System.Drawing.Point(426, 496)
        Me.Generate_btn.Name = "Generate_btn"
        Me.Generate_btn.Size = New System.Drawing.Size(101, 23)
        Me.Generate_btn.TabIndex = 11
        Me.Generate_btn.Text = "Generate!"
        Me.Generate_btn.UseVisualStyleBackColor = True
        '
        'Check_btn
        '
        Me.Check_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Check_btn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check_btn.Location = New System.Drawing.Point(350, 496)
        Me.Check_btn.Name = "Check_btn"
        Me.Check_btn.Size = New System.Drawing.Size(70, 23)
        Me.Check_btn.TabIndex = 12
        Me.Check_btn.Text = "Check"
        Me.Check_btn.UseVisualStyleBackColor = True
        '
        'LoadFromAlertsJson_btn
        '
        Me.LoadFromAlertsJson_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadFromAlertsJson_btn.Location = New System.Drawing.Point(872, 496)
        Me.LoadFromAlertsJson_btn.Name = "LoadFromAlertsJson_btn"
        Me.LoadFromAlertsJson_btn.Size = New System.Drawing.Size(136, 23)
        Me.LoadFromAlertsJson_btn.TabIndex = 13
        Me.LoadFromAlertsJson_btn.Text = "Load from alerts.json"
        Me.LoadFromAlertsJson_btn.UseVisualStyleBackColor = True
        '
        'GetImplementationCode_btn
        '
        Me.GetImplementationCode_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GetImplementationCode_btn.Location = New System.Drawing.Point(569, 496)
        Me.GetImplementationCode_btn.Name = "GetImplementationCode_btn"
        Me.GetImplementationCode_btn.Size = New System.Drawing.Size(138, 23)
        Me.GetImplementationCode_btn.TabIndex = 14
        Me.GetImplementationCode_btn.Text = "Get implementation code"
        Me.GetImplementationCode_btn.UseVisualStyleBackColor = True
        '
        'ImplementCode_cb
        '
        Me.ImplementCode_cb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImplementCode_cb.AutoSize = True
        Me.ImplementCode_cb.Location = New System.Drawing.Point(713, 500)
        Me.ImplementCode_cb.Name = "ImplementCode_cb"
        Me.ImplementCode_cb.Size = New System.Drawing.Size(119, 17)
        Me.ImplementCode_cb.TabIndex = 15
        Me.ImplementCode_cb.Text = "Implement Filename"
        Me.ImplementCode_cb.UseVisualStyleBackColor = True
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 531)
        Me.Controls.Add(Me.ImplementCode_cb)
        Me.Controls.Add(Me.GetImplementationCode_btn)
        Me.Controls.Add(Me.LoadFromAlertsJson_btn)
        Me.Controls.Add(Me.Check_btn)
        Me.Controls.Add(Me.Generate_btn)
        Me.Controls.Add(Me.RemoveRow_btn)
        Me.Controls.Add(Me.Clear_btn)
        Me.Controls.Add(Me.OpenConfig_btn)
        Me.Controls.Add(Me.Load_btn)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.SearchGo_btn)
        Me.Controls.Add(Me.SearchIn_cobo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SearchText_tb)
        Me.Controls.Add(Me.DataGridView1)
        Me.MinimumSize = New System.Drawing.Size(1198, 570)
        Me.Name = "Main_Form"
        Me.Text = "Alerts Generator"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SearchText_tb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SearchIn_cobo As ComboBox
    Friend WithEvents SearchGo_btn As Button
    Friend WithEvents Save_btn As Button
    Friend WithEvents Load_btn As Button
    Friend WithEvents OpenConfig_btn As Button
    Friend WithEvents Clear_btn As Button
    Friend WithEvents RemoveRow_btn As Button
    Friend WithEvents Generate_btn As Button
    Friend WithEvents Check_btn As Button
    Friend WithEvents Type As DataGridViewComboBoxColumn
    Friend WithEvents File As DataGridViewTextBoxColumn
    Friend WithEvents VarName As DataGridViewTextBoxColumn
    Friend WithEvents DefaultVal As DataGridViewTextBoxColumn
    Friend WithEvents TranslatedValue As DataGridViewTextBoxColumn
    Friend WithEvents IsFormatted As DataGridViewCheckBoxColumn
    Friend WithEvents LoadFromAlertsJson_btn As Button
    Friend WithEvents GetImplementationCode_btn As Button
    Friend WithEvents ImplementCode_cb As CheckBox
End Class
