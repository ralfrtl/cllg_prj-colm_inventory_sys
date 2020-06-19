USE dbColmInventory
GO

ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_MultipleAssetQty
GO

CREATE FUNCTION fnIsMultipleAssetQty(@InventoryID INTEGER) RETURNS BIT
AS
BEGIN

    IF dbo.fnGetItemType(@InventoryID) = 'Asset' BEGIN
        DECLARE @Inventory INTEGER = 0,
                @NotInventory INTEGER = 0

        SELECT @Inventory += (ISNULL(SUM(II.Good), 0) + ISNULL(SUM(II.Damaged), 0) + ISNULL(SUM(II.Maintenance), 0) + ISNULL(SUM(II.Replacement), 0))
               FROM tblInventory AS II WHERE II.InventoryID = @InventoryID

        SELECT @NotInventory += (ISNULL(SUM(B.Good), 0) + ISNULL(SUM(B.Damaged), 0))
               FROM tblBorrow AS B WHERE B.InventoryID = @InventoryID

        SELECT @NotInventory += (ISNULL(SUM(S.Good), 0) + ISNULL(SUM(S.Damaged), 0))
               FROM tblStation AS S WHERE S.InventoryID = @InventoryID

        IF (@Inventory = 1 AND @NotInventory = 0) OR
           (@Inventory = 0 AND @NotInventory = 1) OR
           (@Inventory = 0 AND @NotInventory = 0) BEGIN
            RETURN 0
        END
    END
    ELSE BEGIN
        RETURN 0
    END

	RETURN 1

END
GO

ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_MultipleAssetQty CHECK
(dbo.fnIsMultipleAssetQty(InventoryID) = 0 AND
Good = Good AND
Damaged = Damaged AND
Maintenance = Maintenance AND
Replacement = Replacement)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_MultipleAssetQty
GO
