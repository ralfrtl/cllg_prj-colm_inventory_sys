USE dbColmInventory
GO

ALTER VIEW vwDashboard
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
