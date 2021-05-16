using Clientele.Core.DataAccess.Interfaces;
using Clientele.Core.Dtos;
using Clientele.Core.Models.Enums;
using Clientele.Core.Services;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Clientele.Tests
{
    public class CsvWriterTests
    {
        [Fact]
        public void WriteCsv_WhenClientObject_ShouldReturnCommaDelimitedHeader()
        {
            // Arrange
            var clientRepoMock = Substitute.For<IClientRepository>();
            var addressRepoMock = Substitute.For<IAddressRepository>();
            var contactRepoMock = Substitute.For<IContactRepository>();
            var clientService = new ClientService(clientRepoMock, addressRepoMock, contactRepoMock);
            var clientDtos = new List<ClientDto>
            {
                new ClientDto
                {
                    UniqueId = Guid.NewGuid(),
                    FirstName = "Foo",
                    LastName = "Bar",
                    Gender = Gender.Female,
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    AddressesDto = new List<AddressDto>
                    {
                        new AddressDto
                        {
                            UniqueId = Guid.NewGuid(),
                            AddressType = AddressType.Residential,
                            AreaCode = "0081",
                            City = "Pretoria",
                            Country = "South Africa",
                            StateProvince = "Gauteng",
                            Line1 = "6 Camelia Avenue",
                            Line2 = "Glenwood Village",
                            Line3 = "Lynnwood"
                        }
                    }
                },
                new ClientDto
                {
                    UniqueId = Guid.NewGuid(),
                    FirstName = "Foo",
                    LastName = "Bar",
                    Gender = Gender.Female,
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    AddressesDto = new List<AddressDto>
                    {
                        new AddressDto
                        {
                            UniqueId = Guid.NewGuid(),
                            AddressType = AddressType.Residential,
                            AreaCode = "0081",
                            City = "Pretoria",
                            Country = "South Africa",
                            StateProvince = "Gauteng",
                            Line1 = "7 Camelia Avenue",
                            Line2 = "Glenwood Village",
                            Line3 = "Lynnwood"
                        },
                        new AddressDto
                        {
                            UniqueId = Guid.NewGuid(),
                            AddressType = AddressType.Residential,
                            AreaCode = "0081",
                            City = "Pretoria",
                            Country = "South Africa",
                            StateProvince = "Gauteng",
                            Line1 = "8 Camelia Avenue",
                            Line2 = "Glenwood Village",
                            Line3 = "Lynnwood"
                        }
                    }
                },
                new ClientDto
                {
                    UniqueId = Guid.NewGuid(),
                    FirstName = "Foo",
                    LastName = "Bar",
                    Gender = Gender.Female,
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    AddressesDto = new List<AddressDto>
                    {
                        new AddressDto
                        {
                            UniqueId = Guid.NewGuid(),
                            AddressType = AddressType.Residential,
                            AreaCode = "0081",
                            City = "Pretoria",
                            Country = "South Africa",
                            StateProvince = "Gauteng",
                            Line1 = "9 Camelia Avenue",
                            Line2 = "Glenwood Village",
                            Line3 = "Lynnwood"
                        }
                    }
                }
            };

            // Act
            var header = clientService.ToCsvheader(clientDtos);

            // Assert
            header.ShouldBe("UniqueId,FirstName,MiddleName,LastName,Gender,DateOfBirth,AddressUniqueId,AddressType,Line1,Line2,Line3,City,StateProvince,AreaCode,Country,AddressUniqueId,AddressType,Line1,Line2,Line3,City,StateProvince,AreaCode,Country,");
        }
    }
}