using Clientele.Core.Models.Enums;
using System;

namespace Clientele.Core.Dtos
{
    public class ContactDto
    {
        public Guid UniqueId { get; set; }
        public ContactType ContactType { get; set; }
        public string Msisdn { get; set; }
    }
}