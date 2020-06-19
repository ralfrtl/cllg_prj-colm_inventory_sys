USE dbColmInventory
GO

ALTER VIEW vwCustomer
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
