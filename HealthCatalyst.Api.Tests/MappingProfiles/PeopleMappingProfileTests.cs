using AutoMapper;
using HealthCatalyst.API.DTOs;
using HealthCatalyst.API.MappingProfiles;
using HealthCatalyst.API.Models;
using Xunit;

namespace HealthCatalyst.API.Tests.MappingProfiles
{
    public class PeopleMappingProfileTests
    {
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public PeopleMappingProfileTests()
        {
            _mapperConfiguration = new MapperConfiguration(opt => opt.AddProfile(new PeopleMappingProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void ValidateMapperConfiguration()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [Fact]
        public void PersonToPersonReadDTO()
        {
            //Arrange
            var person = new Person 
            { 
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "12345 Real Drive",
                Age = 85,
                Interests = new[] 
                { 
                    new Interest 
                    { 
                        Value = "Interest",
                        Person_Id = 1
                    }
                }
            };

            //Act
            var result = _mapper.Map<PersonReadDTO>(person);

            //Assert
            Assert.Equal(person.FirstName, result.FirstName);
            Assert.Equal(person.LastName, result.LastName);
            Assert.Equal(person.Address, result.Address);
            Assert.Equal(person.Age, result.Age);
            Assert.Collection(result.Interests, v => v.Value.Equals("Interest"));
            Assert.Collection(result.Interests, p => p.Person_Id.Equals(1));
        }

        [Fact]
        public void PersonCreateDTOToPerson()
        {
            //Arrange
            var personCreateDTO = new PersonCreateDTO
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "12345 Real Drive",
                Age = 85,
                Interests = new[]
                {
                    new Interest
                    {
                        Value = "Interest",
                        Person_Id = 1
                    }
                }
            };

            //Act
            var result = _mapper.Map<Person>(personCreateDTO);

            //Assert
            Assert.Equal(personCreateDTO.FirstName, result.FirstName);
            Assert.Equal(personCreateDTO.LastName, result.LastName);
            Assert.Equal(personCreateDTO.Address, result.Address);
            Assert.Equal(personCreateDTO.Age, result.Age);
            Assert.Collection(result.Interests, v => v.Equals("Interest"));
            Assert.Collection(result.Interests, p => p.Person_Id.Equals(1));
        }
    }
}