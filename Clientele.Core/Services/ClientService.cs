using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Dtos;
using Clientele.Core.Models;
using Clientele.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientele.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync()
        {
            var clientDtos = new List<ClientDto>();
            var clients = await _clientRepository.GetClientsAsync();

            foreach (var client in clients)
            {
                clientDtos.Add(new ClientDto
                {
                    UniqueId = client.UniqueId,
                    FirstName = client.FirstName,
                    MiddleName = client.MiddleName,
                    LastName = client.LastName,
                    Gender = client.Gender,
                    DateOfBirth = client.DateOfBirth,
                    AddressUniqueId = client.Address.UniqueId,
                    Residential = client.Address.Residential,
                    WorkAddress = client.Address.Work,
                    Postal = client.Address.Postal,
                    ContactUniqueId = client.Contact.UniqueId,
                    Cell = client.Contact.Cell,
                    WorkContact = client.Contact.Work
                });
            }

            return clientDtos;
        }

        public async Task CreateClientAsync(CreateClientDto createClietnDto)
        {
            var client = new Client
            {
                UniqueId = Guid.NewGuid(),
                FirstName = createClietnDto.FirstName,
                MiddleName = createClietnDto.MiddleName,
                LastName = createClietnDto.LastName,
                Gender = createClietnDto.Gender,
                DateOfBirth = createClietnDto.DateOfBirth,
                Address = new Address
                {
                    UniqueId = Guid.NewGuid(),
                    Postal = createClietnDto.Postal,
                    Residential = createClietnDto.Residential,
                    Work = createClietnDto.WorkAddress
                },
                Contact = new Contact
                {
                    UniqueId = Guid.NewGuid(),
                    Cell = createClietnDto.Cell,
                    Work = createClietnDto.WorkAddress
                }
            };

            await _clientRepository.CreateClientAsync(client);
        }
    }
}