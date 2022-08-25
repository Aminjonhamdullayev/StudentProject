using StudentProject.Models;

namespace StudentProject.IContract
{
    public interface IAminjonService
    {
        Task<List<AminjonModel>> GetAminjonModels();
        Task<AminjonModel> Update(AminjonModel student);
        Task<AminjonModel> Delete(int id);
        Task<AminjonModel> CreatAminjon(AminjonModel studentModel);
    }
}
