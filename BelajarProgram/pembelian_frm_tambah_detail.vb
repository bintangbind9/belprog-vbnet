Public Class pembelian_frm_tambah_detail
    Private Sub pembelian_frm_tambah_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.msbrg' table. You can move, or remove it, as needed.
        Me.MsbrgTableAdapter.Fill(Me.DataSet1.msbrg)
        isiDetail()
    End Sub

    Sub isiDetail()
        sqLstr = "SELECT * FROM View_Brg WHERE ID = " & ComboBox1.SelectedValue & ""
        tabel = proses.executequery(sqLstr)
        With tabel
            If .Rows.Count > 0 Then
                lblSatuan.Text = .Rows(0).Item("Satuan").ToString
                lblJenisBrg.Text = .Rows(0).Item("Jenis Barang").ToString
                lblHargaBrg.Text = .Rows(0).Item("Harga").ToString
            End If
        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not ComboBox1.SelectedValue = Nothing Then
            isiDetail()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(TextBox1.Text) > 0 Then
            With pembelian_frm_tambah
                Dim baris As Integer = .DataGridView1.Rows.Count
                .DataGridView1.Rows.Add()
                .DataGridView1.Rows(baris).Cells("id_barang").Value = ComboBox1.SelectedValue
                .DataGridView1.Rows(baris).Cells("nama_barang").Value = ComboBox1.Text
                .DataGridView1.Rows(baris).Cells("jenis_barang").Value = lblJenisBrg.Text
                .DataGridView1.Rows(baris).Cells("satuan").Value = lblSatuan.Text
                .DataGridView1.Rows(baris).Cells("harga").Value = lblHargaBrg.Text
                .DataGridView1.Rows(baris).Cells("qty_beli").Value = TextBox1.Text
                .DataGridView1.Rows(baris).Cells("note").Value = TextBox2.Text
                .Enabled = True
            End With
        Else
            MsgBox("Mohon isi quantity!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub pembelian_frm_tambah_detail_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        pembelian_frm_tambah.Enabled = True
    End Sub
End Class