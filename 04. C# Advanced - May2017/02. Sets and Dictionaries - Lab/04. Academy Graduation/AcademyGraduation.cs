using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Academy_Graduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            var numStudents = int.Parse(Console.ReadLine());
            var summary = new SortedDictionary<string, List<double>>();
            string studentName;
            List<double> grades;

            for (int i = 0; i < numStudents; i++)
            {
                studentName = Console.ReadLine();
                grades = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                if (!summary.ContainsKey(studentName))
                {
                    summary.Add(studentName, grades);
                }
                else
                {
                    var currGrades = summary[studentName];
                    currGrades.AddRange(grades);
                    summary[studentName] = currGrades;
                }
            }

            foreach (var kvp in summary)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }
    }
}
