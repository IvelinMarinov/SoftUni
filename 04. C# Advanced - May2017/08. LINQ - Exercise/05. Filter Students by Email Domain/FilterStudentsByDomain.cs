using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Filter_Students_by_Email_Domain
{
    public class FilterStudentsByDomain
    {
        private const string Domain = "@gmail.com";

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
                    Email = studentInfo[2]
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .Where(x => x.Email.EndsWith(Domain))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
