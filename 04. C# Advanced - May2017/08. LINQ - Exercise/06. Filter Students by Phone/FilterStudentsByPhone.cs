using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Filter_Students_by_Phone
{
    public class FilterStudentsByPhone
    {
        private const string PhoneCodeOptionOne = "02";
        private const string PhoneCodeOptionTwo = "+359";

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
                    PhoneNumber = studentInfo[2]
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .Where(x => x.PhoneNumber.StartsWith(PhoneCodeOptionOne) || x.PhoneNumber.StartsWith(PhoneCodeOptionTwo))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
