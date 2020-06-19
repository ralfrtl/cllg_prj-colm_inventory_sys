USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trUpdatePermission
	ON tblPermission
	AFTER UPDATE
AS 
BEGIN
	
	IF (SELECT PermissionName FROM DELETED) = 'Admin' BEGIN
		UPDATE tblPermission
		SET
        tblPermission.PermissionName = 'Admin',
		tblPermission.AccessUser = 1,
		tblPermission.AccessPermission = 1,
		tblPermission.AccessCustomer = 1,
		tblPermission.AccessItem = 1,
		tblPermission.AccessInventory = 1,
		tblPermission.AccessConsume = 1,
		tblPermission.AccessBorrow = 1,
		tblPermission.AccessStation = 1,
		tblPermission.AccessReservation = 1
		WHERE tblPermission.PermissionName = (SELECT PermissionName FROM INSERTED)
	END

	IF (SELECT PermissionName FROM DELETED) = 'Guest' BEGIN
		UPDATE tblPermission
		SET  
	    tblPermission.PermissionName = 'Guest',
		tblPermission.AccessUser = 0,
		tblPermission.AccessPermission = 0,
		tblPermission.AccessCustomer = 0,
		tblPermission.AccessItem = 0,
		tblPermission.AccessInventory = 0,
		tblPermission.AccessConsume = 0,
		tblPermission.AccessBorrow = 0,
		tblPermission.AccessStation = 0,
		tblPermission.AccessReservation = 0
		WHERE tblPermission.PermissionName = (SELECT PermissionName FROM INSERTED)
	END

END
GO

ALTER TRIGGER trDeletePermission
	ON tblPermission
	AFTER DELETE
AS 
BEGIN
	
	IF (SELECT PermissionName FROM DELETED) = 'Admin' BEGIN
		INSERT INTO tblPermission VALUES ('Admin', 1, 1, 1, 1, 1, 1, 1, 1, 1)
	END

    IF (SELECT PermissionName FROM DELETED) = 'Guest' BEGIN
		INSERT INTO tblPermission VALUES ('Guest', 0, 0, 0, 0, 0, 0, 0, 0, 0)
	END

END
GO
