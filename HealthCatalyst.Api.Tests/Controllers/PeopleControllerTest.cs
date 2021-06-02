using AutoMapper;
using HealthCatalyst.API.Contexts;
using HealthCatalyst.API.Controllers;
using HealthCatalyst.API.DTOs;
using HealthCatalyst.API.MappingProfiles;
using HealthCatalyst.API.Repositories;
using HealthCatalyst.API.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HealthCatalyst.API.Tests.Controllers
{
    public class PeopleControllerTest
    {
        private readonly PeopleController _peopleController;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IPeopleRepository _peopleRepository;
        private readonly PersonContext _context;

        public PeopleControllerTest()
        {
            _mapperConfiguration = new MapperConfiguration(opt => opt.AddProfile(new PeopleMappingProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _context = ContextGetter.GetSqlServerContext();
            _peopleRepository = new PeopleRepository(_context);
            _peopleController = new PeopleController(_peopleRepository, _mapper);
        }

        [Fact]
        public void GetPeople()
        {
            //Arrange

            //Act
            var response = _peopleController.GetPeople();

            //Assert
            Assert.NotNull(response);
            Assert.True(response is OkObjectResult);
        }

        [Fact]
        public void GetPersonById_Valid()
        {
            //Arrange
            int id = 1;

            //Act
            var response = _peopleController.GetPersonById(id);

            //Assert
            Assert.NotNull(response);
            Assert.True(response is OkObjectResult);
        }

        [Fact]
        public void GetPersonById_Invalid()
        {
            //Arrange
            int id = -1;

            //Act
            var response = _peopleController.GetPersonById(id);

            //Assert
            Assert.NotNull(response);
            Assert.True(response is NotFoundResult);
        }

        [Fact]
        public void GetPersonByName_Valid()
        {
            //Arrange
            string name = "Marie";

            //Act
            var response = _peopleController.GetPersonByName(name);

            //Assert
            Assert.NotNull(response);
            Assert.True(response is OkObjectResult);
        }

        [Fact]
        public void GetPersonByName_Invalid()
        {
            //Arrange
            string name = "-1";

            //Act
            var response = _peopleController.GetPersonByName(name);

            //Assert
            Assert.NotNull(response);
            Assert.True(response is NotFoundResult);
        }

        [Fact]
        public void CreatePerson()
        {
            //Arrange
            var createdPerson = new PersonCreateDTO
            {
                FirstName = "Rufus-Xavier",
                LastName = "Sasparilla",
                Address = "74682 Pronoun Place",
                Age = 99
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                //Act
                var response = _peopleController.CreatePerson(createdPerson);

                //Assert
                Assert.NotNull(response);
                Assert.True(response is CreatedAtRouteResult);

                transaction.Rollback();
            }
        }
    }
}
