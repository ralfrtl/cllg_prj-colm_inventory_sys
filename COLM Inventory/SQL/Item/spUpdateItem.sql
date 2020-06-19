USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spUpdateItem
    @Key NVARCHAR(36),
	@LogPassword NVARCHAR(50),
	@ItemID INTEGER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(120),
	@ItemType NVARCHAR(50),
	@UnitType NVARCHAR(50),
	@LowThreshold INTEGER
AS
BEGIN

    IF dbo.fnIskeyPermitted(@key, 'Item') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@ItemID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
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
	IF dbo.fnGetItemTypeByItemID(@ItemID) <> @ItemType BEGIN
	    IF dbo.fnLogin((SELECT U.Username FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @Key AND U.UserID = S.UserID), @LogPassword) = 0 BEGIN
		    SELECT 'LogPassword' AS RES
            RETURN 0
	    END
	END
    	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DECLARE @Updated Table(LowThreshold INTEGER)

		UPDATE tblItem
		SET
		tblItem.Name = @Name,
		tblItem.Description = @Description,
		tblItem.ItemType = @ItemType,
		tblItem.UnitType = @UnitType,
		tblItem.LowThreshold = @LowThreshold
		OUTPUT DELETED.LowThreshold INTO @Updated
		WHERE tblItem.ItemID = @ItemID
        
		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ItemID:',@ItemID,CHAR(13),CHAR(10),
			'Name:',@Name,CHAR(13),CHAR(10),
			'Description:',@Description,CHAR(13),CHAR(10),
			'ItemType:',@ItemType,CHAR(13),CHAR(10),
			'UnitType:',@UnitType,CHAR(13),CHAR(10),
			'LowThreshold:', IIF((SELECT @LowThreshold - ISNULL(LowThreshold, 0) FROM @Updated) >= 0, '+', ''),(SELECT @LowThreshold - ISNULL(LowThreshold, 0) FROM @Updated))
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified an item.', @LogDetails
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
