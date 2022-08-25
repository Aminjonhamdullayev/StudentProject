using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{
    [Table("Commands")]
    public class AminjonModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("HowTo")]
        public string? FirstName { get; set; }
        [Column("Platform")]
        public string? LastName { get; set; }
        [Column("CommandLine")]
        public string? Email { get; set; }

    }
}
