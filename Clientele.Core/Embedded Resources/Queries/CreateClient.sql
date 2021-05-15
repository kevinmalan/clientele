DECLARE @outputIds TABLE
(
	[AddressId] INT,
	[ContactId] INT
);

INSERT INTO [Address]
(
	[UniqueId],
	[Residential],
	[Work],
	[Postal]
)
OUTPUT INSERTED.ID INTO @outputIds([AddressId])
VALUES
(
	@addressId,
	@residential,
	@workAddress,
	@postal
);

INSERT INTO [Contact]
(
	[UniqueId],
	[Cell],
	[Work]
)
OUTPUT INSERTED.ID INTO @outputIds([ContactId])
VALUES
(
	@contactId,
	@cell,
	@workContact
);

INSERT INTO [dbo].[Client]
(
	[UniqueId],
	[FirstName],
	[MiddleName],
	[LastName],
	[Gender],
	[DateOfBirth],
	[CreatedOn],
	[Status],
	[AddressId],
	[ContactId]
)
VALUES
(
	@uniqueId,
	@firstName,
	@middleName,
	@lastName,
	@gender,
	@dateOfBirth,
	@createdOn,
	@status,
	(SELECT [AddressId] FROM @outputIds WHERE [AddressId] IS NOT NULL),
	(SELECT [ContactId] FROM @outputIds WHERE [ContactId] IS NOT NULL)
);