USE dbColmInventory
GO

ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_ItemType
GO
ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_LowThreshold
GO

-- One more constraint is created in fnGetLen
-- One more constraint is created in fnIsItemDuplicate

ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_ItemType CHECK
(ItemType IN ('Asset', 'Asset - Bulk' ,'Consumable'))
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_ItemType
GO
ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_LowThreshold CHECK
(LowThreshold >= 0)
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_LowThreshold
GO
