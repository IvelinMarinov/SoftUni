using System;
using System.Collections.Generic;
using System.Globalization;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            var allSubjects = new List<ISubjectWithBirthdate>();

            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                switch (input[0].ToLower())
                {
                    case "robot":
                        break;
                    case "citizen":
                        allSubjects.Add(new Citizen(input[1], int.Parse(input[2]), input[3], DateTime.ParseExact(input[4], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                        break;
                    case "pet":
                        allSubjects.Add(new Pet(input[1], DateTime.ParseExact(input[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                        break;
                }

                input = Console.ReadLine().Split();
            }

            var birthYear = int.Parse(Console.ReadLine());
            
            foreach (var subject in allSubjects)
            {
                if (subject.Birthdate.Year == birthYear)
                {
                    Console.WriteLine(subject.Birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
