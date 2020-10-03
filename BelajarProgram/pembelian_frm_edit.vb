Public Class pembelian_frm_edit

    Public Sub isiComboSupplier()
        sqLstr = "SELECT * FROM mssupplier"
        tabel = proses.executequery(sqLstr)
        With cbSupplier
            .DataSource = tabel
            .ValueMember = "idsupplier"
            .DisplayMember = "namasupplier"
        End With
    End Sub

    Private Sub submit()
        sqLstr = "UPDATE TrBeliHead SET Keterangan=" & Aphostrophe(Trim(tbNote.Text)) & ", idSupplier=" & cbSupplier.SelectedValue & "
                  WHERE idTransaksi=" & lblID.Text
        proses.executenonquery(sqLstr)
        MsgBox("Berhasil Update")
        Me.Close()
        pembelian_frm.isiGridHead()
    End Sub

    Private Sub btBatal_Click(sender As Object, e As EventArgs) Handles btBatal.Click
        Me.Close()
    End Sub

    Private Sub btSimpan_Click(sender As Object, e As EventArgs) Handles btSimpan.Click
        Me.submit()
    End Sub
End Class