USE dbColmInventory
GO

ALTER VIEW vwUser
AS

	SELECT
    U.UserID,
	U.Username,
	P.*,
	IIF(U.Active = 0, 'False', 'True') AS Active
	FROM tblUser AS U
    INNER JOIN vwPermission AS P
    ON P.PermissionName = U.PermissionName

GO
