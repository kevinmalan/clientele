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
                    DateOfBirth = client.DateOfBirth
                });
            }

            return clientDtos; // TODO: Add Address & Contact dto collections
        }

        public async Task CreateClientAsync(CreateClientDto createClietnDto)
        {
            var addresses = new List<Address>();
            var contacts = new List<Contact>();
            var client = new Client
            {
                UniqueId = Guid.NewGuid(),
                FirstName = createClietnDto.FirstName,
                MiddleName = createClietnDto.MiddleName,
                LastName = createClietnDto.LastName,
                Gender = createClietnDto.Gender,
                DateOfBirth = createClietnDto.DateOfBirth
            };

            var clientId = await _clientRepository.CreateClientAsync(client);

            foreach (var address in createClietnDto.AddressesDto)
            {
                addresses.Add(new Address
                {
                    UniqueId = Guid.NewGuid(),
                    AddressType = address.AddressType,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    AreaCode = address.AreaCode,
                    City = address.City,
                    StateProvince = address.StateProvince,
                    Country = address.Country,
                    ClientId = clientId
                });
            }

            foreach (var contact in createClietnDto.ContactsDto)
            {
                contacts.Add(new Contact
                {
                    UniqueId = Guid.NewGuid(),
                    ContactType = contact.ContactType,
                    Msisdn = contact.Msisdn,
                    ClientId = clientId
                });
            }

            await _clientRepository.CreateAddressesAsync(addresses);
            await _clientRepository.CreateContactsAsync(contacts);
        }
    }
}