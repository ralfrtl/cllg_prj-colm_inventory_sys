USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spDeleteItem
    @Key NVARCHAR(36),
	@LogPassword NVARCHAR(50),
	@ItemID INTEGER
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
	IF dbo.fnLogin((SELECT U.Username FROM tblSession AS S INNER JOIN tblUser AS U ON U.UserID = S.UserID AND S.SessionKey = @Key), @LogPassword) = 0 BEGIN
		SELECT 'LogPassword' AS RES
        RETURN 0
	END
	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY	
		DELETE FROM tblItem WHERE tblItem.ItemID = @ItemID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ItemID:',@ItemID)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed an item.', @LogDetails
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
        PRINT ERROR_MESSAGE()
        SELECT ERROR_NUMBER() AS RES
	END CATCH

END
GO
