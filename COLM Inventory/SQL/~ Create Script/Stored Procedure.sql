USE dbColmInventory
GO

SET NOCOUNT ON
GO

CREATE PROCEDURE spInsertActivityLog
	@Key NVARCHAR(36),
	@Activity NVARCHAR(50),
	@Details NVARCHAR(3000)
AS
BEGIN

    IF dbo.fnGetLen(@Key) = 0 BEGIN
        RETURN 0
    END
    IF dbo.fnGetLen(@Activity) = 0 BEGIN
        RETURN 0
    END
	IF dbo.fnGetLen(@Details) = 0 BEGIN
		SET @Details = NULL
	END

    BEGIN TRY
        DECLARE @UserID INTEGER = (SELECT S.UserID FROM tblSession AS S WHERE S.SessionKey = @Key)

        INSERT INTO tblActivityLog
        (tblActivityLog.UserID,
	    tblActivityLog.Activity,
	    tblActivityLog.Details)
	    VALUES
	    (@UserID,
	    @Activity,
	    @Details)

		IF @@ROWCOUNT > 0 BEGIN
            PRINT 'Logged.'
            RETURN 1
        END

        RETURN 0
    END TRY
    BEGIN CATCH
  	    RETURN 0
    END CATCH

END
GO

--

CREATE PROCEDURE spInsertBorrow
    @Key NVARCHAR(36),
	@CustomerID INTEGER,
	@InventoryID INTEGER,
	@Good INTEGER,
    @Damaged INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Borrow') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'FK_tblBorrow_CustomerID' AS RES
        RETURN 0
    END
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'FK_tblBorrow_InventoryID' AS RES
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
		DECLARE @Inserted TABLE(BorrowID INTEGER)

		INSERT INTO tblBorrow
		(tblBorrow.CustomerID,
		tblBorrow.InventoryID,
		tblBorrow.Good,
		tblBorrow.Damaged)
		OUTPUT INSERTED.BorrowID INTO @Inserted
		VALUES
		(@CustomerID,
		@InventoryID,
		@Good,
		@Damaged)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'BorrowID:',(SELECT BorrowID FROM @Inserted),CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(13),CHAR(10),
			'Good:',@Good,CHAR(13),CHAR(10),
			'Damaged:',@Damaged)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Borrowed an inventory.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblBorrow_', '') AS RES
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

--

CREATE PROCEDURE spUpdateBorrow
    @Key NVARCHAR(36),
	@BorrowID INTEGER,
	@CustomerID INTEGER,
	@InventoryID INTEGER,
	@Good INTEGER,
    @Damaged INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Borrow') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@BorrowID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'FK_tblBorrow_CustomerID' AS RES
        RETURN 0
    END
    IF ISNULL(@InventoryID, -1) <= 0 BEGIN
        SELECT 'FK_tblBorrow_InventoryID' AS RES
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

		UPDATE tblBorrow
		SET
		tblBorrow.CustomerID = @CustomerID,
		tblBorrow.InventoryID = @InventoryID,
		tblBorrow.Good = @Good,
		tblBorrow.Damaged = @Damaged
        OUTPUT DELETED.Good, DELETED.Damaged INTO @Updated
		WHERE tblBorrow.BorrowID = @BorrowID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'BorrowID:',@BorrowID,CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(13),CHAR(10),
			'Good:',IIF((SELECT @Good - ISNULL(Good, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Good - ISNULL(Good, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Damaged:',IIF((SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated))

            DECLARE @Logged INTEGER
			EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a borrowed inventory.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblBorrow_', '') AS RES
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

--

CREATE PROCEDURE spInsertConsume
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

--

CREATE PROCEDURE spUpdateConsume
    @Key NVARCHAR(36),
	@ConsumeID INTEGER,
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
    IF ISNULL(@ConsumeID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
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
        DECLARE @Updated TABLE(Good INTEGER, Damaged INTEGER)

		UPDATE tblConsume
		SET
		tblConsume.CustomerID = @CustomerID,
		tblConsume.InventoryID = @InventoryID,
		tblConsume.Good = @Good,
		tblConsume.Damaged = @Damaged
        OUTPUT DELETED.Good, DELETED.Damaged INTO @Updated
		WHERE tblConsume.ConsumeID = @ConsumeID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ConsumeID:',@ConsumeID,CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(13),CHAR(10),
			'Good:',IIF((SELECT @Good - ISNULL(Good, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Good - ISNULL(Good, 0) FROM @Updated),CHAR(13),CHAR(10),
			'Damaged:',IIF((SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated) >= 0, '+', ''),(SELECT @Damaged - ISNULL(Damaged, 0) FROM @Updated))

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a consumed inventory.', @LogDetails
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

--

CREATE PROCEDURE spInsertCustomer
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

--

CREATE PROCEDURE spUpdateCustomer
    @Key NVARCHAR(36),
    @CustomerID INTEGER,
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
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
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
		UPDATE tblCustomer
		SET
		tblCustomer.FirstName = @FirstName,
		tblCustomer.MiddleName = @MiddleName,
		tblCustomer.LastName = @LastName,
		tblCustomer.Position = @Position,
		tblCustomer.Department = @Department
		WHERE tblCustomer.CustomerID = @CustomerID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'FirstName:',@FirstName,CHAR(13),CHAR(10),
			'MiddleName:',@MiddleName,CHAR(13),CHAR(10),
			'LastName:',@LastName,CHAR(13),CHAR(10),
			'Position:',@Position,CHAR(13),CHAR(10),
			'Department:',@Department)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a customer.', @LogDetails
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

--

CREATE PROCEDURE spDeleteCustomer
    @Key NVARCHAR(36),
    @CustomerID INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Customer') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@CustomerID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DELETE FROM tblCustomer WHERE tblCustomer.CustomerID = @CustomerID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'CustomerID:',@CustomerID)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed a customer.', @LogDetails
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

--

CREATE PROCEDURE spInsertCustomerOffense
    @Key NVARCHAR(36),
	@CustomerID INTEGER,
	@Information NVARCHAR(120)
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Customer') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
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
		DECLARE @Inserted TABLE(OffenseID INTEGER)

		INSERT tblCustomerOffense
		(tblCustomerOffense.CustomerID,
		tblCustomerOffense.Information)
		OUTPUT INSERTED.OffenseID INTO @Inserted
		VALUES
		(@CustomerID,
		@Information)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'OffenseID:',(SELECT OffenseID FROM @Inserted),CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'Information:',@Information)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added a customer offense.', @LogDetails
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

--

CREATE PROCEDURE spUpdateCustomerOffense
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

--

CREATE PROCEDURE spInsertInventory
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

--

CREATE PROCEDURE spUpdateInventory
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

--

CREATE PROCEDURE spDeleteInventory
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

--

CREATE PROCEDURE spInsertItem
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

--

CREATE PROCEDURE spUpdateItem
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

--

CREATE PROCEDURE spDeleteItem
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

--

CREATE PROCEDURE spInsertPermission
    @Key NVARCHAR(36),
	@PermissionName NVARCHAR(50),
	@AccessUser BIT = 0,
	@AccessPermission BIT = 0,
	@AccessCustomer BIT = 0,
	@AccessItem BIT = 0,
	@AccessInventory BIT = 0,
	@AccessReservation BIT = 0,
	@AccessConsume BIT = 0,
	@AccessBorrow BIT = 0,
	@AccessStation BIT = 0
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Permission') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
        SELECT 'PermissionName' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		INSERT INTO tblPermission
		(tblPermission.PermissionName,
		tblPermission.AccessUser,
		tblPermission.AccessPermission,
		tblPermission.AccessCustomer,
		tblPermission.AccessItem,
		tblPermission.AccessInventory,
		tblPermission.AccessReservation,
		tblPermission.AccessConsume,
		tblPermission.AccessBorrow,
		tblPermission.AccessStation)
		VALUES
		(@PermissionName,
		@AccessUser,
		@AccessPermission,
		@AccessCustomer,
		@AccessItem,
		@AccessInventory,
		@AccessReservation,
		@AccessConsume,
		@AccessBorrow,
		@AccessStation)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'PermissionName:',@PermissionName,CHAR(13),CHAR(10),
			'AccessUser:',@AccessUser,CHAR(13),CHAR(10),
			'AccessPermission:',@AccessPermission,CHAR(13),CHAR(10),
			'AccessCustomer:',@AccessCustomer,CHAR(13),CHAR(10),
			'AccessItem:',@AccessItem,CHAR(13),CHAR(10),
			'AccessInventory:',@AccessInventory,CHAR(13),CHAR(10),
			'AccessReservation:',@AccessReservation, CHAR(13), CHAR(10),
			'AccessConsume:',@AccessConsume,CHAR(13),CHAR(10),
			'AccessBorrow:',@AccessBorrow,CHAR(13),CHAR(10),
			'AccessStation:',@AccessStation)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added a permission.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblPermission_', '') AS RES
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

--

CREATE PROCEDURE spUpdatePermission
    @Key NVARCHAR(36),
	@PermissionName NVARCHAR(50),
	@NewPermissionName NVARCHAR(50),
	@AccessUser BIT,
	@AccessPermission BIT,
	@AccessCustomer BIT,
	@AccessItem BIT,
	@AccessInventory BIT,
	@AccessReservation BIT,
	@AccessConsume BIT,
	@AccessBorrow BIT,
	@AccessStation BIT
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Permission') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@NewPermissionName) = 0 BEGIN
        SELECT 'PermissionName' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		UPDATE tblPermission
		SET
		tblPermission.PermissionName = @NewPermissionName,
		tblPermission.AccessUser = @AccessUser,
		tblPermission.AccessPermission = @AccessPermission,
		tblPermission.AccessCustomer = @AccessCustomer,
		tblPermission.AccessItem = @AccessItem,
		tblPermission.AccessInventory = @AccessInventory,
		tblPermission.AccessReservation = @AccessReservation,
		tblPermission.AccessConsume = @AccessConsume,
		tblPermission.AccessBorrow = @AccessBorrow,
		tblPermission.AccessStation = @AccessStation
		WHERE tblPermission.PermissionName = @PermissionName

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'PermissionName:',@PermissionName,CHAR(13),CHAR(10),
			'NewPermissionName:',@NewPermissionName,CHAR(13),CHAR(10),
			'AccessUser:',@AccessUser,CHAR(13),CHAR(10),
			'AccessPermission:',@AccessPermission,CHAR(13),CHAR(10),
			'AccessCustomer:',@AccessCustomer,CHAR(13),CHAR(10),
			'AccessItem:',@AccessItem,CHAR(13),CHAR(10),
			'AccessInventory:',@AccessInventory,CHAR(13),CHAR(10),
			'AccessReservation:',@AccessReservation,CHAR(13),CHAR(10),
			'AccessConsume:',@AccessConsume,CHAR(13),CHAR(10),
			'AccessBorrow:',@AccessBorrow,CHAR(13),CHAR(10),
			'AccessStation:',@AccessStation)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a permission.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblPermission_', '') AS RES
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

--

CREATE PROCEDURE spDeletePermission
    @Key NVARCHAR(36),
	@PermissionName NVARCHAR(50)
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Permission') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DELETE FROM tblPermission WHERE tblPermission.PermissionName = @PermissionName

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'PermissionName:',@PermissionName)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed a permission.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblPermission_', '') AS RES
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

--

CREATE PROCEDURE spInsertReservation
    @Key NVARCHAR(36),
	@ReservedBy INTEGER,
	@ItemID INTEGER,
	@QuantityNeeded INTEGER,
	@DateNeeded DATETIME2(2)
AS
BEGIN

    SET @DateNeeded = ISNULL(@DateNeeded, '')

    IF dbo.fnIsKeyPermitted(@Key, 'Reservation') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@ReservedBy, -1) <= 0 BEGIN
        SELECT 'FK_tblReservation_ReservedBy' AS RES
        RETURN 0
    END
    IF ISNULL(@ItemID, -1) <= 0 BEGIN
        SELECT 'FK_tblReservation_ItemID' AS RES
        RETURN 0
    END
    IF ISNULL(@QuantityNeeded, -1) < 0 BEGIN
        SELECT 'QuantityNeeded' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DECLARE @Inserted TABLE(ReservationID INTEGER)

		INSERT INTO tblReservation
		(tblReservation.ReservedBy,
		tblReservation.ItemID,
		tblReservation.QuantityNeeded,
		tblReservation.DateNeeded)
		OUTPUT INSERTED.ReservationID INTO @Inserted
		VALUES
		(@ReservedBy,
		@ItemID,
		@QuantityNeeded,
		@DateNeeded)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ReservationID:',(SELECT ReservationID FROM @Inserted),CHAR(13),CHAR(10),
			'ReservedBy:',@ReservedBy,CHAR(13),CHAR(10),
			'ItemID:',@ItemID,CHAR(13),CHAR(10),
			'QuantityNeeded:',@QuantityNeeded,CHAR(13),CHAR(10),
			'DateNeeded:',@DateNeeded)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Added an item reservation.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblReservation_', '') AS RES
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

--

CREATE PROCEDURE spUpdateReservation
    @Key NVARCHAR(36),
    @ReservationID INTEGER,
	@ReservedBy INTEGER,
	@ItemID INTEGER,
	@QuantityNeeded INTEGER,
	@DateNeeded DATETIME2(2)
AS
BEGIN

    SET @DateNeeded = ISNULL(@DateNeeded, '')

    IF dbo.fnIsKeyPermitted(@Key, 'Reservation') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@ReservationID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF ISNULL(@ReservedBy, -1) <= 0 BEGIN
        SELECT 'FK_tblReservation_ReservedBy' AS RES
        RETURN 0
    END
    IF ISNULL(@ItemID, -1) <= 0 BEGIN
        SELECT 'FK_tblReservation_ItemID' AS RES
        RETURN 0
    END
    IF ISNULL(@QuantityNeeded, -1) < 0 BEGIN
        SELECT 'QuantityNeeded' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
        DECLARE @Updated TABLE(QuantityNeeded INTEGER)

		UPDATE tblReservation
		SET
		tblReservation.ReservedBy = @ReservedBy,
		tblReservation.ItemID = @ItemID,
		tblReservation.QuantityNeeded = @QuantityNeeded,
		tblReservation.DateNeeded = @DateNeeded
		OUTPUT DELETED.QuantityNeeded INTO @Updated
        WHERE tblReservation.ReservationID = @ReservationID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ReservationID:',@ReservationID,CHAR(13),CHAR(10),
			'ReservedBy:',@ReservedBy,CHAR(13),CHAR(10),
			'ItemID:',@ItemID,CHAR(13),CHAR(10),
			'QuantityNeeded:',IIF((SELECT @QuantityNeeded - ISNULL(QuantityNeeded, 0) FROM @Updated) >= 0, '+', ''),(SELECT @QuantityNeeded - ISNULL(QuantityNeeded, 0) FROM @Updated),CHAR(13),CHAR(10),
			'DateNeeded:',@DateNeeded)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified an item reservation.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblReservation_', '') AS RES
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

--

CREATE PROCEDURE spDeleteReservation
    @Key NVARCHAR(36),
    @ReservationID INTEGER
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'Reservation') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@ReservationID, -1) <= 0 BEGIN
        SELECT 'Not Exists' AS RES
        RETURN 0
    END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
		DELETE FROM tblReservation WHERE tblReservation.ReservationID = @ReservationID

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'ReservationID:',@ReservationID)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Removed an item reservation.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblReservation_', '') AS RES
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

--

CREATE PROCEDURE spInsertStation
    @Key NVARCHAR(36),
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
		DECLARE @Inserted TABLE(StationID INTEGER)

		INSERT INTO tblStation
		(tblStation.CustomerID,
		tblStation.InventoryID,
		tblStation.Location,
		tblStation.Good,
		tblStation.Damaged)
		OUTPUT INSERTED.StationID INTO @Inserted
		VALUES
		(@CustomerID,
		@InventoryID,
        @Location,
		@Good,
		@Damaged)

		IF @@ROWCOUNT > 0 BEGIN
			DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
			'StationID:',(SELECT StationID FROM @Inserted),CHAR(13),CHAR(10),
			'CustomerID:',@CustomerID,CHAR(13),CHAR(10),
			'InventoryID:',@InventoryID,CHAR(13),CHAR(10),
			'Location:',@Location,CHAR(13),CHAR(10),
			'Good:',@Good,CHAR(13),CHAR(10),
			'Damaged:',@Damaged)

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Stationed an inventory.', @LogDetails
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

--

CREATE PROCEDURE spUpdateStation
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

--

CREATE PROCEDURE spInsertUser
	@Key NVARCHAR(36),
	@Username VARCHAR(16),
	@Password NVARCHAR(50),
	@PermissionName NVARCHAR(50)
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'User') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Username) <= 3 BEGIN
		SELECT 'Username' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Password) <= 5 BEGIN
		SELECT 'Password' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
		SELECT 'FK_tblItem_PermissionName' AS RES
        RETURN 0
    END

    DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
    BEGIN TRANSACTION @TransactionName
    BEGIN TRY
        DECLARE @Inserted TABLE(UserID INTEGER)
	    DECLARE @EncryptedPassword VARBINARY(256) = ENCRYPTBYPASSPHRASE('temp', 'temp')

        INSERT INTO tblUser
        (tblUser.Username,
        tblUser.Password,
        tblUser.PermissionName)
        OUTPUT INSERTED.UserID INTO @Inserted
        VALUES
        (@Username,
        @EncryptedPassword,
        @PermissionName)

        IF @@ROWCOUNT > 0 BEGIN
            DECLARE @SaltedPassword NVARCHAR(100) = CONCAT((SELECT UserID FROM @Inserted), @Password)
            SET @EncryptedPassword = ENCRYPTBYPASSPHRASE(@SaltedPassword, @SaltedPassword)

            UPDATE tblUser
            SET tblUser.Password = @EncryptedPassword
            WHERE tblUser.UserID = (SELECT UserID FROM @Inserted)

            IF @@ROWCOUNT > 0 BEGIN
                DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
                'UserID:', (SELECT UserID FROM @Inserted), CHAR(13), CHAR(10),
                'Username:', @Username, CHAR(13), CHAR(10),
                'PermissionName:', @PermissionName)

                DECLARE @Logged INTEGER
                EXECUTE @Logged = spInsertActivityLog @Key, 'Added a user.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblUser_', '') AS RES
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

--

CREATE PROCEDURE spUpdateUser
    @Key NVARCHAR(36),
    @UserID INTEGER,
    @Username NVARCHAR(16),
    @Password NVARCHAR(50),
    @PermissionName NVARCHAR(50),
    @Active BIT
AS
BEGIN

    IF dbo.fnIsKeyPermitted(@Key, 'User') = 0 BEGIN
        SELECT 'Not Permitted' AS RES
        RETURN 0
    END
    IF ISNULL(@UserID, -1) < 0 BEGIN
		SELECT 'Not Exists' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Username) <= 3 BEGIN
		SELECT 'Username' AS RES
        RETURN 0
    END
    IF @Password IS NOT NULL AND dbo.fnGetLen(@Password) <= 5 BEGIN
		SELECT 'Password' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@PermissionName) = 0 BEGIN
		SELECT 'FK_tblItem_PermissionName' AS RES
        RETURN 0
    END

    DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
    BEGIN TRANSACTION @TransactionName
    BEGIN TRY
        DECLARE @SaltedPassword NVARCHAR(100) = CONCAT(@UserID, @Password)
	    DECLARE @EncryptedPassword VARBINARY(256) = ENCRYPTBYPASSPHRASE(@SaltedPassword, @SaltedPassword)

        UPDATE tblUser
        SET
        tblUser.Username = @Username,
        tblUser.Password = IIF(@Password IS NULL, tblUser.Password, @EncryptedPassword),
        tblUser.PermissionName = @PermissionName,
        tblUser.Active = @Active
        WHERE tblUser.UserID = @UserID

        IF @@ROWCOUNT > 0 BEGIN
            DECLARE @LogDetails NVARCHAR(3000) = CONCAT(
            'UserID:', @UserID, CHAR(13), CHAR(10),
            'Username:', @Username, CHAR(13), CHAR(10),
            'PermissionName:', @PermissionName, CHAR(13), CHAR(10),
            'Active:', IIF(@Active <= 0, 'False', 'True'))

            DECLARE @Logged INTEGER
            EXECUTE @Logged = spInsertActivityLog @Key, 'Modified a user.', @LogDetails
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
            SELECT REPLACE(@M, 'CK_tblUser_', '') AS RES
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

--

CREATE PROCEDURE spLogin
	@Username NVARCHAR(16),
    @Password NVARCHAR(50),
	@DeviceInfo NVARCHAR(500)
AS
BEGIN

    IF dbo.fnGetLen(@Username) <= 3 BEGIN
        SELECT 'Failed' AS RES
        RETURN 0
    END
    IF dbo.fnGetLen(@Password) <= 5 BEGIN
        SELECT 'Failed' AS RES
        RETURN 0
    END

	if dbo.fnGetLen(@DeviceInfo) = 0 BEGIN
		SET @DeviceInfo = NULL
	END

	DECLARE @TransactionName VARCHAR(20) = 'trnsctn'
	BEGIN TRANSACTION @TransactionName
	BEGIN TRY
        IF dbo.fnLogin(@Username, @Password) = 1 BEGIN
            DECLARE @Inserted TABLE(SessionKey NVARCHAR(36))

            INSERT INTO tblSession
            (tblSession.UserID)
            OUTPUT INSERTED.SessionKey INTO @Inserted
            VALUES
            ((SELECT U.UserID FROM tblUser AS U WHERE U.Username = @Username))

            IF @@ROWCOUNT > 0 BEGIN
                DECLARE @Key NVARCHAR(36) = (SELECT SessionKey FROM @Inserted)
                DECLARE @Logged INTEGER
                EXECUTE @Logged = spInsertActivityLog @Key, 'Logged in.', @DeviceInfo
                IF @Logged = 1 BEGIN
                    COMMIT TRANSACTION @TransactionName
                    SELECT 'Successful' AS RES, @Key AS [KEY]
                    RETURN 0
                END
            END
        END

        ROLLBACK TRANSACTION @TransactionName
	    SELECT 'Failed' AS RES
	    RETURN 0
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION @TransactionName
        PRINT ERROR_MESSAGE()
        SELECT ERROR_NUMBER() AS RES
	END CATCH

END
GO
