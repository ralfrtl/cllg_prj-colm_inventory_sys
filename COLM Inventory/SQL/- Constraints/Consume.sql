USE dbColmInventory
GO

ALTER TABLE tblConsume DROP CONSTRAINT CK_tblConsume_Good
GO
ALTER TABLE tblConsume DROP CONSTRAINT CK_tblConsume_Damaged
GO

-- One more constraint is created in fnGetItemType

ALTER TABLE tblConsume WITH CHECK ADD CONSTRAINT CK_tblConsume_Good CHECK
(Good >= 0)
ALTER TABLE tblConsume CHECK CONSTRAINT CK_tblConsume_Good
GO
ALTER TABLE tblConsume WITH CHECK ADD CONSTRAINT CK_tblConsume_Damaged CHECK
(Damaged >= 0)
ALTER TABLE tblConsume CHECK CONSTRAINT CK_tblConsume_Damaged
GO