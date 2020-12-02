using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schoolang_WebAPI.Models;
using Schoolang_WebAPI.Repositories;

namespace Schoolang_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllTeachersAsync(true);

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            try
            {
                var result = await _repository.GetTeachersAsyncById(teacherId, true);

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        [HttpGet("byStudent/{studentId}")]
        public async Task<IActionResult> GetTeacherByStudentId(int studentId)
        {
            try
            {
                var result = await _repository.GetTeachersAsyncByStudentId(studentId, false);

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher teacher)
        {
            try
            {
                _repository.Add(teacher);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(teacher);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> Put(int teacherId, Teacher teacher)
        {
            try
            {
                var hasTeacher = await _repository.GetTeachersAsyncById(teacherId, false);
                if (hasTeacher == null)
                {
                    return NotFound("Professor não encontrado!");
                }

                _repository.Update(teacher);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(teacher);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro { e.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> Delete(int teacherId)
        {
            try
            {
                var hasTeacher = await _repository.GetTeachersAsyncById(teacherId, false);
                if(hasTeacher == null)
                {
                    return NotFound("Professor não encontrado!!");
                }

                _repository.Delete(hasTeacher);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deletado com sucesso");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
            
            return BadRequest();
        }
    }
}
