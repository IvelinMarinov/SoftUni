using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Students_by_First_and_Last_Name
{
    public class StudentsByFirstAndLastName
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
                .Where(x => string.Compare(x.FirstName, x.LastName, StringComparison.Ordinal) < 0)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
