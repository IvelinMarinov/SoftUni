using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Students_Enrolled_in_2014_or_2015
{
    public class StudentsEnrollerIn2014or2015
    {
        private const string EnrolledIn2014 = "14";
        private const string EnrolledIn2015 = "15";

        public static void Main()
        {
            var studentInfo = Console.ReadLine().Split();
            var students = new List<Student>();

            while (studentInfo[0] != "END")
            {
                var student = new Student
                {
                    FacultyNumber = studentInfo[0],
                    Grades = new List<int>()
                };

                for (int i = 1; i < studentInfo.Length; i++)
                {
                    var grade = int.Parse(studentInfo[i]);
                    student.Grades.Add(grade);
                }

                students.Add(student);

                studentInfo = Console.ReadLine().Split();
            }

            students
                .Where(x => x.FacultyNumber.EndsWith(EnrolledIn2014)|| x.FacultyNumber.EndsWith(EnrolledIn2015))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x.Grades)));
        }
    }
}
