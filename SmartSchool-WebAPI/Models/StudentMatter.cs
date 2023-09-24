using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Models
{
    public class StudentMatter
    {
        public StudentMatter() { }
        public StudentMatter(int studentId, int matterId)
        {
            this.StudentId = studentId;
            this.MatterId = matterId;
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int MatterId { get; set; }
        public Matter Matter { get; set; }
    }
}