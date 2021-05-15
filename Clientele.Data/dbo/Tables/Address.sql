CREATE TABLE [dbo].[Address] (
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL,
    [AddressType] INT NOT NULL,
    [Line1] NVARCHAR(255) NOT NULL,
    [Line2] NVARCHAR(255) NULL,
    [Line3] NVARCHAR(255) NULL,
    [City] NVARCHAR(100) NOT NULL,
    [StateProvince] NVARCHAR(100) NOT NULL,
    [AreaCode] NVARCHAR(25) NOT NULL,
    [Country] NVARCHAR(100) NOT NULL,
    [ClientId] INT FOREIGN KEY REFERENCES [dbo].[Client]([Id])
);
GO
CREATE NONCLUSTERED INDEX IX_UniqueId
ON [dbo].[Address]([UniqueId])
