INSERT INTO [dbo].[Contact]
(
	[UniqueId],
	[ContactType],
	[Msisdn],
	[ClientId]
)
VALUES
(
	@uniqueId,
	@contactType,
	@msisdn,
	@clientId
)