Public Class brg_frm
    Dim nama As String

    Sub IsiDataComboJenisBarang()
        ComboBox1.Items.Clear()
        sqLstr = "SELECT [idjenis],[JenisBrg] FROM [POS].[dbo].[tbJenis]"
        tabel = proses.executequery(sqLstr)
        ComboBox1.DataSource = tabel
        ComboBox1.DisplayMember = ("JenisBrg")
        ComboBox1.ValueMember = ("idjenis")
    End Sub

    Sub IsiDataComboSatuan()
        ComboBox2.Items.Clear()
        sqLstr = "SELECT [idsatuan] ,[Satuan] FROM [POS].[dbo].[tbsatuan]"
        tabel = proses.executequery(sqLstr)
        ComboBox2.DataSource = tabel
        ComboBox2.DisplayMember = ("Satuan")
        ComboBox2.ValueMember = ("idsatuan")
    End Sub

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        lblid.Text = ""
    End Sub

    Sub IsiGrid()
        'sqLstr = "SELECT brg.[idbrg], jns.JenisBrg, brg.namabrg, stn.Satuan, brg.[harga], brg.[qty] FROM [POS].[dbo].[msbrg] AS brg INNER JOIN dbo.tbJenis AS jns ON jns.idjenis=brg.jenisbrg INNER JOIN dbo.tbsatuan AS stn ON stn.idsatuan=brg.satuan"
        sqLstr = "SELECT * FROM View_Brg"
        tabel = proses.executequery(sqLstr)
        dgv1.DataSource = tabel
    End Sub

    'Isi data untuk edit
    Sub IsiData()
        With dgv1
            If .Rows.Count > 0 And Button3.Visible = True Then
                lblid.Text = .Item(0, .CurrentRow.Index).Value
                ComboBox1.Text = .Item(1, .CurrentRow.Index).Value
                TextBox1.Text = .Item(2, .CurrentRow.Index).Value
                ComboBox2.Text = .Item(3, .CurrentRow.Index).Value
                TextBox2.Text = .Item(4, .CurrentRow.Index).Value
                TextBox3.Text = .Item(5, .CurrentRow.Index).Value
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
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        dgv1.Enabled = True
    End Sub

    Sub BtnSimpan()
        Button1.Text = "Save"
        Button2.Text = "Cancel"
        Button3.Visible = False
        Button4.Visible = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
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
            TextBox1.Focus()
        Else 'save
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                MsgBox("Input masih Kosong")
            Else
                If lblid.Text = "" Then 'simpan tambah
                    'cek user name sudah ada atau tidak
                    sqLstr = "select * from msbrg where namabrg=" &
                        Aphostrophe(TextBox1.Text)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then
                        MsgBox("Barang sudah ada")
                    Else 'simpan tambah
                        sqLstr = "select top(1)* from msbrg"
                        tabel = proses.executequery(sqLstr)
                        If tabel.Rows.Count > 0 Then
                            sqLstr = "declare @max int;
                    select @max=MAX(idsatuan) from tbsatuan
                    DBCC CHECKIDENT(tbsatuan,reseed,@max) "
                        Else
                            sqLstr = "DBCC CHECKIDENT(idbrg,reseed,0) "
                        End If
                        sqLstr = sqLstr + "INSERT INTO msbrg(jenisbrg, namabrg, satuan, harga, qty) values(" &
                            Aphostrophe(ComboBox1.SelectedValue) & ", " &
                            Aphostrophe(TextBox1.Text) & ", " &
                            Aphostrophe(ComboBox2.SelectedValue) & ", " &
                            Aphostrophe(TextBox2.Text) & ", " &
                            Aphostrophe(TextBox3.Text) & ")"
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Tambah Data")
                        btnAwal()
                        IsiGrid()
                        IsiData()
                    End If
                Else 'update data
                    'cek user
                    sqLstr = "select * from msbrg where namabrg=" &
                        Aphostrophe(TextBox1.Text) & " AND namabrg <> " & Aphostrophe(nama) & " "
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then 'jika ada
                        MsgBox("Barang sudah ada")
                    Else 'update data
                        sqLstr = "update msbrg set jenisbrg=" &
                            Aphostrophe(ComboBox1.SelectedValue) & ", namabrg=" &
                            Aphostrophe(TextBox1.Text) & ", satuan=" &
                            Aphostrophe(ComboBox2.SelectedValue) & ", harga=" &
                            Aphostrophe(TextBox2.Text) & ", qty=" &
                            Aphostrophe(TextBox3.Text) & "
                            where idbrg=" &
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
                TextBox1.Focus()
                nama = TextBox1.Text
                If lblid.Text = 1 Then
                    TextBox1.Enabled = False
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
            tny = MsgBox("apakah anda yakin", MsgBoxStyle.YesNo, "Hapus")
            If tny = vbYes Then
                sqLstr = "Delete from msbrg where idbrg=" & lblid.Text
                proses.executenonquery(sqLstr)
                MsgBox("Berhasil hapus")
                IsiGrid()
                IsiData()
            End If
        Else
            MsgBox("data kosong/belum dipilih")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub brg_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.tbJenis' table. You can move, or remove it, as needed.
        'Me.TbJenisTableAdapter.Fill(Me.DataSet1.tbJenis)
        btnAwal()
        IsiGrid()
        IsiData()
        IsiDataComboSatuan()
        IsiDataComboJenisBarang()
    End Sub

End Class