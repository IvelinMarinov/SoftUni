using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var inputArgs = Regex.Split(input, ", ");
                var command = inputArgs[0];
                var car = inputArgs[1];

                if (command == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    if (parking.Contains(car))
                    {
                        parking.Remove(car);
                    }
                }

                input = Console.ReadLine();
            }

            if (parking.Count != 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
