USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spLogin
	@Username NVARCHAR(16),
    @Password NVARCHAR(50),
	@DeviceInfo NVARCHAR(500)
AS
BEGIN

    IF dbo.fnGetLen(@Username) <= 3 BEGIN
        SELECT 'Failed' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Password) <= 5 BEGIN
        SELECT 'Failed' AS RES
        RETURN 0
    END
	
	if dbo.fnGetLen(@DeviceInfo) = 0 BEGIN
		SET @DeviceInfo = NULL
	END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY	
        IF dbo.fnLogin(@Username, @Password) = 1 BEGIN
            DECLARE @Inserted TABLE(SessionKey NVARCHAR(36))

            INSERT INTO tblSession
            (tblSession.UserID)
            OUTPUT INSERTED.SessionKey INTO @Inserted
            VALUES
            ((SELECT U.UserID FROM tblUser AS U WHERE U.Username = @Username))

            IF @@ROWCOUNT > 0 BEGIN
                DECLARE @Key NVARCHAR(36) = (SELECT SessionKey FROM @Inserted)
                DECLARE @Logged INTEGER
                EXECUTE @Logged = spInsertActivityLog @Key, 'Logged in.', @DeviceInfo
                IF @Logged = 1 BEGIN
                    COMMIT TRANSACTION @TransactionName
                    SELECT 'Successful' AS RES, @Key AS [KEY]
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
        PRINT ERROR_MESSAGE()
        SELECT ERROR_NUMBER() AS RES
	END CATCH

END
GO