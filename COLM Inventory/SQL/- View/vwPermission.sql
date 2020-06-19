USE dbColmInventory
GO

ALTER VIEW vwPermission
AS

	SELECT
	PermissionName,
	IIF(AccessUser = 0, 'False', 'True') AS AccessUser,
	IIF(AccessPermission = 0, 'False', 'True') AS AccessPermission,
	IIF(AccessCustomer = 0, 'False', 'True') AS AccessCustomer,
	IIF(AccessItem = 0, 'False', 'True') AS AccessItem,
	IIF(AccessInventory = 0, 'False', 'True') AS AccessInventory,
	IIF(AccessReservation = 0, 'False', 'True') AS AccessReservation,
	IIF(AccessConsume = 0, 'False', 'True') AS AccessConsume,
	IIF(AccessBorrow = 0, 'False', 'True') AS AccessBorrow,
	IIF(AccessStation = 0, 'False', 'True') AS AccessStation
	FROM tblPermission

GO
