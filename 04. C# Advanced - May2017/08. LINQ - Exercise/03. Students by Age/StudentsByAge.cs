using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Students_by_Age
{
    public class StudentsByAge
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
                    Age = int.Parse(studentInfo[2])
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .Where(x => x.Age >= 18 && x.Age <= 24)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.Age}"));
        }
    }
}
