USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertUser
	@Key NVARCHAR(36),
	@Username VARCHAR(16),
	@Password NVARCHAR(50),
	@PermissionName NVARCHAR(50)
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'User') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Username) <= 3 BEGIN
		SELECT 'Username' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Password) <= 5 BEGIN
		SELECT 'Password' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
		SELECT 'FK_tblItem_PermissionName' AS RES
        RETURN 0
    END

    DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
    BEGIN TRANSACTION @TransactionName
    BEGIN TRY
        DECLARE @Inserted TABLE(UserID INTEGER)
	    DECLARE @EncryptedPassword VARBINARY(256) = ENCRYPTBYPASSPHRASE('temp', 'temp')

        INSERT INTO tblUser
        (tblUser.Username,
        tblUser.Password,
        tblUser.PermissionName)
        OUTPUT INSERTED.UserID INTO @Inserted
        VALUES
        (@Username,
        @EncryptedPassword,
        @PermissionName)

        IF @@ROWCOUNT > 0 BEGIN
            DECLARE @SaltedPassword NVARCHAR(100) = CONCAT((SELECT UserID FROM @Inserted), @Password)
            SET @EncryptedPassword = ENCRYPTBYPASSPHRASE(@SaltedPassword, @SaltedPassword)

            UPDATE tblUser
            SET tblUser.Password = @EncryptedPassword
            WHERE tblUser.UserID = (SELECT UserID FROM @Inserted)

            IF @@ROWCOUNT > 0 BEGIN
                DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
                'UserID:', (SELECT UserID FROM @Inserted), CHAR(13), CHAR(10),
                'Username:', @Username, CHAR(13), CHAR(10),
                'PermissionName:', @PermissionName)

                DECLARE @Logged INTEGER
                EXECUTE @Logged = spInsertActivityLog @Key, 'Added a user.', @LogDetails
                IF @Logged = 0 BEGIN
                    ROLLBACK TRANSACTION @TransactionName
	                SELECT 'Failed' AS RES
                    RETURN 0
                END
                ELSE BEGIN
                    COMMIT TRANSACTION @TransactionName
                    SELECT 'Successful' AS RES, @LogDetails AS LOG
                    RETURN 0
                END
            END
        END

        ROLLBACK TRANSACTION @TransactionName
	    SELECT 'Failed' AS RES
        RETURN 0
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @TransactionName

        DECLARE @M NVARCHAR(200) = ERROR_MESSAGE()
        PRINT @M

        IF ERROR_NUMBER() = 515 BEGIN
            SET @M = SUBSTRING(@M, CHARINDEX('''', @M) + 1, 200)
            SET @M = SUBSTRING(@M, 0, CHARINDEX('''', @M))
            SELECT @M AS RES
            RETURN 0
        END
        ELSE IF ERROR_NUMBER() = 547 BEGIN
            SET @M = SUBSTRING(@M, CHARINDEX('"', @M) + 1, 200)
            SET @M = SUBSTRING(@M, 0, CHARINDEX('"', @M))
            SELECT REPLACE(@M, 'CK_tblUser_', '') AS RES
            RETURN 0
        END

        IF ERROR_NUMBER() = 2627 BEGIN
            SELECT 'Exists' AS RES
            RETURN 0
        END

        SELECT ERROR_NUMBER() AS RES
	END CATCH

END
GO
