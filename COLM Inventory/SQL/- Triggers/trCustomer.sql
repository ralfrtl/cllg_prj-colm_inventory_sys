USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trInsertUpdateCustomer
	ON tblCustomer
	AFTER INSERT, UPDATE
AS 
BEGIN
	
	UPDATE tblCustomer
	SET
    tblCustomer.MiddleName = IIF(dbo.fnGetLen((SELECT MiddleName FROM INSERTED)) = 0, '', (SELECT MiddleName FROM INSERTED))
	WHERE tblCustomer.CustomerID = (SELECT CustomerID FROM INSERTED)

END
GO

