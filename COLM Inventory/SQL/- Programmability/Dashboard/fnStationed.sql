USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER FUNCTION fnStationed(@ItemID INTEGER, @Status NVARCHAR(1)) RETURNS INTEGER
AS
BEGIN
	
	IF (SELECT I.ItemType FROM tblItem AS I WHERE I.ItemID = @ItemID) IN ('Asset', 'Asset - Bulk') BEGIN
		IF @Status = 'G' BEGIN
			RETURN (SELECT ISNULL(SUM(S.Good), 0) FROM tblStation AS S INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND S.InventoryID = I.InventoryID)
        END
        ELSE IF @Status = 'D' BEGIN
			RETURN (SELECT ISNULL(SUM(S.Damaged), 0) FROM tblStation AS S INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND S.InventoryID = I.InventoryID)
        END
	END

	RETURN 0

END
GO
