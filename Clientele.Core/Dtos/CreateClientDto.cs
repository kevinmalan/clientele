using Clientele.Core.Models;
using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Dtos
{
    public class CreateClientDto
    {
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }
}