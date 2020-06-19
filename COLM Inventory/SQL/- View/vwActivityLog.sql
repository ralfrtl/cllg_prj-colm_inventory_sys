USE dbColmInventory
GO

ALTER VIEW vwActivityLog
AS

	SELECT
    A.LogID,
    U.UserID,
    U.Username,
    U.PermissionName,
    A.Activity,
    A.Details,
    FORMAT(A.Timestamp, 'MMM-dd-yyyy hh:mm:ss tt') AS Timestamp
    FROM tblActivityLog AS A
    INNER JOIN tblUser AS U
    ON U.UserID = A.UserID
	
GO
