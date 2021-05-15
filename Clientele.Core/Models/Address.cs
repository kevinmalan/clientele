using System;

namespace Clientele.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Residential { get; set; }
        public string Work { get; set; }
        public string Postal { get; set; }
    }
}