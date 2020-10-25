Public Class penjualan_frm_edit

    Public Sub isiComboCustomer()
        sqLstr = "SELECT * FROM mscust"
        tabel = proses.executequery(sqLstr)
        With cbCustomer
            .DataSource = tabel
            .ValueMember = "idcust"
            .DisplayMember = "namacust"
        End With
    End Sub

    Private Sub submit()
        sqLstr = "UPDATE TrJualHead SET Keterangan=" & Aphostrophe(Trim(tbNote.Text)) & ", idCustomer=" & cbCustomer.SelectedValue & "
                  WHERE idTransaksi=" & lblID.Text
        proses.executenonquery(sqLstr)
        MsgBox("Berhasil Update")
        Me.Close()
        penjualan_frm.isiGridHead()
    End Sub

    Private Sub btBatal_Click(sender As Object, e As EventArgs) Handles btBatal.Click
        Me.Close()
    End Sub

    Private Sub btSimpan_Click(sender As Object, e As EventArgs) Handles btSimpan.Click
        Me.submit()
    End Sub

End Class