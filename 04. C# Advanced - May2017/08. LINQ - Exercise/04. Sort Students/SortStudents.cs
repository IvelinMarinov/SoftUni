using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Sort_Students
{
    public class SortStudents
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
                    LastName = studentInfo[1]
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .OrderBy(x => x.LastName)
                .ThenByDescending(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
