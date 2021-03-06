using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public AddressType AddressType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string AreaCode { get; set; }
        public string Country { get; set; }
        public int ClientId { get; set; }
    }
}