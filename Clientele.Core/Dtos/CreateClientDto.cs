﻿using System;

namespace Clientele.Core.Dtos
{
    public class CreateClientDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Residential { get; set; }
        public string WorkAddress { get; set; }
        public string Postal { get; set; }
        public string Cell { get; set; }
        public string WorkContact { get; set; }
    }
}