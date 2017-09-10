using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Students_Joined_to_Specialties
{
    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            var studentSpecialtyInfo = Console.ReadLine().Split();
            var StudentSpecialties = new List<StudentSpecialty>();

            while (studentSpecialtyInfo[0] != "Students:")
            {
                var studentSpecialty = new StudentSpecialty
                {
                    SpecialtyName = String.Concat(studentSpecialtyInfo[0], " ", studentSpecialtyInfo[1]),
                    FacultyNumber = studentSpecialtyInfo[2]
                };

                StudentSpecialties.Add(studentSpecialty);

                studentSpecialtyInfo = Console.ReadLine().Split();
            }

            var studentInfo = Console.ReadLine().Split();
            var students = new List<Student>();

            while (studentInfo[0] != "END")
            {
                var student = new Student
                {
                    FacultyNumber = studentInfo[0],
                    Name = string.Concat(studentInfo[1], " ", studentInfo[2])
                };

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            var joinedTable = students.Join(StudentSpecialties,
                stud => stud.FacultyNumber,
                spec => spec.FacultyNumber,
                (stud, spec) => new {stud.Name, stud.FacultyNumber, spec.SpecialtyName})
                .ToList();

            foreach (var entry in joinedTable.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{entry.Name} {entry.FacultyNumber} {entry.SpecialtyName}");
            }
        }
    }
}
