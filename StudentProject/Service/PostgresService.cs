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
        public async Task<ResponseModel<PostgresModel>> PostgresToAminjon(int id)
        {
            ResponseModel<PostgresModel> response = new ResponseModel<PostgresModel>();
            try
            {
                var Postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(x => x.Id == id);
                var Amin = await _aminjonDbContext.aminjonModels.FirstOrDefaultAsync(x => x.Id == id);

                if (Amin == null && Postgres != null)
                {
                    AminjonModel aminjonModel = new AminjonModel();
                    aminjonModel.Id = Postgres.Id;
                    aminjonModel.FirstName = Postgres.FirstName;
                    aminjonModel.LastName = Postgres.LastName;
                    aminjonModel.Email = Postgres.Email;

                    await _aminjonDbContext.aminjonModels.AddAsync(aminjonModel);
                    await _aminjonDbContext.SaveChangesAsync();
                    _postgresDbContext.Remove(Postgres);
                    await _postgresDbContext.SaveChangesAsync();

                    response.Data = Postgres;
                    response.StatusCode = 200;
                    response.Message = "success";

                }
                if (Amin != null)
                {
                    response.StatusCode = 202;
                    response.Data = Postgres;
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
        public async Task<ResponseModel<PostgresModel>> CreatPostgres(PostgresModel student)
        {
            ResponseModel<PostgresModel> response = new ResponseModel<PostgresModel>();
            try
            {
                PostgresModel? postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(postgres => postgres.Id == student.Id);
                if (postgres != null)
                {
                    response.StatusCode = 202;
                    response.Data = postgres;
                    response.Message = "Bu ID foydalanilgan";
                }
                if (postgres == null)
                {
                    await _postgresDbContext.postgresModels.AddAsync(student);
                    await _postgresDbContext.SaveChangesAsync();

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

        public async Task<ResponseModel<List<PostgresModel>>> GetPostgresModels()
        {
            ResponseModel<List<PostgresModel>> response = new ResponseModel<List<PostgresModel>>();
            try
            {
                List<PostgresModel> model = await _postgresDbContext.postgresModels.ToListAsync();
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

        public async Task<ResponseModel<PostgresModel>> Update(PostgresModel student)
        {
            ResponseModel<PostgresModel> response = new ResponseModel<PostgresModel>();
            try
            {
                PostgresModel? postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(x => x.Id == student.Id);
                if (postgres != null)
                {
                    postgres.FirstName = student.FirstName;
                    postgres.LastName = student.LastName;
                    postgres.Email = student.Email;
                    await _postgresDbContext.SaveChangesAsync();
                    // return student;

                    response.Data = student;
                    response.StatusCode = 200;
                    response.Message = "success";
                }
                if (postgres == null)
                {
                    response.StatusCode = 202;
                    response.Data = student;
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

        public async Task<ResponseModel<PostgresModel>> Delete(int id)
        {
            ResponseModel<PostgresModel> response = new ResponseModel<PostgresModel>();
            try
            {
                PostgresModel? postgres = await _postgresDbContext.postgresModels.FirstOrDefaultAsync(postgres => postgres.Id == id);

                if (postgres != null)
                {
                    _postgresDbContext.postgresModels.Remove(postgres);
                    await _postgresDbContext.SaveChangesAsync();

                    response.StatusCode = 200;
                    response.Message = "success";
                    response.Data = postgres;
                }

                if (postgres == null)
                {
                    response.StatusCode = 404;
                    response.Message = "Not found";
                    response.Data = null;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = 500;
                response.Data = null;
            }
            return response;
        }

    }
}
