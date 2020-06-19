USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trInsertUpdateActivityLog
	ON tblActivityLog
	AFTER INSERT, UPDATE
AS 
BEGIN
	
	UPDATE tblActivityLog
	SET
    tblActivityLog.Details = IIF(dbo.fnGetLen((SELECT Details FROM INSERTED)) = 0, NULL, (SELECT Details FROM INSERTED))
	WHERE tblActivityLog.LogID = (SELECT LogID FROM INSERTED)

END
GO
