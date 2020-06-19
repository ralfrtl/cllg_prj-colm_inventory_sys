USE dbColmInventory
GO

ALTER TABLE tblStation DROP CONSTRAINT CK_tblStation_Good
GO
ALTER TABLE tblStation DROP CONSTRAINT CK_tblStation_Damaged
GO

-- One more constraint is created in fnGetItemType
-- One more constraint is created in fnGetLen

ALTER TABLE tblStation WITH CHECK ADD CONSTRAINT CK_tblStation_Good CHECK
(Good >= 0)
ALTER TABLE tblStation CHECK CONSTRAINT CK_tblStation_Good
GO
ALTER TABLE tblStation WITH CHECK ADD CONSTRAINT CK_tblStation_Damaged CHECK
(Damaged >= 0)
ALTER TABLE tblStation CHECK CONSTRAINT CK_tblStation_Damaged
GO
