USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spDeletePermission
    @Key NVARCHAR(36),
	@PermissionName NVARCHAR(50)
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
	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DELETE FROM tblPermission WHERE tblPermission.PermissionName = @PermissionName
	
		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'PermissionName:',@PermissionName)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed a permission.', @LogDetails
            IF @Logged = 0 BEGIN
                ROLLBACK TRANSACTION @TransactionName
	            SELECT 'Failed' AS RES
                RETURN 0
            END
            ELSE BEGIN
                COMMIT TRANSACTION @TransactionName
                SELECT 'Successful' AS RES
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