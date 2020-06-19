USE dbColmInventory
GO

CREATE TABLE [dbo].[tblPermission] (
    [PermissionName]    NVARCHAR (50) NOT NULL,
    [AccessUser]        BIT           CONSTRAINT [DF_tblPermission_AccessUser] DEFAULT ((0)) NOT NULL,
    [AccessPermission]  BIT           CONSTRAINT [DF_tblPermission_AccessPermission] DEFAULT ((0)) NOT NULL,
    [AccessCustomer]    BIT           CONSTRAINT [DF_tblPermission_AccessCustomer] DEFAULT ((0)) NOT NULL,
    [AccessItem]        BIT           CONSTRAINT [DF_tblPermission_AccessItem] DEFAULT ((0)) NOT NULL,
    [AccessInventory]   BIT           CONSTRAINT [DF_tblPermission_AccessInventory] DEFAULT ((0)) NOT NULL,
    [AccessReservation] BIT           CONSTRAINT [DF_tblPermission_AccessReservation] DEFAULT ((0)) NOT NULL,
    [AccessConsume]     BIT           CONSTRAINT [DF_tblPermission_AccessConsume] DEFAULT ((0)) NOT NULL,
    [AccessBorrow]      BIT           CONSTRAINT [DF_tblPermission_AccessBorrow] DEFAULT ((0)) NOT NULL,
    [AccessStation]     BIT           CONSTRAINT [DF_tblPermission_AccessStation] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblPermission] PRIMARY KEY CLUSTERED ([PermissionName] ASC)
)

--

CREATE TABLE [dbo].[tblUser] (
    [UserID]         INT             IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (50)   NOT NULL,
    [Password]       VARBINARY (256) NOT NULL,
    [PermissionName] NVARCHAR (50)   NOT NULL,
    [Active]         BIT             CONSTRAINT [DF_tblUser_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [UK_tblUser] UNIQUE NONCLUSTERED ([Username] ASC),
    CONSTRAINT [FK_tblUser_PermissionName] FOREIGN KEY ([PermissionName]) REFERENCES [dbo].[tblPermission] ([PermissionName]) ON UPDATE CASCADE
)

--

CREATE TABLE [dbo].[tblSession] (
    [SessionKey]  NVARCHAR (36) CONSTRAINT [DF_tblSession_SessionKey] DEFAULT (newid()) NOT NULL,
    [UserID]      INT           NOT NULL,
    [DateGranted] DATETIME2 (2) CONSTRAINT [DF_tblSession_DateGranted] DEFAULT (getdate()) NOT NULL,
    [Active]      BIT           CONSTRAINT [DF_tblSession_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tblSession] PRIMARY KEY CLUSTERED ([SessionKey] ASC),
    CONSTRAINT [FK_tblSession_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([UserID])
)

--

CREATE TABLE [dbo].[tblActivityLog] (
    [LogID]     INT             IDENTITY (1, 1) NOT NULL,
    [UserID]    INT             NOT NULL,
    [Activity]  NVARCHAR (50)   NOT NULL,
    [Details]   NVARCHAR (3000) NULL,
    [Timestamp] DATETIME2 (2)   CONSTRAINT [DF_tblActivityLog_Timestamp] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_tblActivityLog] PRIMARY KEY CLUSTERED ([LogID] ASC),
    CONSTRAINT [FK_tblActivityLog_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([UserID])
)

--

CREATE TABLE [dbo].[tblCustomer] (
    [CustomerID] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Position]   NVARCHAR (50) NOT NULL,
    [Department] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
)

--

CREATE TABLE [dbo].[tblCustomerOffense] (
    [OffenseID]   INT            IDENTITY (1, 1) NOT NULL,
    [CustomerID]  INT            NOT NULL,
    [Information] NVARCHAR (120) NOT NULL,
    [Settled]     BIT            CONSTRAINT [DF_tblCustomerOffense_Settled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblCustomerOffense] PRIMARY KEY CLUSTERED ([OffenseID] ASC),
    CONSTRAINT [FK_tblCustomerOffense_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tblCustomer] ([CustomerID]) ON DELETE CASCADE
)

--

CREATE TABLE [dbo].[tblItem] (
    [ItemID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (120) NOT NULL,
    [ItemType]     NVARCHAR (50)  NOT NULL,
    [UnitType]     NVARCHAR (50)  NOT NULL,
    [LowThreshold] INT            NOT NULL,
    CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [CK_tblItem_LowThreshold] CHECK ([LowThreshold]>=(0)),
    CONSTRAINT [CK_tblItem_ItemType] CHECK ([ItemType]='Consumable' OR [ItemType]='Asset - Bulk' OR [ItemType]='Asset')
)

--

CREATE TABLE [dbo].[tblInventory] (
    [ItemID]       INT             NOT NULL,
    [InventoryID]  INT             IDENTITY (1, 1) NOT NULL,
    [Information]  NVARCHAR (500)  NOT NULL,
    [Store]        NVARCHAR (120)  NOT NULL,
    [ReceiptNo]    NVARCHAR (50)   NOT NULL,
    [DateReceived] DATETIME2 (2)   NOT NULL,
    [CostPerUnit]  DECIMAL (19, 2) NOT NULL,
    [Good]         INT             NOT NULL,
    [Damaged]      INT             NOT NULL,
    [Maintenance]  INT             NOT NULL,
    [Replacement]  INT             NOT NULL,
    CONSTRAINT [PK_tblInventory] PRIMARY KEY CLUSTERED ([InventoryID] ASC),
    CONSTRAINT [FK_tblInventory_ItemID] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[tblItem] ([ItemID]) ON DELETE CASCADE,
    CONSTRAINT [CK_tblInventory_CostPerUnit] CHECK ([CostPerUnit]>=(0)),
    CONSTRAINT [CK_tblInventory_Good] CHECK ([Good]>=(0)),
    CONSTRAINT [CK_tblInventory_Damaged] CHECK ([Damaged]>=(0)),
    CONSTRAINT [CK_tblInventory_Maintenance] CHECK ([Maintenance]>=(0)),
    CONSTRAINT [CK_tblInventory_Replacement] CHECK ([Replacement]>=(0))
)

--

CREATE TABLE [dbo].[tblReservation] (
    [ReservationID]  INT           IDENTITY (1, 1) NOT NULL,
    [ReservedBy]     INT           NOT NULL,
    [ItemID]         INT           NOT NULL,
    [QuantityNeeded] INT           NOT NULL,
    [DateNeeded]     DATETIME2 (2) NOT NULL,
    CONSTRAINT [PK_tblReservation] PRIMARY KEY CLUSTERED ([ReservationID] ASC),
    CONSTRAINT [FK_tblReservation_ReservedBy] FOREIGN KEY ([ReservedBy]) REFERENCES [dbo].[tblCustomer] ([CustomerID]),
    CONSTRAINT [FK_tblReservation_ItemID] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[tblItem] ([ItemID]) ON DELETE CASCADE,
    CONSTRAINT [CK_tblReservation_QuantityNeeded] CHECK ([QuantityNeeded]>=(0))
)

--

CREATE TABLE [dbo].[tblConsume] (
    [ConsumeID]   INT IDENTITY (1, 1) NOT NULL,
    [CustomerID]  INT NOT NULL,
    [InventoryID] INT NOT NULL,
    [Good]        INT NOT NULL,
    [Damaged]     INT NOT NULL,
    CONSTRAINT [PK_tblConsume] PRIMARY KEY CLUSTERED ([ConsumeID] ASC),
    CONSTRAINT [FK_tblConsume_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tblCustomer] ([CustomerID]),
    CONSTRAINT [FK_tblConsume_InventoryID] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[tblInventory] ([InventoryID]) ON DELETE CASCADE,
    CONSTRAINT [CK_tblConsume_Good] CHECK ([Good]>=(0)),
    CONSTRAINT [CK_tblConsume_Damaged] CHECK ([Damaged]>=(0))
)

--

CREATE TABLE [dbo].[tblBorrow] (
    [BorrowID]    INT IDENTITY (1, 1) NOT NULL,
    [CustomerID]  INT NOT NULL,
    [InventoryID] INT NOT NULL,
    [Good]        INT NOT NULL,
    [Damaged]     INT NOT NULL,
    CONSTRAINT [PK_tblBorrow] PRIMARY KEY CLUSTERED ([BorrowID] ASC),
    CONSTRAINT [FK_tblBorrow_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tblCustomer] ([CustomerID]),
    CONSTRAINT [FK_tblBorrow_InventoryID] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[tblInventory] ([InventoryID]) ON DELETE CASCADE,
    CONSTRAINT [CK_tblBorrow_Good] CHECK ([Good]>=(0)),
    CONSTRAINT [CK_tblBorrow_Damaged] CHECK ([Damaged]>=(0))
)

--

CREATE TABLE [dbo].[tblStation] (
    [StationID]   INT            IDENTITY (1, 1) NOT NULL,
    [CustomerID]  INT            NOT NULL,
    [InventoryID] INT            NOT NULL,
    [Location]    NVARCHAR (120) NOT NULL,
    [Good]        INT            NOT NULL,
    [Damaged]     INT            NOT NULL,
    CONSTRAINT [PK_tblStation] PRIMARY KEY CLUSTERED ([StationID] ASC),
    CONSTRAINT [FK_tblStation_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[tblCustomer] ([CustomerID]),
    CONSTRAINT [FK_tblStation_InventoryID] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[tblInventory] ([InventoryID]) ON DELETE CASCADE,
    CONSTRAINT [CK_tblStation_Good] CHECK ([Good]>=(0)),
    CONSTRAINT [CK_tblStation_Damaged] CHECK ([Damaged]>=(0))
)
