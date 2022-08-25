using Microsoft.EntityFrameworkCore;
using StudentProject.Database;
using StudentProject.IContract;
using StudentProject.Models;

namespace StudentProject.Service
{
    public class AminjonService : IAminjonService
    {
        private readonly AminjonDbContext _aminjonDbContext;
        private readonly PostgresDbContext _postgresDbContext;
        public AminjonService(AminjonDbContext aminjonDbContext, PostgresDbContext postgresDbContext)
        {
            _aminjonDbContext = aminjonDbContext;
            _postgresDbContext = postgresDbContext;
        }

        public async Task<AminjonModel> CreatAminjon(AminjonModel student)
        {
            await _aminjonDbContext.aminjonModels.AddAsync(student);
            await _aminjonDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<AminjonModel> Delete(int id)
        {
            AminjonModel? aminjon = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(aminjon => aminjon.Id == id);
            _aminjonDbContext.aminjonModels.Remove(aminjon);
            await _aminjonDbContext.SaveChangesAsync();
            return aminjon;

        }

        public async Task<List<AminjonModel>> GetAminjonModels()
        {
            List<AminjonModel> models = await _aminjonDbContext.aminjonModels.ToListAsync();
            return models;
        }

        public async Task<AminjonModel> Update(AminjonModel student)
        {
            AminjonModel? aminjon = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(x => x.Id == student.Id);
            aminjon.FirstName = student.FirstName;
            aminjon.LastName = student.LastName;
            aminjon.Email = student.Email;
            await _aminjonDbContext.SaveChangesAsync();
            return student;
        }
    }
}
