USE dbColmInventory
GO

CREATE TRIGGER trInsertUpdateActivityLog
	ON tblActivityLog
	AFTER INSERT, UPDATE
AS
BEGIN

	UPDATE tblActivityLog
	SET
    tblActivityLog.Details = IIF(dbo.fnGetLen((SELECT Details FROM INSERTED)) = 0, NULL, (SELECT Details FROM INSERTED))
	WHERE tblActivityLog.LogID = (SELECT LogID FROM INSERTED)

END
GO

--

CREATE TRIGGER trInsertBorrow
   ON tblBorrow
   AFTER INSERT
AS
BEGIN

	IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
		DELETE FROM tblBorrow WHERE tblBorrow.BorrowID = (SELECT BorrowID FROM INSERTED)
	END
    ELSE BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
        tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
    END

END
GO

CREATE TRIGGER trUpdateBorrow
   ON tblBorrow
   AFTER UPDATE
AS
BEGIN

	IF (SELECT InventoryID FROM DELETED) <> (SELECT InventoryID FROM INSERTED) BEGIN
        UPDATE tblInventory
	    SET
	    tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
	    tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
	    WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)

		UPDATE tblInventory
		SET
		tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
		tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
		WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
	END
	ELSE BEGIN
		IF ((SELECT Good FROM DELETED) <> (SELECT Good FROM INSERTED)) OR ((SELECT Damaged FROM DELETED) <> (SELECT Damaged FROM INSERTED)) BEGIN
			UPDATE tblInventory
			SET
			tblInventory.Good = tblInventory.Good + ((SELECT Good FROM DELETED) - (SELECT Good FROM INSERTED)),
			tblInventory.Damaged = tblInventory.Damaged + ((SELECT Damaged FROM DELETED) - (SELECT Damaged FROM INSERTED))
			WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
		END
	END

	IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
		DELETE FROM tblBorrow WHERE tblBorrow.BorrowID = (SELECT BorrowID FROM INSERTED)
	END
END
GO

CREATE TRIGGER trDeleteBorrow
   ON tblBorrow
   AFTER DELETE
AS
BEGIN

    IF (SELECT Good + Damaged FROM DELETED) > 0 BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
        tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
    END

END
GO

--

CREATE TRIGGER trInsertConsume
ON tblConsume
AFTER INSERT
AS
BEGIN

    IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
        DELETE FROM tblConsume WHERE tblConsume.ConsumeID = (SELECT ConsumeID FROM INSERTED)
    END
    ELSE BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
        tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
    END

END
GO

CREATE TRIGGER trUpdateConsume
ON tblConsume
AFTER UPDATE
AS
BEGIN

    IF (SELECT InventoryID FROM DELETED) <> (SELECT InventoryID FROM INSERTED) BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
        tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)

        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
        tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
    END
    ELSE BEGIN
        IF ((SELECT Good FROM DELETED) <> (SELECT Good FROM INSERTED)) OR ((SELECT Damaged FROM DELETED) <> (SELECT Damaged FROM INSERTED)) BEGIN
            UPDATE tblInventory
            SET
            tblInventory.Good = tblInventory.Good + ((SELECT Good FROM DELETED) - (SELECT Good FROM INSERTED)),
            tblInventory.Damaged = tblInventory.Damaged + ((SELECT Damaged FROM DELETED) - (SELECT Damaged FROM INSERTED))
            WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
        END
    END

    IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
        DELETE FROM tblConsume WHERE tblConsume.ConsumeID = (SELECT ConsumeID FROM INSERTED)
    END
END
GO

CREATE TRIGGER trDeleteConsume
ON tblConsume
AFTER DELETE
AS
BEGIN

    IF (SELECT Good + Damaged FROM DELETED) > 0 BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
        tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
    END

END
GO

--

CREATE TRIGGER trInsertUpdateCustomer
	ON tblCustomer
	AFTER INSERT, UPDATE
AS
BEGIN

	UPDATE tblCustomer
	SET
    tblCustomer.MiddleName = IIF(dbo.fnGetLen((SELECT MiddleName FROM INSERTED)) = 0, '', (SELECT MiddleName FROM INSERTED))
	WHERE tblCustomer.CustomerID = (SELECT CustomerID FROM INSERTED)

END
GO

--

CREATE TRIGGER trInsertUpdateInventory
	ON tblInventory
	AFTER INSERT, UPDATE
AS
BEGIN

	DECLARE @ItemTypeDeleted NVARCHAR(50) = dbo.fnGetItemTypeByItemID((SELECT ItemID FROM DELETED))
	DECLARE @ItemTypeInserted NVARCHAR(50) = dbo.fnGetItemTypeByItemID((SELECT ItemID FROM INSERTED))

	IF @ItemTypeDeleted <> @ItemTypeInserted BEGIN
	   UPDATE tblInventory
		SET
		tblInventory.ItemID = (SELECT ItemID FROM DELETED)
		WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
	END
	ELSE BEGIN
		IF @ItemTypeInserted = 'Consumable' BEGIN
			UPDATE tblInventory
			SET
			tblInventory.Maintenance = 0
			WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
		END
	END

END
GO

--

CREATE TRIGGER trUpdateItem
	ON tblItem
	AFTER UPDATE
AS
BEGIN

    IF (SELECT ItemType FROM DELETED) <> (SELECT ItemType FROM INSERTED) BEGIN
	    DELETE FROM tblInventory WHERE tblInventory.ItemID = (SELECT ItemID FROM DELETED)
	END

END
GO

--

CREATE TRIGGER trUpdatePermission
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

CREATE TRIGGER trDeletePermission
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

--

CREATE TRIGGER trInsertSession
	ON tblSession
	AFTER INSERT
AS
BEGIN

	UPDATE tblSession
    SET
    tblSession.Active = 0
    WHERE tblSession.UserID = (SELECT UserID FROM INSERTED) AND tblSession.Active = 1 AND tblSession.SessionKey <> (SELECT SessionKey FROM INSERTED)

END
GO

--

CREATE TRIGGER trInsertStation
   ON tblStation
   AFTER INSERT
AS
BEGIN

	IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
		DELETE FROM tblStation WHERE tblStation.StationID = (SELECT StationID FROM INSERTED)
	END
    ELSE BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
        tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
    END

END
GO

CREATE TRIGGER trUpdateStation
   ON tblStation
   AFTER UPDATE
AS
BEGIN

	IF (SELECT InventoryID FROM DELETED) <> (SELECT InventoryID FROM INSERTED) BEGIN
        UPDATE tblInventory
	    SET
	    tblInventory.Good = tblInventory.Good - (SELECT Good FROM INSERTED),
	    tblInventory.Damaged = tblInventory.Damaged - (SELECT Damaged FROM INSERTED)
	    WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)

		UPDATE tblInventory
		SET
		tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
		tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
		WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
	END
	ELSE BEGIN
		IF ((SELECT Good FROM DELETED) <> (SELECT Good FROM INSERTED)) OR ((SELECT Damaged FROM DELETED) <> (SELECT Damaged FROM INSERTED)) BEGIN
			UPDATE tblInventory
			SET
			tblInventory.Good = tblInventory.Good + ((SELECT Good FROM DELETED) - (SELECT Good FROM INSERTED)),
			tblInventory.Damaged = tblInventory.Damaged + ((SELECT Damaged FROM DELETED) - (SELECT Damaged FROM INSERTED))
			WHERE tblInventory.InventoryID = (SELECT InventoryID FROM INSERTED)
		END
	END

	IF (SELECT Good + Damaged FROM INSERTED) = 0 BEGIN
		DELETE FROM tblStation WHERE tblStation.StationID = (SELECT StationID FROM INSERTED)
	END
END
GO

CREATE TRIGGER trDeleteStation
   ON tblStation
   AFTER DELETE
AS
BEGIN

	IF (SELECT Good + Damaged FROM DELETED) > 0 BEGIN
        UPDATE tblInventory
        SET
        tblInventory.Good = tblInventory.Good + (SELECT Good FROM DELETED),
        tblInventory.Damaged = tblInventory.Damaged + (SELECT Damaged FROM DELETED)
        WHERE tblInventory.InventoryID = (SELECT InventoryID FROM DELETED)
    END
END
GO
