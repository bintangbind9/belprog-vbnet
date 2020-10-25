Public Class supplier_frm

    Dim nama As String

    Sub kosong()
        lblid.Text = ""
        TbNamaSupplier.Text = ""
        TbAlamatSupplier.Text = ""
    End Sub

    Sub IsiGrid()
        sqLstr = "SELECT * FROM mssupplier"
        tabel = proses.executequery(sqLstr)
        dgv1.DataSource = tabel
    End Sub

    Sub IsiData()
        With dgv1
            If .Rows.Count > 0 And Button3.Visible = True Then
                lblid.Text = .Item(0, .CurrentRow.Index).Value
                TbNamaSupplier.Text = .Item(1, .CurrentRow.Index).Value
                TbAlamatSupplier.Text = .Item(2, .CurrentRow.Index).Value
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
        TbNamaSupplier.Enabled = False
        TbAlamatSupplier.Enabled = False
        dgv1.Enabled = True
    End Sub

    Sub BtnSimpan()
        Button1.Text = "Save"
        Button2.Text = "Cancel"
        Button3.Visible = False
        Button4.Visible = False
        TbNamaSupplier.Enabled = True
        TbAlamatSupplier.Enabled = True
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
            TbNamaSupplier.Focus()
        Else 'save
            If TbNamaSupplier.Text = "" Or TbAlamatSupplier.Text = "" Then
                MsgBox("Input masih Kosong")
            Else
                If lblid.Text = "" Then 'simpan tambah
                    'cek user name sudah ada atau tidak
                    sqLstr = "SELECT * FROM mssupplier WHERE namasupplier=" &
                        Aphostrophe(TbNamaSupplier.Text)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then
                        MsgBox("Supplier sudah ada")
                    Else 'simpan tambah
                        sqLstr = "SELECT top(1)* FROM mssupplier"
                        tabel = proses.executequery(sqLstr)
                        If tabel.Rows.Count > 0 Then
                            sqLstr = "declare @max int;
                    select @max=MAX(idsupplier) FROM mssupplier
                    DBCC CHECKIDENT(mssupplier,reseed,@max) "
                        Else
                            sqLstr = "DBCC CHECKIDENT(mssupplier,reseed,0) "
                        End If
                        sqLstr = sqLstr + "INSERT INTO mssupplier(namasupplier, alamatsupplier) VALUES(" &
                            Aphostrophe(TbNamaSupplier.Text) & ", " &
                            Aphostrophe(TbAlamatSupplier.Text) & ")"
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Tambah Data")
                        btnAwal()
                        IsiGrid()
                        IsiData()
                    End If
                Else 'update data
                    'cek user
                    sqLstr = "SELECT * FROM mssupplier WHERE namasupplier=" &
                        Aphostrophe(TbNamaSupplier.Text) & " AND namasupplier<>" &
                        Aphostrophe(nama)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then 'jika ada
                        MsgBox("Supplier sudah ada")
                    Else 'update data
                        sqLstr = "UPDATE mssupplier SET namasupplier=" &
                            Aphostrophe(TbNamaSupplier.Text) & ", alamatsupplier=" & Aphostrophe(TbAlamatSupplier.Text) & " WHERE idsupplier=" &
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
                TbNamaSupplier.Focus()
                nama = TbNamaSupplier.Text
                If lblid.Text = 1 Then
                    TbNamaSupplier.Enabled = False
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
                sqLstr = "DELETE FROM mssupplier WHERE idsupplier=" & lblid.Text
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

    Private Sub supplier_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAwal()
        IsiGrid()
        IsiData()
    End Sub
End Class