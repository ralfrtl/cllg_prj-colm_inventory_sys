    USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertInventory
    @Key NVARCHAR(36),
	@ItemID INTEGER,
	@Information NVARCHAR(500),
	@Store NVARCHAR(120),
	@ReceiptNo NVARCHAR(50),
	@DateReceived DATETIME2(2),
	@CostPerUnit DECIMAL(19,2),
	@Good INTEGER,
	@Damaged INTEGER,
	@Maintenance INTEGER,
	@Replacement INTEGER
AS
BEGIN

    SET @DateReceived = ISNULL(@DateReceived, '')

    IF dbo.fnIsKeyPermitted(@Key, 'Inventory') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@ItemID, -1) <= 0 BEGIN
        SELECT 'FK_tblInventory_ItemID' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Information) = 0 BEGIN
        SELECT 'Information' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Store) = 0 BEGIN
        SELECT 'Store' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@ReceiptNo) = 0 BEGIN
        SELECT 'ReceiptNo' AS RES
        RETURN 0
    END
    IF ISNULL(@CostPerUnit, -1) < 0 BEGIN
        SELECT 'CostPerUnit' AS RES
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
    IF ISNULL(@Maintenance, -1) < 0 BEGIN
        SELECT 'Maintenance' AS RES
        RETURN 0
    END
    IF ISNULL(@Replacement, -1) < 0 BEGIN
        SELECT 'Replacement' AS RES
        RETURN 0
    END

    IF dbo.fnGetItemTypeByItemID(@ItemID) = 'Consumable' BEGIN
		SET @Maintenance = 0
	END
	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DECLARE @Inserted TABLE(InventoryID INTEGER)

		INSERT INTO tblInventory
		(tblInventory.ItemID,
		tblInventory.Information,
		tblInventory.Store,
		tblInventory.ReceiptNo,
		tblInventory.DateReceived,
		tblInventory.CostPerUnit,
		tblInventory.Good,
		tblInventory.Damaged,
		tblInventory.Maintenance,
		tblInventory.Replacement)
		OUTPUT INSERTED.InventoryID INTO @Inserted
		VALUES
		(@ItemID,
		@Information,
        @Store,
		@ReceiptNo,
		@DateReceived,
		@CostPerUnit,
		@Good,
		@Damaged,
		@Maintenance,
		@Replacement)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ItemID:',@ItemID,CHAR(13),CHAR(10),
			'InventoryID:',(SELECT InventoryID FROM @Inserted),CHAR(13),CHAR(10),
			'Information:',@Information,CHAR(13),CHAR(10),
			'Store:',@Store,CHAR(13),CHAR(10),
			'ReceiptNo:',@ReceiptNo,CHAR(13),CHAR(10),
			'DateReceived:',@DateReceived,CHAR(13),CHAR(10),
			'CostPerUnit:',@CostPerUnit,CHAR(13),CHAR(10),
			'Good:',@Good,CHAR(13),CHAR(10),
			'Damaged:',@Damaged,CHAR(13),CHAR(10),
			'Maintenance:',@Maintenance,CHAR(13),CHAR(10),
			'Replacement:',@Replacement)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added an inventory.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblInventory_', '') AS RES
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
