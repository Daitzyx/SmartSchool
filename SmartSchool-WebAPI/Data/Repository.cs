using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Student[]> GetAllStudentAsync(bool includeMatter = false)
        {
            IQueryable<Student> query = _context.Student;

            if (includeMatter)
            {
                query = query.Include(pe => pe.StudentsMatters)
                             .ThenInclude(ad => ad.Matter)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int studentId, bool includeMatter)
        {
            IQueryable<Student> query = _context.Student;

            if (includeMatter)
            {
                query = query.Include(a => a.StudentsMatters)
                             .ThenInclude(ad => ad.Matter)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student[]> GetStudentAsyncByMatterId(int matterId, bool includeMatter)
        {
            IQueryable<Student> query = _context.Student;

            if (includeMatter)
            {
                query = query.Include(pe => pe.StudentsMatters)
                             .ThenInclude(ad => ad.Matter)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.StudentsMatters.Any(ad => ad.MatterId == matterId));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeMatter)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeMatter)
            {
                query = query.Include(p => p.Matters);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Matters.Any(d => 
                            d.StudentsMatters.Any(ad => ad.StudentId == studentId)));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeMatter = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeMatter)
            {
                query = query.Include(c => c.Matters);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeMatter = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeMatter)
            {
                query = query.Include(pe => pe.Matters);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id)
                         .Where(teacher => teacher.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }
    }
}