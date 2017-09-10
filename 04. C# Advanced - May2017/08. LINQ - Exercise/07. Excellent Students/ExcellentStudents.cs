using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Excellent_Students
{
    public class ExcellentStudents
    {
        public static void Main()
        {
            var studentInfo = Console.ReadLine().Split();
            var students = new List<Student>();

            while (studentInfo[0] != "END")
            {
                var student = new Student
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Grades = new List<int>()
                };

                for (int i = 2; i < studentInfo.Length; i++)
                {
                    var grade = int.Parse(studentInfo[i]);
                    student.Grades.Add(grade);
                }

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .Where(x => x.Grades.Any(g => g == 6))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
