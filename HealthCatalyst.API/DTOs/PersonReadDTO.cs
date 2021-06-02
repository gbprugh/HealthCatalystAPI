using HealthCatalyst.API.Models;
using System.Collections.Generic;

namespace HealthCatalyst.API.DTOs
{
    public class PersonReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public ICollection<Interest> Interests { get; set; }
    }
}