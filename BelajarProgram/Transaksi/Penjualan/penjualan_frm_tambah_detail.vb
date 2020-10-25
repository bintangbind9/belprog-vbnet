Public Class penjualan_frm_tambah_detail
    Public currentStock, currentIdBrg As Integer

    Private Sub penjualan_frm_tambah_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.msbrg' table. You can move, or remove it, as needed.
        Me.MsbrgTableAdapter.Fill(Me.DataSet1.msbrg)
        isiDetail()
    End Sub

    Sub isiDetail()
        If Me.Text = "Add Detail" Then
            With penjualan_frm_tambah.DataGridView1
                If .Rows.Count > 0 Then
                    currentStock = 0
                    For i As Integer = 0 To .Rows.Count - 1
                        If ComboBox1.SelectedValue = .Rows(i).Cells("id_barang").Value Then
                            currentStock += .Rows(i).Cells("qty_jual").Value
                        End If
                    Next
                    sqLstr = "SELECT * FROM View_Brg WHERE ID = " & ComboBox1.SelectedValue & ""
                    tabel = proses.executequery(sqLstr)
                    With tabel
                        If .Rows.Count > 0 Then
                            lblSatuan.Text = .Rows(0).Item("Satuan").ToString
                            lblJenisBrg.Text = .Rows(0).Item("Jenis Barang").ToString
                            lblHargaBrg.Text = .Rows(0).Item("Harga").ToString
                            lblStock.Text = (.Rows(0).Item("Qty") - currentStock).ToString
                        End If
                    End With
                Else
                    sqLstr = "SELECT * FROM View_Brg WHERE ID = " & ComboBox1.SelectedValue & ""
                    tabel = proses.executequery(sqLstr)
                    With tabel
                        If .Rows.Count > 0 Then
                            lblSatuan.Text = .Rows(0).Item("Satuan").ToString
                            lblJenisBrg.Text = .Rows(0).Item("Jenis Barang").ToString
                            lblHargaBrg.Text = .Rows(0).Item("Harga").ToString
                            lblStock.Text = .Rows(0).Item("Qty").ToString
                        End If
                    End With
                End If
            End With
        Else
            If ComboBox1.SelectedValue = currentIdBrg Then
                sqLstr = "SELECT * FROM View_Brg WHERE ID = " & ComboBox1.SelectedValue & ""
                tabel = proses.executequery(sqLstr)
                With tabel
                    If .Rows.Count > 0 Then
                        lblSatuan.Text = .Rows(0).Item("Satuan").ToString
                        lblJenisBrg.Text = .Rows(0).Item("Jenis Barang").ToString
                        lblHargaBrg.Text = .Rows(0).Item("Harga").ToString
                        lblStock.Text = (.Rows(0).Item("Qty") + currentStock).ToString
                    End If
                End With
            Else
                sqLstr = "SELECT * FROM View_Brg WHERE ID = " & ComboBox1.SelectedValue & ""
                tabel = proses.executequery(sqLstr)
                With tabel
                    If .Rows.Count > 0 Then
                        lblSatuan.Text = .Rows(0).Item("Satuan").ToString
                        lblJenisBrg.Text = .Rows(0).Item("Jenis Barang").ToString
                        lblHargaBrg.Text = .Rows(0).Item("Harga").ToString
                        lblStock.Text = .Rows(0).Item("Qty").ToString
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not ComboBox1.SelectedValue = Nothing Then
            isiDetail()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lblID.Text = "" Then
            'Tambah data saat transhead belum ada
            If Val(TextBox1.Text) > 0 Then
                If Val(TextBox1.Text) > Val(lblStock.Text) Then
                    MsgBox("Maaf, Qty penjualan melebihi stock!")
                Else
                    With penjualan_frm_tambah
                        Dim baris As Integer = .DataGridView1.Rows.Count
                        .DataGridView1.Rows.Add()
                        .DataGridView1.Rows(baris).Cells("id_barang").Value = ComboBox1.SelectedValue
                        .DataGridView1.Rows(baris).Cells("nama_barang").Value = ComboBox1.Text
                        .DataGridView1.Rows(baris).Cells("jenis_barang").Value = lblJenisBrg.Text
                        .DataGridView1.Rows(baris).Cells("satuan").Value = lblSatuan.Text
                        .DataGridView1.Rows(baris).Cells("harga").Value = lblHargaBrg.Text
                        .DataGridView1.Rows(baris).Cells("qty_jual").Value = TextBox1.Text
                        .DataGridView1.Rows(baris).Cells("note").Value = TextBox2.Text
                        '.Enabled = True
                    End With
                    isiDetail()
                End If
            Else
                MsgBox("Mohon isi quantity!")
            End If
        Else
            If Me.Text = "Add Detail" Then
                If Val(TextBox1.Text) > 0 Then
                    If Val(TextBox1.Text) > Val(lblStock.Text) Then
                        MsgBox("Maaf, Qty penjualan melebihi stock!")
                    Else
                        'Insert
                        Dim idTrans As Integer = lblID.Text

                        sqLstr = "INSERT INTO TrJualDetail(idTransHead, idBarang, Qty, Harga, Keterangan) VALUES(" &
                                idTrans & ", " &
                                ComboBox1.SelectedValue & ", " &
                                TextBox1.Text & ", " &
                                lblHargaBrg.Text & ", " &
                                Aphostrophe(TextBox2.Text) & ")"
                        proses.executenonquery(sqLstr)

                        sqLstr = "UPDATE msbrg SET qty = qty - " & TextBox1.Text & "
                                  WHERE idbrg=" & ComboBox1.SelectedValue
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Tambah Data")
                        Me.Close()
                        penjualan_frm.isiGridDetail()
                    End If
                Else
                    MsgBox("Mohon isi quantity!")
                End If
            Else 'Me.Text = "Edit Detail"
                If Val(TextBox1.Text) > 0 Then
                    If Val(TextBox1.Text) > Val(lblStock.Text) Then
                        MsgBox("Maaf, Qty penjualan melebihi stock!")
                    Else
                        'Update
                        Dim idTrans As Integer = lblID.Text

                        sqLstr = "UPDATE TrJualDetail SET idTransHead = " & idTrans & ",
                              idBarang = " & ComboBox1.SelectedValue & ",
                              Qty = " & TextBox1.Text & ",
                              Harga = " & lblHargaBrg.Text & ",
                              Keterangan = " & Aphostrophe(TextBox2.Text) & "
                              WHERE idTransDetail = " & penjualan_frm.DataGridView2.CurrentRow.Cells(10).Value
                        proses.executenonquery(sqLstr)

                        sqLstr = "UPDATE msbrg SET qty = qty + " & currentStock & "
                                  WHERE idbrg=" & currentIdBrg & ";
                              UPDATE msbrg SET qty = qty - " & TextBox1.Text & "
                                  WHERE idbrg=" & ComboBox1.SelectedValue
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Update Data")
                        Me.Close()
                        penjualan_frm.isiGridDetail()
                    End If
                Else
                    MsgBox("Mohon isi quantity!")
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub pembelian_frm_tambah_detail_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        penjualan_frm_tambah.Enabled = True
    End Sub
End Class