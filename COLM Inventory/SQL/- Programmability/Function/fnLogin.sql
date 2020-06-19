USE dbColmInventory
GO

ALTER FUNCTION fnLogin(@Username NVARCHAR(16), @Password NVARCHAR(50)) RETURNS BIT
BEGIN
    
	DECLARE @D AS DATETIME = GETDATE();
	WHILE DATEDIFF(MILLISECOND, @D, GETDATE()) <= 1000 BEGIN
		CONTINUE;
	END

    DECLARE @SaltedPassword NVARCHAR(100) = CONCAT((SELECT U.UserID FROM tblUser AS U WHERE U.Username = @Username AND U.Active = 1), @Password)
    DECLARE @DBPassword NVARCHAR(100) = DECRYPTBYPASSPHRASE(@SaltedPassword, (SELECT U.Password FROM tblUser AS U WHERE U.Username = @Username))
    IF (@SaltedPassword <> @DBPassword AND @DBPassword = '') OR @DBPassword IS NULL BEGIN
		RETURN 0
	END

    RETURN 1

END
GO
