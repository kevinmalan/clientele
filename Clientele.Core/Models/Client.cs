using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string Status { get; set; }
    }
}