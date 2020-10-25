Public Class penjualan_frm

    Private Sub penjualan_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isiGridHead()
        DataGridView1.Columns("ID Transaksi").Visible = False
        DataGridView1.Columns("ID Customer").Visible = False
        DataGridView1.Columns("ID User").Visible = False
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)
            isiGridDetail()
        End If
    End Sub

    Sub isiGridDetail()
        If DataGridView1.Rows.Count > 0 Then
            'Dim idtr As Integer = DataGridView1.Item("ID Transaksi", DataGridView1.CurrentRow.Index).Value
            Dim idtr As Integer = DataGridView1.CurrentRow.Cells(0).Value
            sqLstr = "SELECT TOP(100) * FROM View_DetailJual WHERE [ID Transaksi]=" & idtr & ""
            tabel = proses.executequery(sqLstr)
            DataGridView2.DataSource = tabel
        Else
            DataGridView2.DataSource = Nothing
        End If
    End Sub

    Sub isiGridHead()
        sqLstr = "SELECT TOP(100) * FROM View_HeadJual ORDER BY [Tanggal] DESC"
        tabel = proses.executequery(sqLstr)
        DataGridView1.DataSource = tabel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With penjualan_frm_tambah
            .MdiParent = Main_frm
            .Show()
            .BringToFront()
            .Top = 0
            .Left = 0
            Me.Enabled = False
            .lblID.Text = "Tambah"
            .lblTgl.Text = Format(Now, "dd MMM yyyy")
        End With
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        isiGridDetail()
    End Sub

    'Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
    'isiGridDetail()
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim idTrans As Integer = DataGridView1.CurrentRow.Cells(0).Value
            With penjualan_frm_edit
                .Show()
                .MdiParent = Main_frm
                .Focus()
                .isiComboCustomer()
                sqLstr = "SELECT * FROM TrJualHead WHERE idTransaksi=" & idTrans
                tabel = proses.executequery(sqLstr)
                .lblID.Text = idTrans
                Dim tgl As Date = tabel.Rows(0).Item("Tgl")
                .lblTgl.Text = Format(tgl, "dd MMM yyyy")
                .cbCustomer.SelectedValue = tabel.Rows(0).Item("idCustomer")
                .tbNote.Text = tabel.Rows(0).Item("Keterangan").ToString
            End With
        Else
            MsgBox("Tidak ada data")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If DataGridView1.Rows.Count > 0 Then
            With penjualan_frm_tambah_detail
                .Show()
                .MdiParent = Main_frm
                .Focus()
                .Text = "Add Detail"
                .lblID.Text = DataGridView1.CurrentRow.Cells("ID Transaksi").Value
            End With
        Else
            MsgBox("Tidak ada data di Transaksi Head!")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If DataGridView2.Rows.Count > 0 Then
            With penjualan_frm_tambah_detail
                .Text = "Edit Detail"
                .currentIdBrg = DataGridView2.CurrentRow.Cells("ID Barang").Value
                .currentStock = DataGridView2.CurrentRow.Cells("Qty").Value
                .Show()
                .MdiParent = Main_frm
                .Focus()
                .lblID.Text = DataGridView1.CurrentRow.Cells("ID Transaksi").Value
                .ComboBox1.SelectedValue = DataGridView2.CurrentRow.Cells("ID Barang").Value
                .TextBox1.Text = DataGridView2.CurrentRow.Cells("Qty").Value
                .TextBox2.Text = DataGridView2.CurrentRow.Cells("Keterangan").Value
            End With
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex() = 0 Then
            Button5_Click(sender, e)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DataGridView2.Rows.Count > 0 Then
            Dim tny As String
            tny = MsgBox("Yakin Hapus data?", MsgBoxStyle.YesNo, "Hapus data")
            If tny = vbYes Then
                Dim id As Integer = DataGridView2.CurrentRow.Cells("ID Trans Detail").Value
                sqLstr = "SELECT * FROM TrJualDetail WHERE idTransDetail=" & id
                tabel = proses.executequery(sqLstr)
                sqLstr = "UPDATE msbrg SET qty = qty + " & tabel.Rows(0).Item(3) & " WHERE idbrg=" & tabel.Rows(0).Item(2) & ";
                      DELETE FROM TrJualDetail WHERE idTransDetail = " & id
                proses.executenonquery(sqLstr)
                MsgBox("Berhasil hapus data")
                isiGridDetail()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count > 0 Then
            Dim tny As String
            tny = MsgBox("Yakin Hapus data beserta detail barangnya?", MsgBoxStyle.YesNo, "Hapus data")
            If tny = vbYes Then
                Dim id As Integer = DataGridView1.CurrentRow.Cells("ID Transaksi").Value
                sqLstr = "SELECT * FROM TrJualDetail WHERE idTransHead = " & id
                tabel = proses.executequery(sqLstr)
                For i As Integer = 0 To tabel.Rows.Count - 1
                    sqLstr = "UPDATE msbrg SET qty = qty + " & tabel.Rows(i).Item(3) & " WHERE idbrg=" & tabel.Rows(i).Item(2)
                    proses.executenonquery(sqLstr)
                Next

                sqLstr = "DELETE FROM [POS].[dbo].[TrJualDetail] WHERE [idTransHead] = " & id & ";
                      DELETE FROM [POS].[dbo].[TrJualHead] WHERE [idTransaksi] = " & id & ";"
                proses.executenonquery(sqLstr)

                MsgBox("Berhasil hapus data")
                isiGridHead()
                isiGridDetail()
            End If
        Else
            MsgBox("Tidak ada data")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class