using Clientele.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clientele.Core.Dtos
{
    public class AddressDto
    {
        public Guid UniqueId { get; set; }
        public AddressType AddressType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string AreaCode { get; set; }
        public string Country { get; set; }
    }
}