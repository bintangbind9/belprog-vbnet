CREATE PROCEDURE InsertTrJualHead
@idTransaksi int,
@Tgl date,
@idCustomer int,
@idUser int,
@Keterangan varchar(50)
 
AS
 
BEGIN
 
INSERT INTO TrJualHead(idTransaksi, Tgl, idCustomer, idUser, Keterangan)
 
VALUES ( @idTransaksi, @Tgl, @idCustomer, @idUser, @Keterangan)
 
END