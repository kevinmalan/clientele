SELECT
	c.[Id],
	c.[UniqueId],
	c.[FirstName],
	c.[MiddleName],
	c.[LastName],
	c.[Gender],
	c.[DateOfBirth],
	c.[CreatedOn],
	c.[UpdatedOn],
	c.[Status],
	a.[Id] AS AddressId,
	a.[UniqueId] AS AddressUniqueId,
	a.[Residential],
	a.[Work] AS WorkAddress,
	a.[Postal],
	co.[Id] As ContactId,
	co.[UniqueId] AS ContactUniqueId,
	co.[Cell],
	co.[Work] AS WorkContact
FROM [dbo].[Client] c
JOIN[dbo].[Address] a
ON c.[AddressId] = a.[Id]
JOIN[dbo].[Contact] co
ON c.[ContactId] = co.[Id];