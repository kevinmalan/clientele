using Clientele.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace Clientele.Core.Services.Interfaces
{
    public interface IClientService
    {
        public Task<Guid> CreateClientAsync(CreateClientDto createClientDto);
    }
}