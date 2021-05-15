using Clientele.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.DataAccess.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();

        Task CreateContactsAsync(IEnumerable<Contact> contacts);
    }
}