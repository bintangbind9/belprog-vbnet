Public Class Main_frm
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        keluar()
    End Sub

    Sub keluar()
        Login_frm.Show()
        Me.Close()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        user_frm.MdiParent = Me
        user_frm.Show()
        user_frm.Top = 0
        user_frm.Left = 0
    End Sub

    Private Sub Main_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If idUser = 1 Then
            AdminToolStripMenuItem.Visible = True
        Else
            AdminToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub JenisBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JenisBarangToolStripMenuItem.Click
        With Jenis_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub

    Private Sub SatuanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatuanToolStripMenuItem.Click
        With satuan_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub

    Private Sub BarangProdukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarangProdukToolStripMenuItem.Click
        With brg_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        With cust_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        With supplier_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        With pembelian_frm
            .MdiParent = Me
            .Show()
            .Top = 0
            .Left = 0
        End With
    End Sub
End Class