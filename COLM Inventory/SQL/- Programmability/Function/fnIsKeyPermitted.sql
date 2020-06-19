USE dbColmInventory
GO

--  ENUM @AccessTo
--	    User
--		Permission
--		Customer
--		Item
--		Inventory
--		Reservation
--		Consume
--		Borrow
--		Station

ALTER FUNCTION fnIsKeyPermitted(@SessionKey NVARCHAR(36), @AccessTo NVARCHAR(50)) RETURNS BIT
AS
BEGIN
	
	IF @AccessTo = 'User' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessUser = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Permission' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessPermission = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Customer' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessCustomer = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Item' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessItem = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Inventory' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessInventory = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Reservation' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessReservation = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Consume' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessConsume = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Borrow' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessBorrow = 1) BEGIN
			RETURN 1
		END
	END
	ELSE IF @AccessTo = 'Station' BEGIN
		IF EXISTS (SELECT 1 FROM tblSession AS S INNER JOIN tblUser AS U ON S.SessionKey = @SessionKey AND S.Active = 1 AND U.UserID = S.UserID AND U.Active = 1 INNER JOIN tblPermission AS P ON P.PermissionName = U.PermissionName AND P.AccessStation = 1) BEGIN
			RETURN 1
		END
	END

	RETURN 0

END
GO
