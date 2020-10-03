Public Class pembelian_frm_tambah
    Private Sub pembelian_frm_tambah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.mssupplier' table. You can move, or remove it, as needed.
        Me.MssupplierTableAdapter.Fill(Me.DataSet1.mssupplier)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        pembelian_frm.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Enabled = False
        With pembelian_frm_tambah_detail
            MdiParent = Main_frm
            .Show()
            .BringToFront()
            .StartPosition = FormStartPosition.CenterScreen
            .lblID.Text = ""
            .Text = "Add Detail"
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            If lblID.Text = "Tambah" Then
                'Insert Header
                sqLstr = "INSERT INTO TrBeliHead(Tgl, idSupplier, idUser, Keterangan) VALUES(" &
                    Aphostrophe(lblTgl.Text) & ", " &
                    ComboBox1.SelectedValue & ", " &
                    idUser & ", " &
                    Aphostrophe(TextBox1.Text) & ")"
                proses.executenonquery(sqLstr)

                'Insert Detail
                sqLstr = "SELECT TOP(10) idTransaksi FROM TrBeliHead ORDER BY idTransaksi DESC"
                tabel = proses.executequery(sqLstr)
                Dim idTrans As Integer = tabel.Rows(0).Item(0).ToString

                With DataGridView1
                    For i = 0 To .Rows.Count - 1
                        sqLstr = "INSERT INTO TrBeliDetail(idTransHead, idBarang, Qty, Harga, Keterangan) VALUES(" &
                            idTrans & ", " &
                            .Rows(i).Cells("id_barang").Value & ", " &
                            .Rows(i).Cells("qty_beli").Value & ", " &
                            .Rows(i).Cells("harga").Value & ", " &
                            Aphostrophe(.Rows(i).Cells("note").Value) & ")"
                        proses.executenonquery(sqLstr)

                        sqLstr = "UPDATE msbrg SET qty = qty + " & .Rows(i).Cells("qty_beli").Value & "
                                  WHERE idbrg=" & .Rows(i).Cells("id_barang").Value
                        proses.executenonquery(sqLstr)
                    Next
                    MsgBox("Berhasil Tambah Data")
                End With
                Me.Close()
                pembelian_frm.Enabled = True
                pembelian_frm.isiGridHead()
                'pembelian_frm.DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)
                pembelian_frm.isiGridDetail()
            Else
                'Update

            End If
        Else
            MsgBox("Belum ada detail")
        End If
    End Sub

    Private Sub pembelian_frm_tambah_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        pembelian_frm.Enabled = True
    End Sub
End Class