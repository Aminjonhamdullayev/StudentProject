using StudentProject.Models;

namespace StudentProject.IContract
{
    public interface IPostgresService
    {
        Task<PostgresModel> CreatPostgres(PostgresModel student);
        Task<List<PostgresModel>> GetPostgresModels();
        Task<PostgresModel> Update(PostgresModel student);
        Task<PostgresModel> Delete(int id);
    }
}
