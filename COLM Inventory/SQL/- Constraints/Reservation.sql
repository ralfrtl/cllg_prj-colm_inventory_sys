USE dbColmInventory
GO

ALTER TABLE tblReservation DROP CONSTRAINT CK_tblReservation_ClaimedBy
GO
ALTER TABLE tblReservation DROP CONSTRAINT CK_tblReservation_QuantityNeeded
GO
ALTER TABLE tblReservation DROP CONSTRAINT CK_tblReservation_QuantityClaimed
GO

ALTER TABLE tblReservation WITH CHECK ADD CONSTRAINT CK_tblReservation_ClaimedBy CHECK
(QuantityClaimed = 0 OR (QuantityClaimed <> 0 AND ClaimedBy IS NOT NULL))
ALTER TABLE tblReservation CHECK CONSTRAINT CK_tblReservation_ClaimedBy
GO
ALTER TABLE tblReservation WITH CHECK ADD CONSTRAINT CK_tblReservation_QuantityNeeded CHECK
(QuantityNeeded >= 0)
ALTER TABLE tblReservation CHECK CONSTRAINT CK_tblReservation_QuantityNeeded
GO
ALTER TABLE tblReservation WITH CHECK ADD CONSTRAINT CK_tblReservation_QuantityClaimed  CHECK
(QuantityClaimed >= 0)
ALTER TABLE tblReservation CHECK CONSTRAINT CK_tblReservation_QuantityClaimed
GO
