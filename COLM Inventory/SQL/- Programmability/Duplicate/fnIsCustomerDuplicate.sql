USE dbColmInventory
GO

ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_Exists
GO

ALTER FUNCTION fnIsCustomerDuplicate(@FirstName NVARCHAR(50), @MiddleName NVARCHAR(50), @LastName NVARCHAR(50), @Position NVARCHAR(50), @Department NVARCHAR(50)) RETURNS BIT
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
