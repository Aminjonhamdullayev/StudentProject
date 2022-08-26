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
        public async Task<ResponseModel<AminjonModel>> AminjonToPostgres(int id)
        {
            ResponseModel<AminjonModel> _response = new ResponseModel<AminjonModel>();
            try
            {
                var Amin = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(x => x.Id == id);
                var Postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(x => x.Id == id);

                if (Postgres == null && Amin != null)
                {
                    PostgresModel postgresModel = new PostgresModel();
                    postgresModel.Id = Amin.Id;
                    postgresModel.FirstName = Amin.FirstName;
                    postgresModel.LastName = Amin.LastName;
                    postgresModel.Email = Amin.Email;

                    await _postgresDbContext.postgresModels.AddAsync(postgresModel);
                    await _postgresDbContext.SaveChangesAsync();
                    _aminjonDbContext.Remove(Amin);
                    await _aminjonDbContext.SaveChangesAsync();

                    _response.Data = Amin;
                    _response.StatusCode = 200;
                    _response.Message = "success";
                }

                if (Postgres != null)
                {
                    _response.StatusCode = 202;
                    _response.Data = Amin;
                    _response.Message = "Bu ID foydalanilgan";
                }
            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.Message = ex.Message;
                _response.StatusCode = 500;
            }
            return _response;
        }

        public async Task<ResponseModel<AminjonModel>> CreatAminjon(AminjonModel student)
        {
            ResponseModel<AminjonModel> response = new ResponseModel<AminjonModel>();
            try
            {
                AminjonModel? aminjon = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(aminjon => aminjon.Id == student.Id);
                if (aminjon != null)
                {
                    response.StatusCode = 202;
                    response.Data = aminjon;
                    response.Message = "Bu ID foydalanilgan";
                }
                if (aminjon == null)
                {
                    await _aminjonDbContext.aminjonModels.AddAsync(student);
                    await _aminjonDbContext.SaveChangesAsync();

                    response.Data = student;
                    response.StatusCode = 200;
                    response.Message = "success";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<ResponseModel<AminjonModel>> Delete(int id)
        {
            ResponseModel<AminjonModel> response = new ResponseModel<AminjonModel>();
            try
            {
                AminjonModel? aminjon = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(aminjon => aminjon.Id == id);
                if (aminjon != null)
                {
                    _aminjonDbContext.Remove(aminjon);
                    await _aminjonDbContext.SaveChangesAsync();

                    response.StatusCode = 200;
                    response.Message = "success";
                    response.Data = aminjon;
                }
                if (aminjon == null)
                {
                    response.StatusCode = 404;
                    response.Message = "Not found";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<ResponseModel<List<AminjonModel>>> GetAminjonModels()
        {
            ResponseModel<List<AminjonModel>> response = new ResponseModel<List<AminjonModel>>();
            try
            {
                List<AminjonModel> model = await _aminjonDbContext.aminjonModels.ToListAsync();
                response.StatusCode = 200;
                response.Message = "success";
                response.Data = model;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }


        public async Task<ResponseModel<AminjonModel>> Update(AminjonModel student)
        {
            ResponseModel<AminjonModel> response = new ResponseModel<AminjonModel>();
            try
            {
                AminjonModel? aminjon = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(x => x.Id == student.Id);

                if (aminjon != null)
                {
                    aminjon.FirstName = student.FirstName;
                    aminjon.LastName = student.LastName;
                    aminjon.Email = student.Email;
                    await _aminjonDbContext.SaveChangesAsync();

                    response.Data = aminjon;
                    response.StatusCode = 200;
                    response.Message = "success";
                }

                if (aminjon == null)
                {
                    response.StatusCode = 202;
                    response.Data = aminjon;
                    response.Message = "Bu ID foydalanilgan";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }


    }
}
