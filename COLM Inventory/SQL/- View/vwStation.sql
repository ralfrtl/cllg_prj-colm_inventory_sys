USE dbColmInventory
GO

ALTER VIEW vwStation
AS

	SELECT
    S.StationID,
    CC.*,
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    II.DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
	S.Location,
    S.Good AS StationedGood,
    S.Damaged AS StationedDamaged
    FROM tblStation AS S
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = S.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = S.InventoryID

GO
