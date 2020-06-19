USE dbColmInventory
GO

ALTER VIEW vwItem
AS
	
	SELECT
	I.ItemID,
    I.Name,
    I.Description,
    I.ItemType,
    I.UnitType,
    I.LowThreshold,
    dbo.fnTotal(I.ItemID) AS Total,
    dbo.fnAvailable(I.ItemID) AS Available,
    dbo.fnBorrowed(I.ItemID, 'G') + dbo.fnBorrowed(I.ItemID, 'D') AS Borrowed,
    dbo.fnStationed(I.ItemID, 'G') + dbo.fnStationed(I.ItemID, 'D') AS Stationed,
    dbo.fnReserved(I.ItemID) AS Reserved,
    dbo.fnGood(I.ItemID) AS Good,
    dbo.fnDamaged(I.ItemID) AS Damaged,
    dbo.fnMaintenance(I.ItemID) AS Maintenance,
    dbo.fnReplacement(I.ItemID) AS Replacement
	FROM tblItem AS I

GO
