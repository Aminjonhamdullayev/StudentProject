using StudentProject.Models;

namespace StudentProject.IContract
{
    public interface IPostgresService
    {

        Task<ResponseModel<List<PostgresModel>>> GetPostgresModels();
        Task<ResponseModel<PostgresModel>> Update(PostgresModel student);
        Task<ResponseModel<PostgresModel>> Delete(int id);
        Task<ResponseModel<PostgresModel>> CreatPostgres(PostgresModel student);
        Task<ResponseModel<PostgresModel>> PostgresToAminjon(int id);
    }
}
