using System;

namespace _10.Explicit_Interfaces
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine().Split();
            }
        }
    }
}
