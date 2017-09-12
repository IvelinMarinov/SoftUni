using System;
using System.Collections.Generic;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            var allEnteringSubjects = new List<ISubject>();
            var allDetainedSubjects = new List<ISubject>();

            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input.Length == 2)
                {
                    allEnteringSubjects.Add(new Robot(input[0], input[1]));
                }
                else if (input.Length == 3)
                {
                    allEnteringSubjects.Add(new Citizen(input[0], int.Parse(input[1]), input[2]));
                }

                input = Console.ReadLine().Split();
            }

            var fakeIds = Console.ReadLine();

            foreach (var subject in allEnteringSubjects)
            {
                if (subject.Id.EndsWith(fakeIds))
                {
                    allDetainedSubjects.Add(subject);
                }
            }

            foreach (var subject in allDetainedSubjects)
            {
                Console.WriteLine(subject.Id);
            }
        }
    }
}
