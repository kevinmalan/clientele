CREATE TABLE [dbo].[Client] (
    [Id]          INT                IDENTITY (1, 1) NOT NULL,
    [UniqueId]    UNIQUEIDENTIFIER   NOT NULL,
    [FirstName]   NVARCHAR (255)     NOT NULL,
    [MiddleName]  NVARCHAR (255)     NULL,
    [LastName]    NVARCHAR (255)     NOT NULL,
    [Gender]      NVARCHAR (25)      NOT NULL,
    [DateOfBirth] DATETIME           NOT NULL,
    [CreatedOn]   DATETIMEOFFSET (7) NOT NULL,
    [UpdatedOn]   DATETIMEOFFSET (7) NULL,
    [Status]      NVARCHAR (25)      NOT NULL,
    [AddressId]   INT                NULL,
    [ContactId]   INT                NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([Id])
);

