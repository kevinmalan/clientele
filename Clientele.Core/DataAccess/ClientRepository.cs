using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Models;
using Clientele.Core.Models.Enums;
using Clientele.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess
{
    public class ClientRepository : DataAccess, IClientRepository
    {
        private readonly ISqlQueryProvider _sqlQueryProvider;

        public ClientRepository(
            IConfiguration configuration,
            ISqlQueryProvider sqlQueryProvider)
            : base(configuration)
        {
            _sqlQueryProvider = sqlQueryProvider;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = new List<Client>();

            string query =
                "SELECT"
                + " c.[Id],"
                + " c.[UniqueId],"
                + " c.[FirstName],"
                + " c.[MiddleName],"
                + " c.[LastName],"
                + " c.[Gender],"
                + " c.[DateOfBirth],"
                + " c.[CreatedOn],"
                + " c.[UpdatedOn],"
                + " c.[Status],"
                + " a.[UniqueId] AS AddressUniqueId,"
                + " a.[Residential],"
                + " a.[Work] AS WorkAddress,"
                + " a.[Postal],"
                + " co.[UniqueId] AS ContactUniqueId,"
                + " co.[Cell],"
                + " co.[Work] AS WorkContact"
                + " ROM[dbo].[Client] c"
                + " OIN[dbo].[Address] a"
                + " ON c.[AddressId] = a.[Id]"
                + " OIN[dbo].[Contact] co"
                + " ON c.[ContactId] = co.[Id];";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                clients.Add(new Client
                {
                    Id = reader.GetInt32(0),
                    UniqueId = reader.GetGuid(1),
                    FirstName = reader.GetString(2),
                    MiddleName = reader.GetString(3),
                    LastName = reader.GetString(4),
                    Gender = reader.GetString(5),
                    DateOfBirth = reader.GetDateTime(6),
                    CreatedOn = reader.GetDateTimeOffset(7),
                    UpdatedOn = reader.GetDateTimeOffset(8),
                    Status = reader.GetString(9),
                    Address = new Address
                    {
                        Id = reader.GetInt32(10),
                        UniqueId = reader.GetGuid(11),
                        Residential = reader.GetString(12),
                        Work = reader.GetString(13),
                        Postal = reader.GetString(14)
                    },
                    Contact = new Contact
                    {
                        Id = reader.GetInt32(15),
                        UniqueId = reader.GetGuid(16),
                        Cell = reader.GetString(17),
                        Work = reader.GetString(18)
                    }
                });
            }

            sqlConnection.Close();

            return clients;
        }

        public async Task CreateClientAsync(Client client)
        {
            client.CreatedOn = DateTimeOffset.UtcNow;
            client.Status = Status.Active.ToString();

            string query = _sqlQueryProvider.GetQueryByName("CreateClient");

            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@addressId", client.Address.UniqueId);
            command.Parameters.AddWithValue("@residential", client.Address.Residential);
            command.Parameters.AddWithValue("@workAddress", client.Address.Work);
            command.Parameters.AddWithValue("@postal", client.Address.Postal);
            command.Parameters.AddWithValue("@contactId", client.Contact.UniqueId);
            command.Parameters.AddWithValue("@cell", client.Contact.Cell);
            command.Parameters.AddWithValue("@workContact", client.Contact.Work);
            command.Parameters.AddWithValue("@uniqueId", client.UniqueId);
            command.Parameters.AddWithValue("@firstName", client.FirstName);
            command.Parameters.AddWithValue("@middleName", client.MiddleName ?? string.Empty);
            command.Parameters.AddWithValue("@lastName", client.LastName);
            command.Parameters.AddWithValue("@gender", client.Gender);
            command.Parameters.AddWithValue("@dateOfBirth", client.DateOfBirth);
            command.Parameters.AddWithValue("@createdOn", client.CreatedOn);
            command.Parameters.AddWithValue("@status", client.Status);

            sqlConnection.Open();
            await command.ExecuteNonQueryAsync();

            sqlConnection.Close();
        }
    }
}