using Microsoft.AspNetCore.Mvc;
using StudentProject.IContract;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IPostgresService _postgresService;
        private readonly IAminjonService _aminjonService;

        public HomeController(IPostgresService postgresService, IAminjonService aminjonService)
        {
            _aminjonService = aminjonService;
            _postgresService = postgresService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAminjon(AminjonModel student)
        {
            ResponseModel<AminjonModel> studentModel2 = await _aminjonService.CreatAminjon(student);
            return Ok(studentModel2);
        }
        [HttpPost]
        public async Task<IActionResult> CreatPostgres(PostgresModel studentModel)
        {
            ResponseModel<PostgresModel> studentModel1 = await _postgresService.CreatPostgres(studentModel);
            return Ok(studentModel1);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAminjon(int id)
        {
            ResponseModel<AminjonModel> aminjon = await _aminjonService.Delete(id);
            return Ok(aminjon);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePostgres(int id)
        {
            ResponseModel<PostgresModel> postgres = await _postgresService.Delete(id);
            return Ok(postgres);
        }

        [HttpGet]
        public async Task<IActionResult> GetAminjonModles()
        {
            var aminjon = await _aminjonService.GetAminjonModels();
            return Ok(aminjon);
        }

        [HttpGet]
        public async Task<IActionResult> GetPostgresModles()
        {
            var postgres = await _postgresService.GetPostgresModels();
            return Ok(postgres);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAminjon(AminjonModel student)
        {
            ResponseModel<AminjonModel> aminjon = await _aminjonService.Update(student);
            return Ok(aminjon);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostgres(PostgresModel student)
        {
            ResponseModel<PostgresModel> postgres = await _postgresService.Update(student);
            return Ok(postgres);
        }

        [HttpPost]
        public async Task<IActionResult> AminjondanPostgresga(int id)
        {
            ResponseModel<AminjonModel> response = await _aminjonService.AminjonToPostgres(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostgresdanAminjonga(int id)
        {
            ResponseModel<PostgresModel> responses = await _postgresService.PostgresToAminjon(id);
            return Ok(responses);
        }



    }
}
