USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER FUNCTION fnTotal(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN dbo.fnGood(@ItemID) +
           dbo.fnDamaged(@ItemID) +
           dbo.fnMaintenance(@ItemID) +
           dbo.fnReplacement(@ItemID)
	
END
GO
