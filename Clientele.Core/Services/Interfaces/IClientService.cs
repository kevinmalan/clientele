using Clientele.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clientele.Core.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClientsAsync();

        public Task CreateClientAsync(CreateClientDto createClientDto);
    }
}