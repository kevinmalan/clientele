using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Models
{
    public class Client
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Status Status { get; set; }
    }
}