USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER FUNCTION fnConsumed(@ItemID INTEGER, @Status NVARCHAR(1)) RETURNS INTEGER
AS
BEGIN
    
	IF (SELECT I.ItemType FROM tblItem AS I WHERE I.ItemID = @ItemID) = 'Consumable' BEGIN
		IF @Status = 'G' BEGIN
			RETURN (SELECT ISNULL(SUM(C.Good), 0) FROM tblConsume AS C INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND C.InventoryID = I.InventoryID)
        END
        ELSE IF @Status = 'D' BEGIN
			RETURN (SELECT ISNULL(SUM(C.Damaged), 0) FROM tblConsume AS C INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND C.InventoryID = I.InventoryID)
        END
	END

	RETURN 0
	
END
GO
