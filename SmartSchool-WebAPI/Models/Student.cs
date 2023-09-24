using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Models
{
    public class Student
    {
        public Student() {}

        public Student(int id, string name, string lastName, string phone) 
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Phone = phone; 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<StudentMatter>? StudentsMatters { get; set; }
    }
}