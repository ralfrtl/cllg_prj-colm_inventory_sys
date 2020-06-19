USE dbColmInventory
GO

ALTER TABLE tblReservation DROP CONSTRAINT CK_tblReservation_Exists
GO

ALTER FUNCTION fnIsReservationDuplicate(@ReservedBy INTEGER, @ItemID INTEGER, @DateNeeded DATETIME2(2)) RETURNS BIT
AS
BEGIN

    IF (SELECT ISNULL(COUNT(*), 0) FROM tblReservation AS R WHERE R.ReservedBy = @ReservedBy AND R.ItemID = @ItemID AND R.DateNeeded = @DateNeeded) > 1 BEGIN
        RETURN 1
    END
    
    RETURN 0

END
GO

ALTER TABLE tblReservation WITH CHECK ADD CONSTRAINT CK_tblReservation_Exists CHECK
(dbo.fnIsReservationDuplicate(ReservedBy, ItemID, DateNeeded) = 0)
ALTER TABLE tblReservation CHECK CONSTRAINT CK_tblReservation_Exists
GO
