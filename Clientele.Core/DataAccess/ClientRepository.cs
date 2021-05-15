using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Models;
using Clientele.Core.Models.Enums;
using Clientele.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            string query = _sqlQueryProvider.GetQueryByName("GetClients");

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
                    Gender = (Gender)reader.GetInt32(5),
                    DateOfBirth = reader.GetDateTime(6),
                    CreatedOn = reader.GetDateTimeOffset(7),
                    UpdatedOn = reader.IsDBNull(8) ? (DateTimeOffset?)null : reader.GetDateTimeOffset(8),
                    Status = (Status)reader.GetInt32(9)
                });
            }

            sqlConnection.Close();

            return clients;
        }

        public async Task<int> CreateClientAsync(Client client)
        {
            client.CreatedOn = DateTimeOffset.UtcNow;
            client.Status = Status.Active;

            string query = _sqlQueryProvider.GetQueryByName("CreateClient");

            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@uniqueId", client.UniqueId);
            command.Parameters.AddWithValue("@firstName", client.FirstName);
            command.Parameters.AddWithValue("@middleName", client.MiddleName ?? string.Empty);
            command.Parameters.AddWithValue("@lastName", client.LastName);
            command.Parameters.AddWithValue("@gender", client.Gender);
            command.Parameters.AddWithValue("@dateOfBirth", client.DateOfBirth);
            command.Parameters.AddWithValue("@createdOn", client.CreatedOn);
            command.Parameters.AddWithValue("@status", client.Status);

            sqlConnection.Open();
            var clientId = (int)await command.ExecuteScalarAsync();
            sqlConnection.Close();

            return clientId;
        }

        public async Task CreateAddressesAsync(IEnumerable<Address> addresses)
        {
            string query = _sqlQueryProvider.GetQueryByName("CreateAddress");

            sqlConnection.Open();

            foreach (var address in addresses)
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@uniqueId", address.UniqueId);
                command.Parameters.AddWithValue("@addressType", address.AddressType);
                command.Parameters.AddWithValue("@line11", address.Line1);
                command.Parameters.AddWithValue("@line2", address.Line2 ?? string.Empty);
                command.Parameters.AddWithValue("@line3", address.Line3 ?? string.Empty);
                command.Parameters.AddWithValue("@city", address.City);
                command.Parameters.AddWithValue("@stateProvince", address.StateProvince);
                command.Parameters.AddWithValue("@areaCode", address.AreaCode);
                command.Parameters.AddWithValue("@country", address.Country);
                command.Parameters.AddWithValue("@clientId", address.ClientId);

                await command.ExecuteNonQueryAsync();
            }

            sqlConnection.Close();
        }

        public async Task CreateContactsAsync(IEnumerable<Contact> contacts)
        {
            string query = _sqlQueryProvider.GetQueryByName("CreateContact");

            sqlConnection.Open();

            foreach (var contact in contacts)
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@uniqueId", contact.UniqueId);
                command.Parameters.AddWithValue("@contactType", contact.ContactType);
                command.Parameters.AddWithValue("@msisdn", contact.Msisdn);
                command.Parameters.AddWithValue("@clientId", contact.ClientId);

                await command.ExecuteNonQueryAsync();
            }

            sqlConnection.Close();
        }
    }
}