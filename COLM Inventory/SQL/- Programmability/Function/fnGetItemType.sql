USE dbColmInventory
GO

ALTER TABLE tblConsume DROP CONSTRAINT CK_tblConsume_ItemType
GO
ALTER TABLE tblBorrow DROP CONSTRAINT CK_tblBorrow_ItemType
GO
ALTER TABLE tblStation DROP CONSTRAINT CK_tblStation_ItemType
GO

ALTER FUNCTION fnGetItemType(@InventoryID INTEGER) RETURNS NVARCHAR(50)
AS
BEGIN
	
	RETURN (SELECT I.ItemType FROM tblItem AS I INNER JOIN tblInventory AS II ON II.InventoryID = @InventoryID AND I.ItemID = II.ItemID)

END
GO


ALTER FUNCTION fnGetItemTypeByItemID(@ItemID INTEGER) RETURNS NVARCHAR(50)
AS
BEGIN
	
	RETURN (SELECT I.ItemType FROM tblItem AS I WHERE I.ItemID = @ItemID)

END
GO


ALTER TABLE tblConsume WITH CHECK ADD CONSTRAINT CK_tblConsume_ItemType CHECK
(dbo.fnGetItemType(InventoryID) = 'Consumable')
ALTER TABLE tblConsume CHECK CONSTRAINT CK_tblConsume_ItemType
GO
ALTER TABLE tblBorrow WITH CHECK ADD CONSTRAINT CK_tblBorrow_ItemType CHECK
(dbo.fnGetItemType(InventoryID) IN ('Asset', 'Asset - Bulk'))
ALTER TABLE tblBorrow CHECK CONSTRAINT CK_tblBorrow_ItemType
GO
ALTER TABLE tblStation WITH CHECK ADD CONSTRAINT CK_tblStation_ItemType CHECK
(dbo.fnGetItemType(InventoryID) IN ('Asset', 'Asset - Bulk'))
ALTER TABLE tblStation CHECK CONSTRAINT CK_tblStation_ItemType
GO
