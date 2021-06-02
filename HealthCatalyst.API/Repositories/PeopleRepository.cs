using HealthCatalyst.API.Contexts;
using HealthCatalyst.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthCatalyst.API.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PersonContext _context;

        public PeopleRepository(PersonContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person pers)
        {
            if (pers == null)
            {
                throw new ArgumentNullException(nameof(pers));
            }

            _context.People.Add(pers);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.People.Include(p => p.Interests);
        }

        public Person GetPersonById(int id)
        {
            return _context.People.Include(p => p.Interests).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Person> GetPeopleByFirstOrLastName(string name)
        {
            return _context.People.Include(p => p.Interests).Where(n => n.FirstName == name || n.LastName == name);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}