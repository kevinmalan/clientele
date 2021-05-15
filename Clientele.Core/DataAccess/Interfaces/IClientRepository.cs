using Clientele.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<int> CreateClientAsync(Client client);

        Task CreateAddressesAsync(IEnumerable<Address> addresses);

        Task CreateContactsAsync(IEnumerable<Contact> contacts);
    }
}