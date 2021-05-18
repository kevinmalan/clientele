CREATE TABLE [dbo].[Client] (
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL,
    [FirstName] NVARCHAR (255) NOT NULL,
    [MiddleName] NVARCHAR (255) NULL,
    [LastName] NVARCHAR (255) NOT NULL,
    [Gender] INT NOT NULL,
    [CreatedOn] DATETIMEOFFSET (7) NOT NULL,
    [UpdatedOn] DATETIMEOFFSET (7) NULL,
    [Status] INT NOT NULL
);
GO
CREATE NONCLUSTERED INDEX IX_UniqueId
ON [dbo].[Client]([UniqueId])