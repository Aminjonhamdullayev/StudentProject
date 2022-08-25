using Microsoft.EntityFrameworkCore;
using StudentProject.Database;
using StudentProject.IContract;
using StudentProject.Models;

namespace StudentProject.Service
{
    public class PostgresService : IPostgresService
    {
        private readonly PostgresDbContext _postgresDbContext;
        private readonly AminjonDbContext _aminjonDbContext;
        public PostgresService(PostgresDbContext postgresDbContext, AminjonDbContext aminjonDbContext)
        {
            _postgresDbContext = postgresDbContext;
            _aminjonDbContext = aminjonDbContext;
        }
        public async Task<PostgresModel> CreatPostgres(PostgresModel student)
        {
            await _postgresDbContext.postgresModels.AddAsync(student);
            await _postgresDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<PostgresModel> Delete(int id)
        {
            PostgresModel? postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(postgres => postgres.Id == id);
            _postgresDbContext.postgresModels.Remove(postgres);
            await _postgresDbContext.SaveChangesAsync();
            return postgres;
        }

        public async Task<List<PostgresModel>> GetPostgresModels()
        {
            List<PostgresModel> models = await _postgresDbContext.postgresModels.ToListAsync();
            return models;
        }

        public async Task<PostgresModel> Update(PostgresModel student)
        {
            PostgresModel? postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(x => x.Id == student.Id);
            postgres.FirstName = student.FirstName;
            postgres.LastName = student.LastName;
            postgres.Email = student.Email;
            await _postgresDbContext.SaveChangesAsync();
            return student;
        }
    }
}
