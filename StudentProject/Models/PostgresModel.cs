using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentProject.Models
{
    [Table("commands")]
    public class PostgresModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("howto")]
        public string? FirstName { get; set; }
        [Column("platform")]
        public string? LastName { get; set; }
        [Column("commandline")]
        public string? Email { get; set; }

        public static implicit operator PostgresModel(List<PostgresModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
