USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spUpdatePermission
    @Key NVARCHAR(36),
	@PermissionName NVARCHAR(50),
	@NewPermissionName NVARCHAR(50),
	@AccessUser BIT,
	@AccessPermission BIT,
	@AccessCustomer BIT,
	@AccessItem BIT,
	@AccessInventory BIT,
	@AccessReservation BIT,
	@AccessConsume BIT,
	@AccessBorrow BIT,
	@AccessStation BIT
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Permission') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@NewPermissionName) = 0 BEGIN
        SELECT 'PermissionName' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		UPDATE tblPermission
		SET
		tblPermission.PermissionName = @NewPermissionName,
		tblPermission.AccessUser = @AccessUser,
		tblPermission.AccessPermission = @AccessPermission,
		tblPermission.AccessCustomer = @AccessCustomer,
		tblPermission.AccessItem = @AccessItem,
		tblPermission.AccessInventory = @AccessInventory,
		tblPermission.AccessReservation = @AccessReservation,
		tblPermission.AccessConsume = @AccessConsume,
		tblPermission.AccessBorrow = @AccessBorrow,
		tblPermission.AccessStation = @AccessStation
		WHERE tblPermission.PermissionName = @PermissionName

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'PermissionName:',@PermissionName,CHAR(13),CHAR(10),
			'NewPermissionName:',@NewPermissionName,CHAR(13),CHAR(10),
			'AccessUser:',@AccessUser,CHAR(13),CHAR(10),
			'AccessPermission:',@AccessPermission,CHAR(13),CHAR(10),
			'AccessCustomer:',@AccessCustomer,CHAR(13),CHAR(10),
			'AccessItem:',@AccessItem,CHAR(13),CHAR(10),
			'AccessInventory:',@AccessInventory,CHAR(13),CHAR(10),
			'AccessReservation:',@AccessReservation,CHAR(13),CHAR(10),
			'AccessConsume:',@AccessConsume,CHAR(13),CHAR(10),
			'AccessBorrow:',@AccessBorrow,CHAR(13),CHAR(10),
			'AccessStation:',@AccessStation)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a permission.', @LogDetails
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

        ROLLBACK TRANSACTION @TransactionName
	    SELECT 'Not Exists' AS RES
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
            SELECT REPLACE(@M, 'CK_tblPermission_', '') AS RES
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
