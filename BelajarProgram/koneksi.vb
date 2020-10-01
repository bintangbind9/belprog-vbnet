Public Class koneksi
    Protected cn As OleDb.OleDbConnection
    Protected cmd As OleDb.OleDbCommand
    Protected da As OleDb.OleDbDataAdapter
    Protected ds As DataSet
    Protected dt As DataTable
    Protected conString As String
    Protected svrName As String = "BINTANG\BIND"
    Protected svrData As String = "POS"
    Protected svrUser As String = "sa"
    Protected svrPass As String = "Asevvenx"

    Public Function openconn() As Boolean
        Try
            conString = "Provider=SQLOLEDB;Data Source=" & svrName & ";Initial Catalog=" & svrData & ";Persist Security Info=True;User ID=" & svrUser & ";Password=" & svrPass
            cn = New OleDb.OleDbConnection(conString)
            cn.Open()
            If cn.State <> ConnectionState.Open Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Gagal akses database", MsgBoxStyle.Critical, "Access Failed")
            Return Nothing
            Exit Function
        End Try
    End Function

    Public Sub closeconn()
        If Not IsNothing(cn) Then
            cn.Close()
            cn = Nothing
        End If
    End Sub

    Public Function executequery(ByVal query As String) As DataTable
        If Not openconn() Then
            MsgBox("Koneksi gagal", MsgBoxStyle.Critical, "Access Failed")
            Return Nothing
            Exit Function
        End If
        cmd = New OleDb.OleDbCommand(query, cn)
        da = New OleDb.OleDbDataAdapter
        da.SelectCommand = cmd
        ds = New Data.DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        Return dt
        dt = Nothing
        ds = Nothing
        da = Nothing
        cmd = Nothing
        closeconn()
    End Function

    Public Sub executenonquery(ByVal query As String)
        If Not openconn() Then
            MsgBox("Koneksi gagal", MsgBoxStyle.Critical, "Access Failed")
            Exit Sub
        End If
        cmd = New OleDb.OleDbCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query
        cmd.ExecuteNonQuery()
        cmd = Nothing
        closeconn()
    End Sub

End Class
