CREATE TABLE [dbo].[Address] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [UniqueId]    UNIQUEIDENTIFIER NOT NULL,
    [Residential] NVARCHAR (500)   NULL,
    [Work]        NVARCHAR (500)   NULL,
    [Postal]      NVARCHAR (500)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

