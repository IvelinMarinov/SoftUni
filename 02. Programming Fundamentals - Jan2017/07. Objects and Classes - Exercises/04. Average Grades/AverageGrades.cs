using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Average_Grades
{
    public class AverageGrades
    {
        public static Student InitializeStudent(string[] studentInfo)
        {
            var currStudent = new Student()
            {
                Name = studentInfo[0],
                Grades = new List<double>()
            };

            for (int i = 1; i < studentInfo.Length; i++)
            {
                var currGrade = double.Parse(studentInfo[i]);
                currStudent.Grades.Add(currGrade);
            }
            return currStudent;
        }

        public static void Main()
        {
            var numberOfStudents = int.Parse(Console.ReadLine());

            var studentsList = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                var studentInfo = Console.ReadLine().Split();
                var currStudent = InitializeStudent(studentInfo);
                studentsList.Add(currStudent);
            }

            foreach (var student in studentsList
                .Where(a => a.AverageGrade >= 5)
                .OrderBy(s => s.Name)
                .ThenByDescending(a => a.AverageGrade))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
            }
        }
    }
}
