USE dbColmInventory
GO

SET NOCOUNT ON
GO

CREATE FUNCTION fnAvailable(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

	RETURN dbo.fnGood(@ItemID) + dbo.fnDamaged(@ItemID)

END
GO

CREATE FUNCTION fnBorrowed(@ItemID INTEGER, @Status NVARCHAR(1)) RETURNS INTEGER
AS
BEGIN

	IF (SELECT I.ItemType FROM tblItem AS I WHERE I.ItemID = @ItemID) IN ('Asset', 'Asset - Bulk') BEGIN
		IF @Status = 'G' BEGIN
			RETURN (SELECT ISNULL(SUM(B.Good), 0) FROM tblBorrow AS B INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND B.InventoryID = I.InventoryID)
        END
        ELSE IF @Status = 'D' BEGIN
			RETURN (SELECT ISNULL(SUM(B.Damaged), 0) FROM tblBorrow AS B INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND B.InventoryID = I.InventoryID)
        END
	END

	RETURN 0

END
GO

CREATE FUNCTION fnConsumed(@ItemID INTEGER, @Status NVARCHAR(1)) RETURNS INTEGER
AS
BEGIN

	IF (SELECT I.ItemType FROM tblItem AS I WHERE I.ItemID = @ItemID) = 'Consumable' BEGIN
		IF @Status = 'G' BEGIN
			RETURN (SELECT ISNULL(SUM(C.Good), 0) FROM tblConsume AS C INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND C.InventoryID = I.InventoryID)
        END
        ELSE IF @Status = 'D' BEGIN
			RETURN (SELECT ISNULL(SUM(C.Damaged), 0) FROM tblConsume AS C INNER JOIN tblInventory AS I ON I.ItemID = @ItemID AND C.InventoryID = I.InventoryID)
        END
	END

	RETURN 0

END
GO

CREATE FUNCTION fnDamaged(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN (SELECT ISNULL(SUM(I.Damaged), 0) FROM tblInventory AS I WHERE I.ItemID = @ItemID)

END
GO

CREATE FUNCTION fnGood(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN (SELECT ISNULL(SUM(I.Good), 0) FROM tblInventory AS I WHERE I.ItemID = @ItemID)

END
GO

CREATE FUNCTION fnMaintenance(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN (SELECT ISNULL(SUM(I.Maintenance), 0) FROM tblInventory AS I WHERE I.ItemID = @ItemID)

END
GO

CREATE FUNCTION fnReplacement(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN (SELECT ISNULL(SUM(I.Replacement), 0) FROM tblInventory AS I WHERE I.ItemID = @ItemID)

END
GO

CREATE FUNCTION fnReserved(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

	RETURN (SELECT ISNULL(SUM(R.QuantityNeeded), 0) FROM tblReservation AS R WHERE R.ItemID = @ItemID AND GETDATE() <= DATEADD(MINUTE, 15, R.DateNeeded))

END
GO

CREATE FUNCTION fnStationed(@ItemID INTEGER, @Status NVARCHAR(1)) RETURNS INTEGER
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

CREATE FUNCTION fnTotal(@ItemID INTEGER) RETURNS INTEGER
AS
BEGIN

    RETURN dbo.fnGood(@ItemID) +
           dbo.fnDamaged(@ItemID) +
           dbo.fnMaintenance(@ItemID) +
           dbo.fnReplacement(@ItemID)

END
GO
