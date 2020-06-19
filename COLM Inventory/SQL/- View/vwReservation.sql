USE dbColmInventory
GO

ALTER VIEW vwReservation
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
