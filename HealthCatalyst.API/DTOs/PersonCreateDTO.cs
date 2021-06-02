using HealthCatalyst.API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalyst.API.DTOs
{
    public class PersonCreateDTO
    {
        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(120)]
        public string Address { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        public ICollection<Interest> Interests { get; set; }
    }
}