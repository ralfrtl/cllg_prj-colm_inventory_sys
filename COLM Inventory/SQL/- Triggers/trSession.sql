USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trInsertSession
	ON tblSession
	AFTER INSERT
AS
BEGIN

	UPDATE tblSession
    SET
    tblSession.Active = 0
    WHERE tblSession.UserID = (SELECT UserID FROM INSERTED) AND tblSession.Active = 1 AND tblSession.SessionKey <> (SELECT SessionKey FROM INSERTED)

END
GO
