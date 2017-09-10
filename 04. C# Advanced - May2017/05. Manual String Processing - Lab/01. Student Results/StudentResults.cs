using System;
using System.Linq;

namespace _01.Student_Results
{
    public class StudentResults
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var grades = new string[n][];

            for (int i = 0; i < n; i++)
            {
                var currStudent = Console.ReadLine()
                    .Split(new[] { ',', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                grades[i] = currStudent;
            }

            Console.WriteLine("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");

            for (int i = 0; i < grades.Length; i++)
            {
                var name = grades[i][0];
                var firstGrade = double.Parse(grades[i][1]);
                var secondGrade = double.Parse(grades[i][2]);
                var thirdGrade = double.Parse(grades[i][3]);
                var averageGrade = (firstGrade + secondGrade + thirdGrade) / 3;

                Console.WriteLine("{0, -10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, firstGrade, secondGrade, thirdGrade, averageGrade);
            }
        }
    }
}
