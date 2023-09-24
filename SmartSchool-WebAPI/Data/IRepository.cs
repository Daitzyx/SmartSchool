using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public interface IRepository
    {
            //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Student
        Task<Student[]> GetAllStudentAsync(bool includeTeacher);        
        Task<Student[]> GetStudentAsyncByMatterId(int matterId, bool includeMatter);
        Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher);
        
        //Teacher
        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);
        Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent);
        Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeMatter);
    }
}