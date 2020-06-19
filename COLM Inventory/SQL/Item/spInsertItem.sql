USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertItem
    @Key NVARCHAR(36),
    @Name NVARCHAR(50),
    @Description NVARCHAR(120),
    @ItemType NVARCHAR(50),
    @UnitType NVARCHAR(50),
    @LowThreshold INTEGER
AS
BEGIN
    
    IF dbo.fnIsKeyPermitted(@Key, 'Item') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Name) = 0 BEGIN
        SELECT 'Name' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Description) = 0 BEGIN
        SELECT 'Description' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@ItemType) = 0 BEGIN
        SELECT 'ItemType' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@UnitType) = 0 BEGIN
        SELECT 'UnitType' AS RES
        RETURN 0
    END
    IF ISNULL(@LowThreshold, -1) < 0 BEGIN
        SELECT 'LowThreshold' AS RES
        RETURN 0
    END
    
    DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
    BEGIN TRANSACTION @TransactionName
    BEGIN TRY
		DECLARE @Inserted TABLE(ItemID INTEGER)
        
		INSERT INTO tblItem
        (tblItem.Name,
        tblItem.Description,
        tblItem.ItemType,
        tblItem.UnitType,
        tblItem.LowThreshold)
        OUTPUT INSERTED.ItemID INTO @Inserted
        VALUES
        (@Name,
        @Description,
        @ItemType,
        @UnitType,
        @LowThreshold)

		IF @@ROWCOUNT > 0 BEGIN
            DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
            'ItemID:',(SELECT ItemID FROM @Inserted),CHAR(13),CHAR(10),
            'Name:',@Name,CHAR(13),CHAR(10),
            'Description:',@Description,CHAR(13),CHAR(10),
            'ItemType:',@ItemType,CHAR(13),CHAR(10),
            'UnitType:',@UnitType,CHAR(13),CHAR(10),
            'LowThreshold:',@LowThreshold)
            
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added an item.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblItem_', '') AS RES
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
