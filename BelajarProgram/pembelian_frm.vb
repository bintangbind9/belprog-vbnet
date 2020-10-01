Public Class pembelian_frm
    Private Sub pembelian_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isiGridHead()
        DataGridView1.Columns("ID Transaksi").Visible = False
        DataGridView1.Columns("ID Supplier").Visible = False
        DataGridView1.Columns("ID User").Visible = False
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)
            isiGridDetail()
        End If
    End Sub

    Sub isiGridDetail()
        If DataGridView1.Rows.Count > 0 Then
            'Dim idtr As Integer = DataGridView1.Item("ID Transaksi", DataGridView1.CurrentRow.Index).Value
            Dim idtr As Integer = DataGridView1.CurrentRow.Cells(0).Value
            sqLstr = "SELECT TOP(100) * FROM View_DetailBeli WHERE [ID Transaksi]=" & idtr & ""
            tabel = proses.executequery(sqLstr)
            DataGridView2.DataSource = tabel
        End If
    End Sub

    Sub isiGridHead()
        sqLstr = "SELECT TOP(100) * FROM View_HeadBeli ORDER BY [Tanggal] DESC"
        tabel = proses.executequery(sqLstr)
        DataGridView1.DataSource = tabel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With pembelian_frm_tambah
            .MdiParent = Main_frm
            .Show()
            .BringToFront()
            .Top = 0
            .Left = 0
            Me.Enabled = False
            .lblID.Text = "Tambah"
            .lblTgl.Text = Format(Now, "dd MMM yyyy")
        End With
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        isiGridDetail()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim idTrans As Integer = DataGridView1.CurrentRow.Cells(0).Value
            With pembelian_frm_tambah
                .Show()
                .Focus()
                sqLstr = "SELECT * FROM TrBeliHead WHERE idTransaksi=" & idTrans
                tabel = proses.executequery(sqLstr)
                .lblID.Text = idTrans
                Dim tgl As Date = tabel.Rows(0).Item("Tgl")
                .lblTgl.Text = Format(tgl, "dd MMM yyyy")
                .ComboBox1.SelectedValue = tabel.Rows(0).Item("idSupplier")
                .TextBox1.Text = tabel.Rows(0).Item("Keterangan").ToString
                sqLstr = "SELECT [ID Barang],[Jenis Barang],[Nama Barang],[Satuan],[Harga],[Qty],[Keterangan] FROM View_DetailBeli WHERE [ID Transaksi]=" & idTrans
                tabel = proses.executequery(sqLstr)
                .DataGridView1.Columns.Clear()
                .DataGridView1.DataSource = tabel
                .id_barang.DataPropertyName = "[ID Barang]"
                .jenis_barang.DataPropertyName = "[Jenis Barang]"
                .nama_barang.DataPropertyName = "[Nama Barang]"
                .satuan.DataPropertyName = "Satuan"
                .harga.DataPropertyName = "Harga"
                .qty_beli.DataPropertyName = "Qty"
                .note.DataPropertyName = "Keterangan"
            End With
        Else
            MsgBox("Tidak ada data")
        End If
    End Sub

End Class