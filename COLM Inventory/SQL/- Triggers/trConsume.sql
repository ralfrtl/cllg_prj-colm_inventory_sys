USE dbColmInventory
GO

SET NOCOUNT ON
GO

ALTER TRIGGER trInsertConsume
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

ALTER TRIGGER trUpdateConsume
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

ALTER TRIGGER trDeleteConsume
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
