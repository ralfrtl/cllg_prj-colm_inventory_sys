USE dbColmInventory
GO

ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_CostPerUnit
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Good
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Damaged
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Maintenance
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Replacement
GO

-- One more constraint is created in fnGetLen
-- One more constraint is created in fnIsMultipleAssetQty

ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_CostPerUnit CHECK
(CostPerUnit >= 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_CostPerUnit
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Good CHECK
(Good >= 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Good
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Damaged CHECK
(Damaged >= 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Damaged
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Maintenance CHECK
(Maintenance >= 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Maintenance
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Replacement CHECK
(Replacement >= 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Replacement
GO
