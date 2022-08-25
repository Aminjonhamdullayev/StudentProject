using Microsoft.AspNetCore.Mvc;
using StudentProject.IContract;
using StudentProject.Models;
using StudentProject.Service;

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
        public async Task<IActionResult> CreatAminjon(AminjonModel studentModel)
        {
            AminjonModel studentModel2 = await _aminjonService.CreatAminjon(studentModel);
            return Ok(studentModel2);
        }
        [HttpPost]
        public async Task<IActionResult> CreatPostgres(PostgresModel studentModel)
        {
            PostgresModel studentModel1 = await _postgresService.CreatPostgres(studentModel);
            return Ok(studentModel1);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAminjon(int id)
        {
            AminjonModel aminjon = await _aminjonService.Delete(id);
            return Ok(aminjon);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePostgres(int id)
        {
            PostgresModel postgres = await _postgresService.Delete(id);
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
            AminjonModel aminjon = await _aminjonService.Update(student);
            return Ok(aminjon);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostgres(PostgresModel student)
        {
            PostgresModel postgres = await _postgresService.Update(student);
            return Ok(postgres);
        }



    }
}
