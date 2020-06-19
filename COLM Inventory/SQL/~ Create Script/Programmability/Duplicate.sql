USE dbColmInventory
GO

ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_Exists
GO

CREATE FUNCTION fnIsCustomerDuplicate(@FirstName NVARCHAR(50), @MiddleName NVARCHAR(50), @LastName NVARCHAR(50), @Position NVARCHAR(50), @Department NVARCHAR(50)) RETURNS BIT
AS
BEGIN

    IF @MiddleName IS NULL BEGIN
        IF (SELECT ISNULL(COUNT(*), 0) FROM tblCustomer AS C WHERE C.FirstName = @FirstName AND C.MiddleName IS NULL AND C.LastName = @LastName AND C.Position = @Position AND C.Department = @Department) > 1 BEGIN
            RETURN 1
        END
    END
    ELSE BEGIN
        IF (SELECT ISNULL(COUNT(*), 0) FROM tblCustomer AS C WHERE C.FirstName = @FirstName AND C.MiddleName = @MiddleName AND C.LastName = @LastName AND C.Position = @Position AND C.Department = @Department) > 1 BEGIN
            RETURN 1
        END
    END

	RETURN 0

END
GO

ALTER TABLE tblCustomer WITH CHECK ADD CONSTRAINT CK_tblCustomer_Exists CHECK
(dbo.fnIsCustomerDuplicate(FirstName, MiddleName, LastName, Position, Department) = 0)
ALTER TABLE tblCustomer CHECK CONSTRAINT CK_tblCustomer_Exists
GO

--

ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Exists
GO

CREATE FUNCTION fnIsInventoryDuplicate(@ItemID INTEGER, @Information NVARCHAR(500), @Store NVARCHAR(120), @ReceiptNo NVARCHAR(50), @CostPerUnit DECIMAL(19, 2)) RETURNS BIT
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

--

ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_Exists
GO

CREATE FUNCTION fnIsItemDuplicate(@Name NVARCHAR(50), @Description NVARCHAR(50), @ItemType NVARCHAR(50), @UnitType NVARCHAR(50)) RETURNS BIT
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

--

ALTER TABLE tblReservation DROP CONSTRAINT CK_tblReservation_Exists
GO

CREATE FUNCTION fnIsReservationDuplicate(@ReservedBy INTEGER, @ItemID INTEGER, @DateNeeded DATETIME2(2)) RETURNS BIT
AS
BEGIN

    IF (SELECT ISNULL(COUNT(*), 0) FROM tblReservation AS R WHERE R.ReservedBy = @ReservedBy AND R.ItemID = @ItemID AND R.DateNeeded = @DateNeeded) > 1 BEGIN
        RETURN 1
    END

    RETURN 0

END
GO

ALTER TABLE tblReservation WITH CHECK ADD CONSTRAINT CK_tblReservation_Exists CHECK
(dbo.fnIsReservationDuplicate(ReservedBy, ItemID, DateNeeded) = 0)
ALTER TABLE tblReservation CHECK CONSTRAINT CK_tblReservation_Exists
GO
