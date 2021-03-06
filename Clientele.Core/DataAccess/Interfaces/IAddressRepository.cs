using Clientele.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddressesAsync(int clientId);

        Task CreateAddressesAsync(IEnumerable<Address> addresses);
    }
}