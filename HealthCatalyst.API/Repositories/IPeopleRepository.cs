using System.Collections.Generic;
using HealthCatalyst.API.Models;

namespace HealthCatalyst.API.Repositories
{
    public interface IPeopleRepository
    {
        bool SaveChanges();
        IEnumerable<Person> GetPeople();
        public Person GetPersonById(int id);
        IEnumerable<Person> GetPeopleByFirstOrLastName(string name);
        void CreatePerson(Person pers);
    }
}