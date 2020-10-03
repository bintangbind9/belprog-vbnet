<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pembelian_frm_edit
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
        Me.components = New System.ComponentModel.Container()
        Me.tbNote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btSimpan = New System.Windows.Forms.Button()
        Me.btBatal = New System.Windows.Forms.Button()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTgl = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.DataSet1 = New BelajarProgram.DataSet1()
        Me.MssupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MssupplierTableAdapter = New BelajarProgram.DataSet1TableAdapters.mssupplierTableAdapter()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MssupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbNote
        '
        Me.tbNote.Location = New System.Drawing.Point(78, 91)
        Me.tbNote.Multiline = True
        Me.tbNote.Name = "tbNote"
        Me.tbNote.Size = New System.Drawing.Size(268, 40)
        Me.tbNote.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Note"
        '
        'btSimpan
        '
        Me.btSimpan.Location = New System.Drawing.Point(78, 140)
        Me.btSimpan.Name = "btSimpan"
        Me.btSimpan.Size = New System.Drawing.Size(75, 23)
        Me.btSimpan.TabIndex = 24
        Me.btSimpan.Text = "Simpan"
        Me.btSimpan.UseVisualStyleBackColor = True
        '
        'btBatal
        '
        Me.btBatal.Location = New System.Drawing.Point(159, 140)
        Me.btBatal.Name = "btBatal"
        Me.btBatal.Size = New System.Drawing.Size(75, 23)
        Me.btBatal.TabIndex = 23
        Me.btBatal.Text = "Batal"
        Me.btBatal.UseVisualStyleBackColor = True
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(78, 61)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(268, 21)
        Me.cbSupplier.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Supplier"
        '
        'lblTgl
        '
        Me.lblTgl.AutoSize = True
        Me.lblTgl.Location = New System.Drawing.Point(12, 35)
        Me.lblTgl.Name = "lblTgl"
        Me.lblTgl.Size = New System.Drawing.Size(32, 13)
        Me.lblTgl.TabIndex = 20
        Me.lblTgl.Text = "lblTgl"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(12, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(28, 13)
        Me.lblID.TabIndex = 19
        Me.lblID.Text = "lblID"
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MssupplierBindingSource
        '
        Me.MssupplierBindingSource.DataMember = "mssupplier"
        Me.MssupplierBindingSource.DataSource = Me.DataSet1
        '
        'MssupplierTableAdapter
        '
        Me.MssupplierTableAdapter.ClearBeforeFill = True
        '
        'pembelian_frm_edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 174)
        Me.Controls.Add(Me.tbNote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btSimpan)
        Me.Controls.Add(Me.btBatal)
        Me.Controls.Add(Me.cbSupplier)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTgl)
        Me.Controls.Add(Me.lblID)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(377, 213)
        Me.MinimumSize = New System.Drawing.Size(377, 213)
        Me.Name = "pembelian_frm_edit"
        Me.Text = "Edit Header Pembelian"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MssupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbNote As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btSimpan As Button
    Friend WithEvents btBatal As Button
    Friend WithEvents cbSupplier As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTgl As Label
    Friend WithEvents lblID As Label
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents MssupplierBindingSource As BindingSource
    Friend WithEvents MssupplierTableAdapter As DataSet1TableAdapters.mssupplierTableAdapter
End Class
