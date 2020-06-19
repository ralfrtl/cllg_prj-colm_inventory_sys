USE dbColmInventory
GO

ALTER TABLE tblActivityLog DROP CONSTRAINT CK_tblActivityLog_Activity
GO

ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_FirstName
GO
ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_LastName
GO
ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_Position
GO
ALTER TABLE tblCustomer DROP CONSTRAINT CK_tblCustomer_Department
GO

ALTER TABLE tblCustomerOffense DROP CONSTRAINT CK_tblCustomerOffense_Information
GO

ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Information
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_Store
GO
ALTER TABLE tblInventory DROP CONSTRAINT CK_tblInventory_ReceiptNo
GO

ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_Name
GO
ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_Description
GO
ALTER TABLE tblItem DROP CONSTRAINT CK_tblItem_UnitType
GO

ALTER TABLE tblPermission DROP CONSTRAINT CK_tblPermission_PermissionName
GO

ALTER TABLE tblStation DROP CONSTRAINT CK_tblStation_Location
GO

ALTER TABLE tblUser DROP CONSTRAINT CK_tblUser_Username
GO

CREATE FUNCTION fnGetLen(@String NVARCHAR(4000)) RETURNS INTEGER
AS
BEGIN

	RETURN LEN(REPLACE(REPLACE(REPLACE(ISNULL(@String, ''), ' ', ''), CONCAT(CHAR(13), CHAR(10)), ''), CHAR(9), ''))

END
GO

ALTER TABLE tblActivityLog WITH CHECK ADD CONSTRAINT CK_tblActivityLog_Activity CHECK
(dbo.fnGetLen(Activity) > 0)
ALTER TABLE tblActivityLog CHECK CONSTRAINT CK_tblActivityLog_Activity
GO

ALTER TABLE tblCustomer WITH CHECK ADD CONSTRAINT CK_tblCustomer_FirstName CHECK
(dbo.fnGetLen(FirstName) > 0)
ALTER TABLE tblCustomer CHECK CONSTRAINT CK_tblCustomer_FirstName
GO
ALTER TABLE tblCustomer WITH CHECK ADD CONSTRAINT CK_tblCustomer_LastName CHECK
(dbo.fnGetLen(LastName) > 0)
ALTER TABLE tblCustomer CHECK CONSTRAINT CK_tblCustomer_LastName
GO
ALTER TABLE tblCustomer WITH CHECK ADD CONSTRAINT CK_tblCustomer_Position CHECK
(dbo.fnGetLen(Position) > 0)
ALTER TABLE tblCustomer CHECK CONSTRAINT CK_tblCustomer_Position
GO
ALTER TABLE tblCustomer WITH CHECK ADD CONSTRAINT CK_tblCustomer_Department CHECK
(dbo.fnGetLen(Department) > 0)
ALTER TABLE tblCustomer CHECK CONSTRAINT CK_tblCustomer_Department
GO

ALTER TABLE tblCustomerOffense WITH CHECK ADD CONSTRAINT CK_tblCustomerOffense_Information CHECK
(dbo.fnGetLen(Information) > 0)
ALTER TABLE tblCustomerOffense CHECK CONSTRAINT CK_tblCustomerOffense_Information
GO

ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Information CHECK
(dbo.fnGetLen(Information) > 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Information
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_Store CHECK
(dbo.fnGetLen(Store) > 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_Store
GO
ALTER TABLE tblInventory WITH CHECK ADD CONSTRAINT CK_tblInventory_ReceiptNo CHECK
(dbo.fnGetLen(ReceiptNo) > 0)
ALTER TABLE tblInventory CHECK CONSTRAINT CK_tblInventory_ReceiptNo
GO

ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_Name CHECK
(dbo.fnGetLen(Name) > 0)
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_Name
GO
ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_Description CHECK
(dbo.fnGetLen(Description) > 0)
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_Description
GO
ALTER TABLE tblItem WITH CHECK ADD CONSTRAINT CK_tblItem_UnitType CHECK
(dbo.fnGetLen(UnitType) > 0)
ALTER TABLE tblItem CHECK CONSTRAINT CK_tblItem_UnitType
GO

ALTER TABLE tblPermission WITH CHECK ADD CONSTRAINT CK_tblPermission_PermissionName CHECK
(dbo.fnGetLen(PermissionName) > 0)
ALTER TABLE tblPermission CHECK CONSTRAINT CK_tblPermission_PermissionName
GO

ALTER TABLE tblStation WITH CHECK ADD CONSTRAINT CK_tblStation_Location CHECK
(dbo.fnGetLen(Location) > 0)
ALTER TABLE tblStation CHECK CONSTRAINT CK_tblStation_Location
GO

ALTER TABLE tblUser WITH CHECK ADD CONSTRAINT CK_tblUser_Username CHECK
(dbo.fnGetLen(Username) > 3)
ALTER TABLE tblUser CHECK CONSTRAINT CK_tblUser_Username
GO
