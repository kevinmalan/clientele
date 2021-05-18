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
                    CreatedOn = reader.GetDateTimeOffset(6),
                    UpdatedOn = reader.IsDBNull(7) ? (DateTimeOffset?)null : reader.GetDateTimeOffset(7),
                    Status = (Status)reader.GetInt32(8)
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
            command.Parameters.AddWithValue("@createdOn", client.CreatedOn);
            command.Parameters.AddWithValue("@status", client.Status);

            sqlConnection.Open();
            var clientId = (int)await command.ExecuteScalarAsync();
            sqlConnection.Close();

            return clientId;
        }
    }
}