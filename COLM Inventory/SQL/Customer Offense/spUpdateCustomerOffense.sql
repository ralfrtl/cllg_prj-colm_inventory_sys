USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spUpdateCustomerOffense
    @Key NVARCHAR(36),
	@OffenseID INTEGER,
	@CustomerID INTEGER,
	@Information NVARCHAR(120),
	@Settled BIT
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Customer') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@OffenseID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'FK_tblCustomerOffense_CustomerID' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Information) = 0 BEGIN
        SELECT 'Information' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		UPDATE tblCustomerOffense
		SET
		tblCustomerOffense.CustomerID = @CustomerID,
		tblCustomerOffense.Information = @Information,
		tblCustomerOffense.Settled = @Settled
		WHERE tblCustomerOffense.OffenseID = @OffenseID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'OffenseID:',@OffenseID,CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'Settled:',IIF(@Settled = 0, 'False', 'True'),CHAR(13),CHAR(10),
			'Information:',@Information)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a customer offense.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblCustomerOffense_', '') AS RES
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
