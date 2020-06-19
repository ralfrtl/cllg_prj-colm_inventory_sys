USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER FUNCTION fnAvailable(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

	RETURN dbo.fnGood(@ItemID) + dbo.fnDamaged(@ItemID)
	
END
GO
