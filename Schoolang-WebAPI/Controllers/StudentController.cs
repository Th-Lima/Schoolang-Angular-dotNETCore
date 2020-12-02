using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schoolang_WebAPI.Models;
using Schoolang_WebAPI.Repositories;

namespace Schoolang_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
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

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            try
            {
                _repository.Add(student);

                if(await _repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro { e.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> Put(int studentId, Student student)
        {
            try
            {
                var hasStudent = await _repository.GetStudentsAsyncById(studentId, false);
                if (hasStudent == null)
                {
                    return NotFound("Aluno não encontrado");
                }
                
                _repository.Update(student);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(student);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro { e.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            try
            {
                var hasStudent = await _repository.GetStudentsAsyncById(studentId, false);
                if (hasStudent == null)
                {
                    return NotFound("Aluno não encontrado");
                }

                _repository.Delete(hasStudent);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deletado com sucesso");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro { e.Message}");
            }

            return BadRequest();
        }
    }
}
