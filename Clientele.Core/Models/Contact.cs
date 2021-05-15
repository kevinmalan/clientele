using System;

namespace Clientele.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Cell { get; set; }
        public string Work { get; set; }
    }
}