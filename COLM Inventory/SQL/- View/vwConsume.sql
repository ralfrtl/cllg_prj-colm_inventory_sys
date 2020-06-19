USE dbColmInventory
GO

ALTER VIEW vwConsume
AS

	SELECT
    C.ConsumeID,
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
    C.Good As ConsumedGood,
    C.Damaged As ConsumedDamaged
    FROM tblConsume AS C
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = C.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = C.InventoryID

GO
