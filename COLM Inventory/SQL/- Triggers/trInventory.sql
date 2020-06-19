USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trInsertUpdateInventory
	ON tblInventory
	AFTER INSERT, UPDATE
AS 
BEGIN
	
	DECLARE @ItemTypeDeleted NVARCHAR(50) = dbo.fnGetItemTypeByItemID((SELECT ItemID FROM DELETED))
	DECLARE @ItemTypeInserted NVARCHAR(50) = dbo.fnGetItemTypeByItemID((SELECT ItemID FROM INSERTED))

	IF @ItemTypeDeleted <> @ItemTypeInserted BEGIN
	   UPDATE tblInventory
		SET
		tblInventory.ItemID = (SELECT ItemID FROM DELETED)
		WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
	END
	ELSE BEGIN
		IF @ItemTypeInserted = 'Consumable' BEGIN
			UPDATE tblInventory
			SET
			tblInventory.Maintenance = 0
			WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
		END
	END
	
END
GO
