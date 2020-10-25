Imports System.Data.SqlClient

Module umum
    Public proses As New koneksi
    Public tabel As DataTable
    Public sqLstr As String
    Public namaUser As String
    Public idUser As String

    Public svrName As String = "BINTANG\BIND"
    Public svrData As String = "POS"
    Public svrUser As String = "sa"
    Public svrPass As String = "Asevvenx"
    Public strConn As String = "Data Source=" & svrName & ";Initial Catalog=" & svrData & ";Integrated Security=True;User ID=" & svrUser & ";Password=" & svrPass
    Public sqlCon As SqlConnection

    Function Aphostrophe(ByVal sval As String) As String
        Dim sRet As String
        sRet = sval.Replace("'", "''")

        sRet = "'" + sRet + "'"
        Return sRet
    End Function

End Module
