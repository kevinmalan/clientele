using Clientele.Core.Models.Enums;
using System;
using System.Collections.Generic;

namespace Clientele.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}