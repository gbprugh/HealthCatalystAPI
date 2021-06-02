using System.Collections.Generic;
using HealthCatalyst.API.Models;

namespace HealthCatalyst.API.Repositories
{
    public class PersonSeeding
    {
        public static List<Person> PersonSeedData()
        {
            var people = new List<Person>
                {
                    new Person { Id = 1, FirstName = "Jack", LastName = "Cat", Address = "127 Elm Street", Age = 9 },
                    new Person { Id = 2, FirstName = "Jamie", LastName = "Prugh", Address = "124 Rocky Brook Road", Age = 8 },
                    new Person { Id = 3, FirstName = "Marie", LastName = "Collins", Address = "8 Elm Court", Age = 32 },
                    new Person { Id = 4, FirstName = "Geoff", LastName = "Jack", Address = "5 Elm Court", Age = 87 }
                };

            return people;
        }

        public static List<Interest> InterestSeedData()
        {
            return new List<Interest>
                {
                    new Interest
                    {
                        Id = 1,
                        Person_Id = 1,
                        Value = "Sleeping"
                    },
                    new Interest
                    {
                        Id = 2,
                        Person_Id = 2,
                        Value = "Eating"
                    },
                    new Interest
                    {
                        Id = 3,
                        Person_Id = 2,
                        Value = "Running"
                    },
                    new Interest
                    {
                        Id = 4,
                        Person_Id = 2,
                        Value = "Playing"
                    },
                    new Interest
                    {
                        Id = 5,
                        Person_Id = 3,
                        Value = "KPop"
                    },
                    new Interest
                    {
                        Id = 6,
                        Person_Id = 3,
                        Value = "Reading"
                    },
                    new Interest
                    {
                        Id = 7,
                        Person_Id = 4,
                        Value = "Reading"
                    }
                };
        }
    }
}