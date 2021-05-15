INSERT INTO [dbo].[Client]
(
	[UniqueId],
	[FirstName],
	[MiddleName],
	[LastName],
	[Gender],
	[DateOfBirth],
	[CreatedOn],
	[Status]
)
OUTPUT INSERTED.ID 
VALUES
(
	@uniqueId,
	@firstName,
	@middleName,
	@lastName,
	@gender,
	@dateOfBirth,
	@createdOn,
	@status
);