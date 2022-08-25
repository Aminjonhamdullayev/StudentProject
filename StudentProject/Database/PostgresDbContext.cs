using Microsoft.EntityFrameworkCore;
using StudentProject.Models;

namespace StudentProject.Database
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        public DbSet<PostgresModel> postgresModels{ get; set; }
    }
}
