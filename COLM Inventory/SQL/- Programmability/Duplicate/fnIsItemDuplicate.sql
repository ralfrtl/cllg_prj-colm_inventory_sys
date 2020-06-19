USE dbColmInventory
GO

ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_Exists
GO

ALTER FUNCTION fnIsItemDuplicate(@Name NVARCHAR(50), @Description NVARCHAR(50), @ItemType NVARCHAR(50), @UnitType NVARCHAR(50)) RETURNS BIT
AS
BEGIN

	IF (SELECT ISNULL(COUNT(*), 0) FROM tblItem AS I WHERE I.Name = @Name AND I.Description = @Description AND I.ItemType = @ItemType AND I.UnitType = @UnitType) > 1 BEGIN
        RETURN 1
    END

	RETURN 0

END
GO

ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_Exists CHECK
(dbo.fnIsItemDuplicate(Name, Description, ItemType, UnitType) = 0)
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_Exists
GO
