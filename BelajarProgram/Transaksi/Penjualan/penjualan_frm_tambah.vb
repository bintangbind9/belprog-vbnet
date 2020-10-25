Imports System.Data.SqlClient

Public Class penjualan_frm_tambah

    Private Sub penjualan_frm_tambah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet2.mscust' table. You can move, or remove it, as needed.
        Me.MscustTableAdapter.Fill(Me.DataSet2.mscust)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        penjualan_frm.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Enabled = False
        With penjualan_frm_tambah_detail
            .MdiParent = Main_frm
            .Show()
            .BringToFront()
            .StartPosition = FormStartPosition.CenterScreen
            .lblID.Text = ""
            .Text = "Add Detail"
        End With
    End Sub

    Private Sub insertTrJualHead()
        sqlCon = New SqlConnection(strConn)
        Using sqlCon

            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlCon

            sqlComm.CommandText = "InsertTrJualHead"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("Tgl", lblTgl.Text)
            sqlComm.Parameters.AddWithValue("idCustomer", ComboBox1.SelectedValue)
            sqlComm.Parameters.AddWithValue("idUser", idUser)
            sqlComm.Parameters.AddWithValue("Keterangan", TextBox1.Text)

            sqlCon.Open()

            sqlComm.ExecuteNonQuery()

        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            If lblID.Text = "Tambah" Then
                'Insert Header Common Step:
                'sqLstr = "INSERT INTO TrJualHead(Tgl, idCustomer, idUser, Keterangan) VALUES(" &
                'Aphostrophe(lblTgl.Text) & ", " &
                'ComboBox1.SelectedValue & ", " &
                'idUser & ", " &
                'Aphostrophe(TextBox1.Text) & ")"
                'proses.executenonquery(sqLstr)

                'Insert Header With Store Procedure:
                insertTrJualHead()

                'Insert Detail
                sqLstr = "SELECT TOP(10) idTransaksi FROM TrJualHead ORDER BY idTransaksi DESC"
                tabel = proses.executequery(sqLstr)
                Dim idTrans As Integer = tabel.Rows(0).Item(0).ToString

                With DataGridView1
                    For i = 0 To .Rows.Count - 1
                        sqLstr = "INSERT INTO TrJualDetail(idTransHead, idBarang, Qty, Harga, Keterangan) VALUES(" &
                            idTrans & ", " &
                            .Rows(i).Cells("id_barang").Value & ", " &
                            .Rows(i).Cells("qty_jual").Value & ", " &
                            .Rows(i).Cells("harga").Value & ", " &
                            Aphostrophe(.Rows(i).Cells("note").Value) & ")"
                        proses.executenonquery(sqLstr)

                        sqLstr = "UPDATE msbrg SET qty = qty - " & .Rows(i).Cells("qty_jual").Value & "
                                  WHERE idbrg=" & .Rows(i).Cells("id_barang").Value
                        proses.executenonquery(sqLstr)
                    Next
                    MsgBox("Berhasil Tambah Data")
                End With
                Me.Close()
                penjualan_frm.Enabled = True
                penjualan_frm.isiGridHead()
                'pembelian_frm.DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)
                penjualan_frm.isiGridDetail()
            Else
                'Update

            End If
        Else
            MsgBox("Belum ada detail")
        End If
    End Sub

    Private Sub penjualan_frm_tambah_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        penjualan_frm.Enabled = True
    End Sub

End Class