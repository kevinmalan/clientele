using Clientele.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClientsAsync();

        public Task CreateClientAsync(CreateClientDto createClientDto);

        string ToCsvBody(IEnumerable<ClientDto> clients);

        string ToCsvheader(IEnumerable<ClientDto> clients);
    }
}