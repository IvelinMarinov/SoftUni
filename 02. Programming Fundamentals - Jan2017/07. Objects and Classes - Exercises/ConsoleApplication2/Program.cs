using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _08.MentorGroup
{
    public class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Attendance { get; set; }

        public static SortedDictionary<string, Student> studentList = new SortedDictionary<string, Student>();
    }
    public class MentorGroup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            while (input != "end of dates")
            {
                AddStudent(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of comments")
            {
                AddComments(input);
                input = Console.ReadLine();
            }

            PrintResult();
        }

        public static void AddStudent(string input)
        {
            var inputDates = input.Split(' ', ',');

            var currentStudent = new Student
            {
                Name = inputDates[0].ToLower(),
                Attendance = inputDates
                .Skip(1)
                .Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .ToList(),
                Comments = new List<string>()
            };

            if (!Student.studentList.ContainsKey(currentStudent.Name))
            {
                Student.studentList[currentStudent.Name] = currentStudent;
            }

            else
            {
                Student.studentList[currentStudent.Name].Attendance.AddRange(currentStudent.Attendance);
            }
        }

        public static void AddComments(string input)
        {
            var inputComments = input.Split('-');

            var currentStudent = new Student
            {
                Name = inputComments[0].ToLower(),
                Comments = inputComments.Skip(1).ToList()
            };

            if (Student.studentList.ContainsKey(currentStudent.Name))
            {
                Student.studentList[currentStudent.Name].Comments.AddRange(currentStudent.Comments);

            }
        }

        public static void PrintResult()
        {
            foreach (var student in Student.studentList.Values)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");

                foreach (var comment in student.Comments.Distinct().ToList())
                {
                    Console.WriteLine("- " + comment);
                }

                Console.WriteLine("Dates attended:");

                foreach (var date in student.Attendance.OrderBy(x => x).ToList())
                {
                    Console.WriteLine("-- {0:dd/MM/yyyy}", date);
                }
            }
        }
    }
}