USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spUpdateInventory
    @Key NVARCHAR(36),
	@ItemID INTEGER,
	@InventoryID INTEGER,
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
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
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

	IF dbo.fnGetItemType(@InventoryID) = 'Consumable' BEGIN
		SET @Maintenance = 0
	END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DECLARE @Updated Table(Good INTEGER, Damaged INTEGER, Maintenance INTEGER, Replacement INTEGER)

		UPDATE tblInventory
		SET
		tblInventory.ItemID = @ItemID,
		tblInventory.Information = @Information,
		tblInventory.Store = @Store,
		tblInventory.ReceiptNo = @ReceiptNo,
		tblInventory.DateReceived = @DateReceived,
		tblInventory.CostPerUnit = @CostPerUnit,
		tblInventory.Good = @Good,
		tblInventory.Damaged = @Damaged,
		tblInventory.Maintenance = @Maintenance,
		tblInventory.Replacement = @Replacement
		OUTPUT DELETED.Good, DELETED.Damaged, DELETED.Maintenance, DELETED.Replacement INTO @Updated
		WHERE tblInventory.InventoryID = @InventoryID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ItemID:',@ItemID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(10),
			'Information:',@Information,CHAR(13),CHAR(10),
			'Store:',@Store,CHAR(13),CHAR(10),
			'ReceiptNo:',@ReceiptNo,CHAR(13),CHAR(10),
			'DateReceived:',@DateReceived,CHAR(13),CHAR(10),
			'CostPerUnit:',@CostPerUnit,CHAR(13),CHAR(10),
			'Good:',IIF((SELECT @Good - ISNULL(Good, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Good - ISNULL(Good, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Damaged:',IIF((SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Maintenance:',IIF((SELECT @Maintenance - ISNULL(Maintenance, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Maintenance - ISNULL(Maintenance, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Replacement:',IIF((SELECT @Replacement - ISNULL(Replacement, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Replacement - ISNULL(Replacement, 0) FROM @Updated))
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified an inventory.', @LogDetails
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
