using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public class DataContext: DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Matter> Matter { get; set; }
        public DbSet<StudentMatter> StudentMatters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentMatter>()
                .HasKey(AD => new { AD.StudentId, AD.MatterId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, "Lauro"),
                    new Teacher(2, "Roberto"),
                    new Teacher(3, "Ronaldo"),
                    new Teacher(4, "Rodrigo"),
                    new Teacher(5, "Alexandre"),
                });
            
            builder.Entity<Matter>()
                .HasData(new List<Matter>{
                    new Matter(1, "Matemática", 1),
                    new Matter(2, "Física", 2),
                    new Matter(3, "Português", 3),
                    new Matter(4, "Inglês", 4),
                    new Matter(5, "Programação", 5)
                });
            
            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Marta", "Kent", "33225555"),
                    new Student(2, "Paula", "Isabela", "3354288"),
                    new Student(3, "Laura", "Antonia", "55668899"),
                    new Student(4, "Luiza", "Maria", "6565659"),
                    new Student(5, "Lucas", "Machado", "565685415"),
                    new Student(6, "Pedro", "Alvares", "456454545"),
                    new Student(7, "Paulo", "José", "9874512")
                });

            builder.Entity<StudentMatter>()
                .HasData(new List<StudentMatter>() {
                    new StudentMatter() {StudentId = 1, MatterId = 2 },
                    new StudentMatter() {StudentId = 1, MatterId = 4 },
                    new StudentMatter() {StudentId = 1, MatterId = 5 },
                    new StudentMatter() {StudentId = 2, MatterId = 1 },
                    new StudentMatter() {StudentId = 2, MatterId = 2 },
                    new StudentMatter() {StudentId = 2, MatterId = 5 },
                    new StudentMatter() {StudentId = 3, MatterId = 1 },
                    new StudentMatter() {StudentId = 3, MatterId = 2 },
                    new StudentMatter() {StudentId = 3, MatterId = 3 },
                    new StudentMatter() {StudentId = 4, MatterId = 1 },
                    new StudentMatter() {StudentId = 4, MatterId = 4 },
                    new StudentMatter() {StudentId = 4, MatterId = 5 },
                    new StudentMatter() {StudentId = 5, MatterId = 4 },
                    new StudentMatter() {StudentId = 5, MatterId = 5 },
                    new StudentMatter() {StudentId = 6, MatterId = 1 },
                    new StudentMatter() {StudentId = 6, MatterId = 2 },
                    new StudentMatter() {StudentId = 6, MatterId = 3 },
                    new StudentMatter() {StudentId = 6, MatterId = 4 },
                    new StudentMatter() {StudentId = 7, MatterId = 1 },
                    new StudentMatter() {StudentId = 7, MatterId = 2 },
                    new StudentMatter() {StudentId = 7, MatterId = 3 },
                    new StudentMatter() {StudentId = 7, MatterId = 4 },
                    new StudentMatter() {StudentId = 7, MatterId = 5 }
                });
        }
    }
}