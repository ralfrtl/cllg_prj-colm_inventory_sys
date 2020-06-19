USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spDeleteInventory
    @Key NVARCHAR(36),
	@InventoryID INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Inventory') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DELETE FROM tblInventory WHERE tblInventory.InventoryID = @InventoryID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'InventoryID:',@InventoryID)
            
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed an inventory.', @LogDetails
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