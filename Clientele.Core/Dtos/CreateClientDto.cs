using Clientele.Core.Models.Enums;
using System;
using System.Collections.Generic;

namespace Clientele.Core.Dtos
{
    public class CreateClientDto
    {
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<AddressDto> AddressesDto { get; set; }
        public IEnumerable<ContactDto> ContactsDto { get; set; }
    }
}