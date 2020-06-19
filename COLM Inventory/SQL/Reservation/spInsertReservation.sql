USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertReservation
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