using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _repository;
        public StudentController(IRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try {
                var result = await _repository.GetAllStudentAsync(true);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId) 
        {
            try {
                var result = await _repository.GetStudentAsyncById(studentId, true);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("ByMatter/{matterId}")]
        public async Task<IActionResult> GetByMatterId(int matterId) 
        {
            try {
                var result = await _repository.GetStudentAsyncByMatterId(matterId, false);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> post([FromBody]Student model) 
        {
            try {
                _repository.Add(model);

                if(await _repository.SaveChangesAsync())
                    return Ok(model);

                
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        
        [HttpPut("{studentId}")]
        public async Task<IActionResult> put(int studentId, [FromBody]Student model) 
        {
            try {
                var aluno = await _repository.GetStudentAsyncById(studentId, false);

                if(aluno == null) return NotFound("Student not found!");

                _repository.Update(model);

                if(await _repository.SaveChangesAsync())
                    return Ok(model);
                
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> delete(int studentId) 
        {
            try {
                var aluno = await _repository.GetStudentAsyncById(studentId, false);
                if(aluno == null) return NotFound();

                _repository.Delete(aluno);

                if(await _repository.SaveChangesAsync())
                    return Ok("Deleted");
                
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}