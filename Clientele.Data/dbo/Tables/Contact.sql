CREATE TABLE [dbo].[Contact] (
    [Id]       INT              IDENTITY (1, 1) NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL,
    [Cell]     NVARCHAR (50)    NULL,
    [Work]     NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

