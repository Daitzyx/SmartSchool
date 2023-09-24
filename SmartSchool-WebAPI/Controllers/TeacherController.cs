using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repository;

        public TeacherController(IRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try {
                var result = await _repository.GetAllTeachersAsync(true);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(int teacherId) 
        {
            try {
                var result = await _repository.GetTeacherAsyncById(teacherId, false);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("by-student/{studentId}")]
        public async Task<IActionResult> GetTeacherByStudentId(int studentId) 
        {
            try {
                var result = await _repository.GetTeachersAsyncByStudentId(studentId, true);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> post([FromBody]Teacher model) {
            try {
                _repository.Add(model);

                if(await _repository.SaveChangesAsync())
                    return Ok(model);                

            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }         

            return BadRequest();

        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> put (int teacherId, [FromBody]Teacher model) {
            try {
                var teacher = await _repository.GetTeacherAsyncById(teacherId, false);

                if(teacher == null) return NotFound("Teacher not found!");

                _repository.Update(model);

                if(await _repository.SaveChangesAsync())
                    return Ok(model);
                
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();

        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> delete(int teacherId) 
        {
            try {
                var teacher = await _repository.GetTeacherAsyncById(teacherId, false);
                if(teacher == null) return NotFound();

                _repository.Delete(teacher);

                if(await _repository.SaveChangesAsync())
                    return Ok("Deleted");
                
            } catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}