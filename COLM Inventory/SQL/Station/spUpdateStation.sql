USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spUpdateStation
    @Key NVARCHAR(36),
    @StationID INTEGER,
	@CustomerID INTEGER,
	@InventoryID INTEGER,
	@Location NVARCHAR(120),
	@Good INTEGER,
    @Damaged INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Station') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@StationID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'FK_tblStation_CustomerID' AS RES
        RETURN 0
    END
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'FK_tblStation_InventoryID' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Location) = 0 BEGIN
        SELECT 'Location' AS RES
        RETURN 0
    END
    IF ISNULL(@Good, -1) < 0 BEGIN
        SELECT 'Good' AS RES
        RETURN 0
    END
    IF ISNULL(@Damaged, -1) < 0 BEGIN
        SELECT 'Damaged' AS RES
        RETURN 0
    END
		
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
        DECLARE @Updated TABLE(Good INTEGER, Damaged INTEGER)

		UPDATE tblStation
		SET
		tblStation.CustomerID = @CustomerID,
        tblStation.InventoryID = @InventoryID,
        tblStation.Location = @Location,
        tblStation.Good = @Good,
        tblStation.Damaged = @Damaged
        OUTPUT DELETED.Good, DELETED.Damaged INTO @Updated
		WHERE tblStation.StationID = @StationID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'StationID:',@StationID,CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'Good:',IIF((SELECT @Good - ISNULL(Good, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Good - ISNULL(Good, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Damaged:',IIF((SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated))
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a stationed inventory.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblStation_', '') AS RES
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