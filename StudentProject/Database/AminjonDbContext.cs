using Microsoft.EntityFrameworkCore;
using StudentProject.Models;

namespace StudentProject.Database
{
    public class AminjonDbContext : DbContext
    {
        public AminjonDbContext(DbContextOptions<AminjonDbContext> options) : base(options) { }

        public DbSet<AminjonModel> aminjonModels { get; set; }      
    }
}
