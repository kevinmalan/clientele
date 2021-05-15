using Clientele.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task CreateClientAsync(Client client);
    }
}