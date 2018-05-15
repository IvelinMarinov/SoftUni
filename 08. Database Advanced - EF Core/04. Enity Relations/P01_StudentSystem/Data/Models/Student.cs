using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public DateTime? Birthday { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<StudentCourse> HomeworkSubmissisons { get; set; } = new List<StudentCourse>();

        public ICollection<Homework> CourseEnrollments { get; set; } = new List<Homework>();
    }
}
