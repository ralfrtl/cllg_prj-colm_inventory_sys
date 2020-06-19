USE dbColmInventory
GO

ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Exists
GO

ALTER FUNCTION fnIsInventoryDuplicate(@ItemID INTEGER, @Information NVARCHAR(500), @Store NVARCHAR(120), @ReceiptNo NVARCHAR(50), @CostPerUnit DECIMAL(19, 2)) RETURNS BIT
AS
BEGIN

	IF (SELECT ISNULL(COUNT(*), 0) FROM tblInventory AS I WHERE I.ItemID = @ItemID AND I.Information = @Information AND I.Store = @Store AND I.ReceiptNo = @ReceiptNo AND I.CostPerUnit = @CostPerUnit) > 1 BEGIN
        RETURN 1
    END

	RETURN 0

END
GO

ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Exists CHECK
(dbo.fnIsInventoryDuplicate(ItemID, Information, Store, ReceiptNo, CostPerUnit) = 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Exists
GO
