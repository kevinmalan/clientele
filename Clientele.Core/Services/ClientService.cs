using Clientele.Core.Dtos;
using Clientele.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientele.Core.Services
{
    public class ClientService : IClientService
    {
        public Task<Guid> CreateClientAsync(CreateClientDto createClientDto)
        {
            throw new NotImplementedException();
        }
    }
}