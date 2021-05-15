CREATE TABLE [dbo].[Contact] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL,
    [ContactType] INT NOT NULL,
    [Msisdn] NVARCHAR(100) NOT NULL,
    [ClientId] INT FOREIGN KEY REFERENCES [dbo].[Client]([Id])
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE NONCLUSTERED INDEX IX_UniqueId
ON [dbo].[Contact]([UniqueId])