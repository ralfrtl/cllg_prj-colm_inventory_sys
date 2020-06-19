USE dbColmInventory
GO

CREATE VIEW vwActivityLog
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

--

CREATE VIEW vwBorrow
AS

	SELECT
    B.BorrowID,
    CC.*,
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    II.DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
    B.Good AS BorrowedGood,
    B.Damaged AS BorrowedDamaged
    FROM tblBorrow AS B
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = B.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = B.InventoryID

GO

--

CREATE VIEW vwConsume
AS

	SELECT
    C.ConsumeID,
    CC.*,
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    II.DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
    C.Good As ConsumedGood,
    C.Damaged As ConsumedDamaged
    FROM tblConsume AS C
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = C.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = C.InventoryID

GO

--

CREATE VIEW vwCustomer
AS

	SELECT
	CC.CustomerID,
	CC.FirstName,
	CC.MiddleName,
	CC.LastName,
	CC.Position,
	CC.Department,
    (SELECT ISNULL(COUNT(CO.OffenseID), 0) FROM tblCustomerOffense AS CO WHERE CO.CustomerID = CC.CustomerID AND CO.Settled = 0) AS Offense
	FROM tblCustomer AS CC

GO

--

CREATE VIEW vwCustomerOffense
AS

	SELECT
	CO.OffenseID,
	CO.CustomerID,
	CO.Information,
	IIF(CO.Settled = 0, 'False', 'True') AS Settled
	FROM tblCustomerOffense AS CO

GO

--

CREATE VIEW vwDashboard
AS

	SELECT
	(SELECT ISNULL(COUNT(*), 0) FROM tblItem) AS Item,
	(SELECT ISNULL(COUNT(*), 0) FROM tblInventory) AS Inventory,
	(SELECT ISNULL(COUNT(*), 0) FROM tblItem WHERE ItemType = 'Asset') AS Asset,
	(SELECT ISNULL(COUNT(*), 0) FROM tblItem WHERE ItemType = 'Asset - Bulk') AS AssetBulk,
	(SELECT ISNULL(COUNT(*), 0) FROM tblItem WHERE ItemType = 'Consumable') AS Consumable,

	(SELECT ISNULL(SUM(Reserved), 0) FROM vwItem WHERE Reserved > 0) AS Reserved,
	(SELECT ISNULL(SUM(Borrowed), 0) FROM vwItem WHERE Reserved > 0) AS Borrowed,
	(SELECT ISNULL(SUM(Stationed), 0) FROM vwItem WHERE Reserved > 0) AS Stationed,

	(SELECT ISNULL(COUNT(*), 0) FROM vwItem WHERE LowThreshold > 0 AND Available > 0 AND Available < LowThreshold) AS Low,
	(SELECT ISNULL(COUNT(*), 0) FROM vwItem WHERE LowThreshold > 0 AND Available = 0) AS Out

GO

--

CREATE VIEW vwInventory
AS

    SELECT
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    FORMAT(II.DateReceived, 'MMM-dd-yyyy hh:mm:ss tt') AS DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
    II.Maintenance,
    II.Replacement,
	IIF(dbo.fnGetItemTypeByItemID(II.ItemID) = 'Asset',
		IIF((SELECT ISNULL(SUM(B.Good), 0) + ISNULL(SUM(B.Damaged), 0) FROM tblBorrow AS B WHERE B.InventoryID = II.InventoryID) = 0  AND
			(SELECT ISNULL(SUM(S.Good), 0) + ISNULL(SUM(S.Damaged), 0) FROM tblStation AS S WHERE S.InventoryID = II.InventoryID) = 0,
			'False', 'True'),
		'') AS InUse
    FROM tblInventory AS II

GO

--

CREATE VIEW vwItem
AS

	SELECT
	I.ItemID,
    I.Name,
    I.Description,
    I.ItemType,
    I.UnitType,
    I.LowThreshold,
    dbo.fnTotal(I.ItemID) AS Total,
    dbo.fnAvailable(I.ItemID) AS Available,
    dbo.fnBorrowed(I.ItemID, 'G') + dbo.fnBorrowed(I.ItemID, 'D') AS Borrowed,
    dbo.fnStationed(I.ItemID, 'G') + dbo.fnStationed(I.ItemID, 'D') AS Stationed,
    dbo.fnReserved(I.ItemID) AS Reserved,
    dbo.fnGood(I.ItemID) AS Good,
    dbo.fnDamaged(I.ItemID) AS Damaged,
    dbo.fnMaintenance(I.ItemID) AS Maintenance,
    dbo.fnReplacement(I.ItemID) AS Replacement
	FROM tblItem AS I

GO

--

CREATE VIEW vwPermission
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

--

CREATE VIEW vwReservation
AS

	SELECT
	TOP(1000)
    R.ReservationID,
    RB.*,
    I.*,
    R.QuantityNeeded,
    FORMAT(R.DateNeeded, 'MMM-dd-yyyy hh:mm:ss tt') AS DateNeeded,
    IIF(GETDATE() <= DATEADD(MINUTE, 15, R.DateNeeded), 'False', 'True') AS Expired
    FROM tblReservation AS R
    INNER JOIN vwCustomer AS RB
    ON RB.CustomerID = R.ReservedBy
    INNER JOIN tblItem AS I
    ON I.ItemID = R.ItemID
	WHERE GETDATE() <= DATEADD(MINUTE, 15, R.DateNeeded)
	ORDER BY DateNeeded ASC

	UNION ALL

	SELECT
	TOP(1000)
    R.ReservationID,
    RB.*,
    I.*,
    R.QuantityNeeded,
    FORMAT(R.DateNeeded, 'MMM-dd-yyyy hh:mm:ss tt') AS DateNeeded,
    IIF(GETDATE() <= DATEADD(MINUTE, 15, R.DateNeeded), 'False', 'True') AS Expired
    FROM tblReservation AS R
    INNER JOIN vwCustomer AS RB
    ON RB.CustomerID = R.ReservedBy
    INNER JOIN tblItem AS I
    ON I.ItemID = R.ItemID
	WHERE GETDATE() > DATEADD(MINUTE, 15, R.DateNeeded)
	ORDER BY DateNeeded DESC


GO

--

CREATE VIEW vwStation
AS

	SELECT
    S.StationID,
    CC.*,
    II.ItemID,
    II.InventoryID,
    II.Information,
    II.Store,
    II.ReceiptNo,
    II.DateReceived,
    II.CostPerUnit,
    II.Good,
    II.Damaged,
	S.Location,
    S.Good AS StationedGood,
    S.Damaged AS StationedDamaged
    FROM tblStation AS S
    INNER JOIN vwCustomer AS CC
    ON CC.CustomerID = S.CustomerID
    INNER JOIN tblInventory AS II
    ON II.InventoryID = S.InventoryID

GO

--

CREATE VIEW vwUser
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
