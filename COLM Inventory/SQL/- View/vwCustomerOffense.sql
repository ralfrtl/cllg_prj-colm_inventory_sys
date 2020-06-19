USE dbColmInventory
GO

ALTER VIEW vwCustomerOffense
AS

	SELECT
	CO.OffenseID,
	CO.CustomerID,
	CO.Information,
	IIF(CO.Settled = 0, 'False', 'True') AS Settled
	FROM tblCustomerOffense AS CO
    
GO
