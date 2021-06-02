using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCatalyst.API.Models
{
    [Table(name: "People", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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