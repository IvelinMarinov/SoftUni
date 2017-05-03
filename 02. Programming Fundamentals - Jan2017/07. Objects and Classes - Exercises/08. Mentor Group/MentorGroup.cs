using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08.Mentor_Group
{
    public class MentorGroup
    {
        public static void Main()
        {
            var nameAndDates = Console.ReadLine();
            var studentsList = new SortedDictionary<string, Student>();

            while (nameAndDates != "end of dates")
            {
                var nameAndDatesArr = nameAndDates.Split();
                var currStudentName = nameAndDatesArr[0].ToLower();

                if (!studentsList.ContainsKey(currStudentName))
                {
                    var currentStudent = new Student()
                    {
                        Name = currStudentName,
                        Dates = new List<DateTime>(),
                        Comments = new List<string>()
                    };

                    if (nameAndDatesArr.Length > 1)
                    {
                        var currStudentDates = nameAndDatesArr[1].Split(',');

                        for (int i = 0; i < currStudentDates.Length; i++)
                        {
                            currentStudent.Dates.Add(DateTime.ParseExact(currStudentDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        }
                    }

                    studentsList.Add(currStudentName, currentStudent);
                }

                else if (studentsList.ContainsKey(currStudentName) && nameAndDatesArr.Length > 1)
                {
                    var currStudentDates = nameAndDatesArr[1].Split(',');

                    for (int i = 0; i < currStudentDates.Length; i++)
                    {
                        studentsList[currStudentName].Dates.Add(DateTime.ParseExact(currStudentDates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                }

                nameAndDates = Console.ReadLine();
            }

            var comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                var commentArr = comment.Split('-');
                var studentName = commentArr[0];
                var studentComment = commentArr[1];

                foreach (var kvp in studentsList)
                {
                    if (kvp.Value.Name == studentName)
                    {
                        kvp.Value.Comments.Add(studentComment);
                    }
                }

                comment = Console.ReadLine();
            }
            
            foreach (var studentkvp in studentsList.Values)
            {
                Console.WriteLine(studentkvp.Name);
                Console.WriteLine("Comments:");

                foreach (var studentcomment in studentkvp.Comments)
                {
                    Console.WriteLine("- " + studentcomment);
                }

                Console.WriteLine("Dates attended:");

                foreach (var date in studentkvp.Dates.OrderBy(x => x).ToList())
                {
                    Console.WriteLine("-- {0:dd/MM/yyyy}", date);
                }
            }
        }
    }
}