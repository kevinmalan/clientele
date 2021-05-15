using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Dtos
{
    public class ClientDto
    {
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid AddressUniqueId { get; set; }
        public string Residential { get; set; }
        public string WorkAddress { get; set; }
        public string Postal { get; set; }
        public Guid ContactUniqueId { get; set; }
        public string Cell { get; set; }
        public string WorkContact { get; set; }
    }
}