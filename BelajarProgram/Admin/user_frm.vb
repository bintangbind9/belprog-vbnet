Public Class user_frm
    Dim nama As String

    Private Sub user_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAwal()
        IsiGrid()
        IsiData()
    End Sub

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        lblid.Text = ""
    End Sub

    Sub IsiGrid()
        sqLstr = "Select * from msuser"
        tabel = proses.executequery(sqLstr)
        dgv1.DataSource = tabel
    End Sub

    Sub IsiData()
        With dgv1
            If .Rows.Count > 0 And Button3.Visible = True Then
                lblid.Text = .Item(0, .CurrentRow.Index).Value
                TextBox1.Text = .Item(1, .CurrentRow.Index).Value
                TextBox2.Text = .Item(2, .CurrentRow.Index).Value
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
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        dgv1.Enabled = True
    End Sub

    Sub BtnSimpan()
        Button1.Text = "Save"
        Button2.Text = "Cancel"
        Button3.Visible = False
        Button4.Visible = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
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
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Input masih Kosong")
            Else
                If lblid.Text = "" Then 'simpan tambah
                    'cek user name sudah ada atau tidak
                    sqLstr = "select * from msuser where username=" &
                        Aphostrophe(TextBox1.Text)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then
                        MsgBox("User sudah ada")
                    Else 'simpan tambah
                        sqLstr = "select top(1)* from msuser"
                        tabel = proses.executequery(sqLstr)
                        If tabel.Rows.Count > 0 Then
                            sqLstr = "declare @max int;
                    select @max=MAX(Iduser) from Msuser
                    DBCC CHECKIDENT(MSuser,reseed,@max) "
                        Else
                            sqLstr = "DBCC CHECKIDENT(MSuser,reseed,0) "
                        End If
                        sqLstr = sqLstr + "Insert into msuser(username,pass)values(" &
                            Aphostrophe(TextBox1.Text) & "," &
                            Aphostrophe(TextBox2.Text) & ")"
                        proses.executenonquery(sqLstr)
                        MsgBox("Berhasil Tambah Data")
                        btnAwal()
                        IsiGrid()
                        IsiData()
                    End If
                Else 'update data
                    'cek user
                    sqLstr = "select * from msuser where username=" &
                        Aphostrophe(TextBox1.Text) & " and username<>" &
                        Aphostrophe(nama)
                    tabel = proses.executequery(sqLstr)
                    If tabel.Rows.Count > 0 Then 'jika ada
                        MsgBox("User sudah ada")
                    Else 'update data
                        sqLstr = "update msuser set username=" &
                            Aphostrophe(TextBox1.Text) & ",pass=" &
                            Aphostrophe(TextBox2.Text) & "where iduser=" &
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
            If lblid.Text = 1 Then
                MsgBox("Admin tidak dapat dihapus")
            Else
                Dim tny As String
                tny = MsgBox("apakah anda yakin", MsgBoxStyle.YesNo, "Hapus")
                If tny = vbYes Then
                    sqLstr = "Delete from msuser where iduser=" & lblid.Text
                    proses.executenonquery(sqLstr)
                    MsgBox("Berhasil hapus")
                    IsiGrid()
                    IsiData()
                End If
            End If
        Else
            MsgBox("data kosong/belum dipilih")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

End Class