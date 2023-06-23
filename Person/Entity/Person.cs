using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person.Entity
{
    [Table("Person")]
    public class Person
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("MiddleName")]
        public string MiddleName { get; set; }

        [Required]
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("Gender")]
        public string Gender { get; set; }

        [Required]
        [Column("Location")]
        public string Location { get; set; }
    }
}

