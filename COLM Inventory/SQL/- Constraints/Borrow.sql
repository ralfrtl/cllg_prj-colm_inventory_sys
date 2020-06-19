USE dbColmInventory
GO

ALTER TABLE tblBorrow DROP CONSTRAINT CK_tblBorrow_Good
GO
ALTER TABLE tblBorrow DROP CONSTRAINT CK_tblBorrow_Damaged
GO

-- One more constraint is created in fnGetItemType
-- One more constraint is created in fnGetLen

ALTER TABLE tblBorrow WITH CHECK ADD CONSTRAINT CK_tblBorrow_Good CHECK
(Good >= 0)
ALTER TABLE tblBorrow CHECK CONSTRAINT CK_tblBorrow_Good
GO
ALTER TABLE tblBorrow WITH CHECK ADD CONSTRAINT CK_tblBorrow_Damaged CHECK
(Damaged >= 0)
ALTER TABLE tblBorrow CHECK CONSTRAINT CK_tblBorrow_Damaged
GO
