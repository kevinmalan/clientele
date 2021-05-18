INSERT INTO [dbo].[Client]
(
	[UniqueId],
	[FirstName],
	[MiddleName],
	[LastName],
	[Gender],
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
	@createdOn,
	@status
);