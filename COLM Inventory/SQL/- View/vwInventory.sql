USE dbColmInventory
GO

ALTER VIEW vwInventory
AS

    SELECT
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    FORMAT(II.DateReceived, 'MMM-dd-yyyy hh:mm:ss tt') AS DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
    II.Maintenance,
    II.Replacement,
	IIF(dbo.fnGetItemTypeByItemID(II.ItemID) = 'Asset',
		IIF((SELECT ISNULL(SUM(B.Good), 0) + ISNULL(SUM(B.Damaged), 0) FROM tblBorrow AS B WHERE B.InventoryID = II.InventoryID) = 0  AND
			(SELECT ISNULL(SUM(S.Good), 0) + ISNULL(SUM(S.Damaged), 0) FROM tblStation AS S WHERE S.InventoryID = II.InventoryID) = 0,
			'False', 'True'),
		'') AS InUse
    FROM tblInventory AS II
	
GO
