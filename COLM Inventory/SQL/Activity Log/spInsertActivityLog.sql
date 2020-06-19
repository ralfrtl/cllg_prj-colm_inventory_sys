USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER PROCEDURE spInsertActivityLog
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
