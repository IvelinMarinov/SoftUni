using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var numStudents = int.Parse(Console.ReadLine());

            var fail = 0;
            var between3And4 = 0;
            var between4And5 = 0;
            var topStudents = 0;
            var sumGrades = 0.00;

            for (int i = 0; i < numStudents; i++)
            {
                var grade = double.Parse(Console.ReadLine());
                sumGrades += grade;

                if (grade < 3.00)
                {
                    fail++;
                }
                else if (grade >= 3.00 && grade < 4.00)
                {
                    between3And4++;
                }
                else if (grade >= 4.00 && grade < 5.00)
                {
                    between4And5++;
                }
                else
                {
                    topStudents++;
                }                                           
            }
            var FailPerc = fail * 100.00 / numStudents;
            var between3And4Perc = between3And4 * 100.00 / numStudents;
            var between4And5Perc = between4And5 * 100.00 / numStudents;
            var topStudentsPerc = topStudents * 100.00 / numStudents;
            var averageGrade = sumGrades / numStudents;

            Console.WriteLine("Top students: {0:f2}%", topStudentsPerc);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", between4And5Perc);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", between3And4Perc);
            Console.WriteLine("Fail: {0:f2}%", FailPerc);
            Console.WriteLine("Average: {0:f2}", averageGrade);
        }
    }
}
