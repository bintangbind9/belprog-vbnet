<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cust_frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TbAlamatCust = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbNamaCust = New System.Windows.Forms.TextBox()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Alamat"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(12, 13)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(16, 13)
        Me.lblid.TabIndex = 51
        Me.lblid.Text = "Id"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(291, 16)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(400, 222)
        Me.dgv1.TabIndex = 50
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(192, 215)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 49
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(111, 215)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 48
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(192, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(111, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TbAlamatCust
        '
        Me.TbAlamatCust.Location = New System.Drawing.Point(115, 67)
        Me.TbAlamatCust.Multiline = True
        Me.TbAlamatCust.Name = "TbAlamatCust"
        Me.TbAlamatCust.Size = New System.Drawing.Size(152, 88)
        Me.TbAlamatCust.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Nama Customer"
        '
        'TbNamaCust
        '
        Me.TbNamaCust.Location = New System.Drawing.Point(115, 39)
        Me.TbNamaCust.Name = "TbNamaCust"
        Me.TbNamaCust.Size = New System.Drawing.Size(152, 20)
        Me.TbNamaCust.TabIndex = 53
        '
        'cust_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 250)
        Me.Controls.Add(Me.TbNamaCust)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TbAlamatCust)
        Me.Controls.Add(Me.Label1)
        Me.Name = "cust_frm"
        Me.Text = "Tabel Customer"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents lblid As Label
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TbAlamatCust As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TbNamaCust As TextBox
End Class
