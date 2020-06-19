USE dbColmInventory
GO

ALTER VIEW vwBorrow
AS
	
	SELECT
    B.BorrowID,
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
    B.Good AS BorrowedGood,
    B.Damaged AS BorrowedDamaged
    FROM tblBorrow AS B
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = B.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = B.InventoryID

GO
