using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public ContactType ContactType { get; set; }
        public string Msisdn { get; set; }
        public int ClientId { get; set; }
    }
}