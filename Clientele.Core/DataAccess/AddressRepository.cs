using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Dtos;
using Clientele.Core.Models;
using Clientele.Core.Models.Enums;
using Clientele.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess
{
    public class AddressRepository : DataAccess, IAddressRepository
    {
        private readonly ISqlQueryProvider _sqlQueryProvider;

        public AddressRepository(
            IConfiguration configuration,
            ISqlQueryProvider sqlQueryProvider
           ) : base(configuration)
        {
            _sqlQueryProvider = sqlQueryProvider;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            var addresses = new List<Address>();

            string query = _sqlQueryProvider.GetQueryByName("GetAddresses");

            SqlCommand command = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                addresses.Add(new Address
                {
                    Id = reader.GetInt32(0),
                    UniqueId = reader.GetGuid(1),
                    AddressType = (AddressType)reader.GetInt32(2),
                    Line1 = reader.GetString(3),
                    Line2 = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Line3 = reader.GetString(5),
                    City = reader.GetString(6),
                    StateProvince = reader.GetString(7),
                    AreaCode = reader.GetString(8),
                    Country = reader.GetString(9),
                    ClientId = reader.GetInt32(10)
                });
            }

            sqlConnection.Close();

            return addresses;
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
                command.Parameters.AddWithValue("@line1", address.Line1);
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
    }
}