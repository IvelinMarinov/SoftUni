using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Group_by_Group
{
    public class GroupByGroup
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
                    Group = int.Parse(studentInfo[2])
                };
                
                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            var groupedStudents = students
                .GroupBy(x => x.Group)
                .ToDictionary(x => x.Key, x => x.ToList())
                .OrderBy(x => x.Key);

            foreach (var group in groupedStudents)
            {
                Console.Write($"{group.Key} - ");
                var entries = new List<string>();

                foreach (var entry in group.Value)
                {
                    var firstAndLastNameAsString = string.Concat(entry.FirstName, " " ,entry.LastName);

                    entries.Add(firstAndLastNameAsString);
                }

                Console.Write(string.Join(", ", entries));
                Console.WriteLine();
            }
        }
    }
}
