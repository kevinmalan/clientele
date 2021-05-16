using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Models;
using Clientele.Core.Models.Enums;
using Clientele.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess
{
    public class ContactRepository : DataAccess, IContactRepository
    {
        private readonly ISqlQueryProvider _sqlQueryProvider;

        public ContactRepository(
            IConfiguration configuration,
            ISqlQueryProvider sqlQueryProvider
           ) : base(configuration)
        {
            _sqlQueryProvider = sqlQueryProvider;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(int clientId)
        {
            var contacts = new List<Contact>();

            string query = _sqlQueryProvider.GetQueryByName("GetContacts");
            query += " WHERE [ClientId] = @clientId ";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@clientId", clientId);

            sqlConnection.Open();
            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                contacts.Add(new Contact
                {
                    Id = reader.GetInt32(0),
                    UniqueId = reader.GetGuid(1),
                    ContactType = (ContactType)reader.GetInt32(2),
                    Msisdn = reader.GetString(3),
                    ClientId = reader.GetInt32(4)
                });
            }

            sqlConnection.Close();

            return contacts;
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