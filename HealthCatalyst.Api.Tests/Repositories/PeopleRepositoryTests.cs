using System.Collections.Generic;
using System.Linq;
using HealthCatalyst.API.Models;
using HealthCatalyst.API.Repositories;
using HealthCatalyst.API.Tests.Helpers;
using Xunit;

namespace HealthCatalyst.API.Tests.Repositories
{
    public class PeopleRepositoryTests
    {
        public PeopleRepositoryTests()
        {

        }        

        [Fact]
        public void GetPeople()
        {
            //Arrange
            var context = ContextGetter.GetSqlServerContext();
            var peopleRepository = new PeopleRepository(context);
            var peopleCount = context.People.ToList().Count;

            //Act
            var people = peopleRepository.GetPeople();
            var person = people.ToList()[1];

            //Assert
            Assert.Equal(peopleCount, people.ToList().Count);
            Assert.Equal("Jamie", person.FirstName);
            Assert.Equal("Prugh", person.LastName);
            Assert.Equal("124 Rocky Brook Road", person.Address);
            Assert.Equal(8, person.Age);
            Assert.Equal(3, person.Interests.Count);
        }

        [Fact]
        public void GetPersonById()
        {
            //Arrange
            var context = ContextGetter.GetSqlServerContext();
            var peopleRepository = new PeopleRepository(context);
            int id = 3;

            //Act
            var person = peopleRepository.GetPersonById(id);

            //Assert
            Assert.Equal("Marie", person.FirstName);
            Assert.Equal("Collins", person.LastName);
            Assert.Equal("8 Elm Court", person.Address);
            Assert.Equal(32, person.Age);
            Assert.Equal(2, person.Interests.Count);
        }

        [Fact]
        public void GetPeopleByFirstOrLastName_Single()
        {
            //Arrange
            var context = ContextGetter.GetSqlServerContext();
            var peopleRepository = new PeopleRepository(context);
            string name = "Jamie";

            //Act
            var people = peopleRepository.GetPeopleByFirstOrLastName(name).ToList();
            var person = people[0];

            //Assert
            Assert.Single(people);
            Assert.Equal(name, person.FirstName);
            Assert.Equal(2, person.Id);
        }

        [Fact]
        public void GetPeopleByFirstOrLastName_Multiple()
        {
            //Arrange
            var context = ContextGetter.GetSqlServerContext();
            var peopleRepository = new PeopleRepository(context);
            string name = "Jack";

            //Act
            var people = peopleRepository.GetPeopleByFirstOrLastName(name).ToList();

            //Assert
            Assert.Equal(2, people.Count);
            Assert.Equal(name, people[0].FirstName);
            Assert.Equal(name, people[1].LastName);
        }
        [Fact]
        public void CreatePerson()
        {
            //Arrange
            var context = ContextGetter.GetSqlServerContext();
            var peopleRepository = new PeopleRepository(context);
            var person = new Person
            {
                FirstName = "Buttons",
                LastName = "May",
                Address = "1289 Oak Road",
                Age = 57,
                Interests = new List<Interest>
                {
                    new Interest
                    {
                        Value = "Jumping"
                    },
                    new Interest
                    {
                        Value = "Barking"
                    },
                    new Interest
                    {
                        Value = "Rope"
                    },
                    new Interest
                    {
                        Value = "Ball"
                    }
                }
            };
            var previousCount = context.People.ToList().Count;

            //Act
            using (var transaction = context.Database.BeginTransaction())
            {
                peopleRepository.CreatePerson(person);
                context.SaveChanges();

                //Assert
                Assert.Equal(previousCount + 1, context.People.ToList().Count);

                transaction.Rollback();
            }
        }
    }
}