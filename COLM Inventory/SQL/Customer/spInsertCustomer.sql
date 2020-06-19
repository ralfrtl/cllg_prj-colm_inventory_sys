USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertCustomer
    @Key NVARCHAR(36),
	@FirstName NVARCHAR(50),
	@MiddleName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Position NVARCHAR(50),
	@Department NVARCHAR(50)
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Customer') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@FirstName) = 0 BEGIN
        SELECT 'FirstName' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@LastName) = 0 BEGIN
        SELECT 'LastName' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Position) = 0 BEGIN
        SELECT 'Position' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Department) = 0 BEGIN
        SELECT 'Department' AS RES
        RETURN 0
    END

	IF dbo.fnGetLen(@MiddleName) = 0 BEGIN
		SET @MiddleName = ''
	END
	
	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DECLARE @Inserted TABLE(CustomerID INTEGER)

		INSERT tblCustomer
		(tblCustomer.FirstName,
		tblCustomer.MiddleName,
		tblCustomer.LastName,
		tblCustomer.Position,
		tblCustomer.Department)
		OUTPUT INSERTED.CustomerID INTO @Inserted
		VALUES
		(@FirstName,
		@MiddleName,
		@LastName,
		@Position,
		@Department)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'CustomerID:',(SELECT CustomerID FROM @Inserted),CHAR(13),CHAR(10),
			'FirstName:',@FirstName,CHAR(13),CHAR(10),
			'MiddleName:',@MiddleName,CHAR(13),CHAR(10),
			'LastName:',@LastName,CHAR(13),CHAR(10),
			'Position:',@Position,CHAR(13),CHAR(10),
			'Department:',@Department)
			
            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added a customer.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblCustomer_', '') AS RES
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