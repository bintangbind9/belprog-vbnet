<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pembelian_frm_tambah
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
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblTgl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataSet1 = New BelajarProgram.DataSet1()
        Me.MssupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MssupplierTableAdapter = New BelajarProgram.DataSet1TableAdapters.mssupplierTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.id_barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jenis_barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama_barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_beli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MssupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(12, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(28, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "lblID"
        '
        'lblTgl
        '
        Me.lblTgl.AutoSize = True
        Me.lblTgl.Location = New System.Drawing.Point(12, 35)
        Me.lblTgl.Name = "lblTgl"
        Me.lblTgl.Size = New System.Drawing.Size(32, 13)
        Me.lblTgl.TabIndex = 1
        Me.lblTgl.Text = "lblTgl"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Supplier"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.MssupplierBindingSource
        Me.ComboBox1.DisplayMember = "namasupplier"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(78, 61)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(187, 21)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.ValueMember = "idsupplier"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_barang, Me.jenis_barang, Me.nama_barang, Me.satuan, Me.harga, Me.qty_beli, Me.note})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 137)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(638, 185)
        Me.DataGridView1.TabIndex = 4
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(578, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Batal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(497, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Simpan"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(271, 59)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Add Detail"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Note"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(78, 91)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(268, 40)
        Me.TextBox1.TabIndex = 9
        '
        'id_barang
        '
        Me.id_barang.HeaderText = "ID Barang"
        Me.id_barang.Name = "id_barang"
        '
        'jenis_barang
        '
        Me.jenis_barang.HeaderText = "Jenis Barang"
        Me.jenis_barang.Name = "jenis_barang"
        '
        'nama_barang
        '
        Me.nama_barang.HeaderText = "Nama Barang"
        Me.nama_barang.Name = "nama_barang"
        '
        'satuan
        '
        Me.satuan.HeaderText = "Satuan"
        Me.satuan.Name = "satuan"
        '
        'harga
        '
        Me.harga.HeaderText = "Harga"
        Me.harga.Name = "harga"
        '
        'qty_beli
        '
        Me.qty_beli.HeaderText = "Qty Beli"
        Me.qty_beli.Name = "qty_beli"
        '
        'note
        '
        Me.note.HeaderText = "Keterangan"
        Me.note.Name = "note"
        '
        'pembelian_frm_tambah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 334)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTgl)
        Me.Controls.Add(Me.lblID)
        Me.Name = "pembelian_frm_tambah"
        Me.Text = "Tambah Transaksi"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MssupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblID As Label
    Friend WithEvents lblTgl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents MssupplierBindingSource As BindingSource
    Friend WithEvents MssupplierTableAdapter As DataSet1TableAdapters.mssupplierTableAdapter
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents id_barang As DataGridViewTextBoxColumn
    Friend WithEvents jenis_barang As DataGridViewTextBoxColumn
    Friend WithEvents nama_barang As DataGridViewTextBoxColumn
    Friend WithEvents satuan As DataGridViewTextBoxColumn
    Friend WithEvents harga As DataGridViewTextBoxColumn
    Friend WithEvents qty_beli As DataGridViewTextBoxColumn
    Friend WithEvents note As DataGridViewTextBoxColumn
End Class
