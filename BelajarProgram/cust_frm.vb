Public Class cust_frm
    Dim nama As String

    Sub kosong()
        lblid.Text = ""
        TbNamaCust.Text = ""
        TbAlamatCust.Text = ""
    End Sub

    Sub IsiGrid()
        sqLstr = "SELECT * FROM mscust"
        tabel = proses.executequery(sqLstr)
        dgv1.DataSource = tabel
    End Sub

    Sub IsiData()
        With dgv1
            If .Rows.Count > 0 And Button3.Visible = True Then
                lblid.Text = .Item(0, .CurrentRow.Index).Value
                TbNamaCust.Text = .Item(1, .CurrentRow.Index).Value
                TbAlamatCust.Text = .Item(2, .CurrentRow.Index).Value
            End If
        End With
    End Sub

    Sub btnAwal()
        Button1.Text = "Add"
        Button2.Text = "Edit"
        Button3.Text = "Delete"
        Button4.Text = "Keluar"
        Button3.Visible = True
        Button4.Visible = True
        TbNamaCust.Enabled = False
        TbAlamatCust.Enabled = False
        dgv1.Enabled = True
    End Sub

    Sub BtnSimpan()
        Button1.Text = "Save"
        Button2.Text = "Cancel"
        Button3.Visible = False
        Button4.Visible = False
        TbNamaCust.Enabled = True
        TbAlamatCust.Enabled = True
        dgv1.Enabled = False
    End Sub

    Private Sub dgv1_Click(sender As Object, e As EventArgs) Handles dgv1.Click
        IsiData()
    End Sub

    'tombol tambah/simpan
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Add" Then
            kosong()
            BtnSimpan()
            TbNamaCust.Focus()
        Else 'save
            If TbNamaCust.Text = "" Or TbAlamatCust.Text = "" Then
                MsgBox("Input masih Kosong")
            Else
                If lblid.Text = "" Then 'simpan tambah
                    'cek user name sudah ada atau tidak
                    sqLstr = "SELECT * FROM mscust WHERE namacust=" &
                        Aphostrophe(TbNamaCust.Text)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then
                        MsgBox("Customer sudah ada")
                    Else 'simpan tambah
                        sqLstr = "SELECT top(1)* FROM mscust"
                        tabel = proses.executequery(sqLstr)
                        If tabel.Rows.Count > 0 Then
                            sqLstr = "declare @max int;
                    select @max=MAX(idcust) FROM mscust
                    DBCC CHECKIDENT(mscust,reseed,@max) "
                        Else
                            sqLstr = "DBCC CHECKIDENT(mscust,reseed,0) "
                        End If
                        sqLstr = sqLstr + "INSERT INTO mscust(namacust, alamatcust) VALUES(" &
                            Aphostrophe(TbNamaCust.Text) & ", " &
                            Aphostrophe(TbAlamatCust.Text) & ")"
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Tambah Data")
                        btnAwal()
                        IsiGrid()
                        IsiData()
                    End If
                Else 'update data
                    'cek user
                    sqLstr = "SELECT * FROM mscust WHERE namacust=" &
                        Aphostrophe(TbNamaCust.Text) & " AND namacust<>" &
                        Aphostrophe(nama)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then 'jika ada
                        MsgBox("Customer sudah ada")
                    Else 'update data
                        sqLstr = "UPDATE mscust SET namacust=" &
                            Aphostrophe(TbNamaCust.Text) & ", alamatcust=" & Aphostrophe(TbAlamatCust.Text) & " WHERE idcust=" &
                            lblid.Text
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Update Data")
                        btnAwal()
                        IsiGrid()
                        IsiData()
                    End If
                End If

            End If
        End If
    End Sub

    'tombol edit cancel
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            If lblid.Text <> "" Then
                BtnSimpan()
                TbNamaCust.Focus()
                nama = TbNamaCust.Text
                If lblid.Text = 1 Then
                    TbNamaCust.Enabled = False
                End If
            End If

        Else 'cancel
            btnAwal()
        End If
    End Sub

    'hapus data
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dgv1.Rows.Count > 0 Then
            Dim tny As String
            tny = MsgBox("Apakah anda yakin?", MsgBoxStyle.YesNo, "Hapus")
            If tny = vbYes Then
                sqLstr = "DELETE FROM mscust WHERE idcust=" & lblid.Text
                proses.executenonquery(sqLstr)
                MsgBox("Berhasil hapus data")
                IsiGrid()
                IsiData()
            End If
        Else
            MsgBox("Data kosong/ Belum dipilih!")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub cust_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAwal()
        IsiGrid()
        IsiData()
    End Sub
End Class