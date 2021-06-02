using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCatalyst.API.Models
{
    [Table(name: "Interest", Schema = "dbo")]
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int Person_Id { get; set; }

        public string Value { get; set; }

        public Person Person { get; set; }
    }
}