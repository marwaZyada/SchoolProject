using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }

        // Foreign Key
        public int InstructorId { get; set; }

        // Navigation Property
        public Instructor Instructor { get; set; }
        // Navigation Property
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
