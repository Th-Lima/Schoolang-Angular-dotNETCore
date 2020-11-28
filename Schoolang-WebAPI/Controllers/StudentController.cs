using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schoolang_WebAPI.Repositories;

namespace Schoolang_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _repository;

        public StudentController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllStudentsAsync(false);

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            try
            {
                var result = await _repository.GetStudentsAsyncById(studentId, true);

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        [HttpGet("byLanguage/{languageId}")]
        public async Task<IActionResult> GetByLanguageId(int languageId)
        {
            try
            {
                var result = await _repository.GetStudentsAsyncByLanguageId(languageId, false);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro { e.Message}");
            }
        }
    }
}
