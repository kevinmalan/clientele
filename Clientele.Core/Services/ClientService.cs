using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Dtos;
using Clientele.Core.Models;
using Clientele.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientele.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;

        public ClientService(
            IClientRepository clientRepository,
            IAddressRepository addressRepository,
            IContactRepository contactRepository
           )
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync()
        {
            var clientDtos = new List<ClientDto>();
            var addressDtos = new List<AddressDto>();
            var contactDtos = new List<ContactDto>();
            var clients = await _clientRepository.GetClientsAsync();
            var addresses = await _addressRepository.GetAddressesAsync();
            var contacts = await _contactRepository.GetContactsAsync();

            foreach (var address in addresses)
            {
                addressDtos.Add(new AddressDto
                {
                    UniqueId = address.UniqueId,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Line3 = address.Line3,
                    AddressType = address.AddressType,
                    AreaCode = address.AreaCode,
                    City = address.City,
                    Country = address.Country,
                    StateProvince = address.StateProvince
                });
            }

            foreach (var contact in contacts)
            {
                contactDtos.Add(new ContactDto
                {
                    UniqueId = contact.UniqueId,
                    ContactType = contact.ContactType,
                    Msisdn = contact.Msisdn
                });
            }

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
                    AddressesDto = addressDtos,
                    ContactsDto = contactDtos
                });
            }

            return clientDtos;
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

            await _addressRepository.CreateAddressesAsync(addresses);
            await _contactRepository.CreateContactsAsync(contacts);
        }
    }
}