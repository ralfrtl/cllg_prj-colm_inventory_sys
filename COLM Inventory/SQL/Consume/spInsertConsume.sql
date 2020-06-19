USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertConsume
    @Key NVARCHAR(36),
	@CustomerID INTEGER,
	@InventoryID INTEGER,
	@Good INTEGER,
    @Damaged INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Consume') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'FK_tblConsume_CustomerID' AS RES
        RETURN 0
    END
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'FK_tblConsume_InventoryID' AS RES
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
		DECLARE @Inserted TABLE(ConsumeID INTEGER)

		INSERT INTO tblConsume
		(tblConsume.CustomerID,
		tblConsume.InventoryID,
		tblConsume.Good,
		tblConsume.Damaged)
		OUTPUT INSERTED.ConsumeID INTO @Inserted
		VALUES
		(@CustomerID,
		@InventoryID,
		@Good,
		@Damaged)
		
		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ConsumeID:',(SELECT ConsumeID FROM @Inserted),CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(13),CHAR(10),
			'Good:',@Good,CHAR(13),CHAR(10),
			'Damaged:',@Damaged)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Consumed an inventory.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblConsume_', '') AS RES
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