using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students_by_Group
{
    public class StudentsByGroup
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
                    GroupNumber = int.Parse(studentInfo[2])
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students.Where(x => x.GroupNumber == 2)
                .OrderBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
        }
    }
}
