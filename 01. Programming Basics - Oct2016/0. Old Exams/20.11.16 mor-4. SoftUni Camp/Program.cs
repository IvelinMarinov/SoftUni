using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_mor_4.SoftUni_Camp_
{
    class Program
    {
        static void Main(string[] args)
        {
            var numGroups = int.Parse(Console.ReadLine());
            var totalPersons = 0;
            var car = 0;
            var van = 0;
            var smallBus = 0;
            var bigBus = 0;
            var train = 0;

            for (int i = 0; i < numGroups; i++)
            {
                var personsInGroup = int.Parse(Console.ReadLine());
                totalPersons += personsInGroup;

                if (personsInGroup <= 5)
                {
                    car += personsInGroup;
                }
                else if (personsInGroup >=6 && personsInGroup <= 12)
                {
                    van += personsInGroup;
                }
                else if (personsInGroup >= 13 && personsInGroup <= 25)
                {
                    smallBus += personsInGroup;
                }
                else if (personsInGroup >= 26 && personsInGroup <= 40)
                {
                    bigBus += personsInGroup;
                }
                else if (personsInGroup >= 41)
                {
                    train += personsInGroup;
                }
            }
            Console.WriteLine("{0:f2}%", car * 100.00 / totalPersons);
            Console.WriteLine("{0:f2}%", van * 100.00 / totalPersons);
            Console.WriteLine("{0:f2}%", smallBus * 100.00 / totalPersons);
            Console.WriteLine("{0:f2}%", bigBus * 100.00 / totalPersons);
            Console.WriteLine("{0:f2}%", train * 100.00 / totalPersons);
        }
    }
}
