using StudentProject.Models;

namespace StudentProject.IContract
{
    public interface IAminjonService
    {

        Task<ResponseModel<List<AminjonModel>>> GetAminjonModels();
        Task<ResponseModel<AminjonModel>> Update(AminjonModel student);
        Task<ResponseModel<AminjonModel>> Delete(int id);
        Task<ResponseModel<AminjonModel>> CreatAminjon(AminjonModel student);
        Task<ResponseModel<AminjonModel>> AminjonToPostgres(int id);
    }
}
