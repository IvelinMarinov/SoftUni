using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tyreOnePressure = double.Parse(input[5]);
                int tyreOneAge = int.Parse(input[6]);
                double tyreTwoPressure = double.Parse(input[7]);
                int tyreTwoAge = int.Parse(input[8]);
                double tyreThreePressure = double.Parse(input[9]);
                int tyreThreeAge = int.Parse(input[10]);
                double tyreFourPressure = double.Parse(input[11]);
                int tyreFourAge = int.Parse(input[12]);

                var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                    tyreOnePressure, tyreOneAge, tyreTwoPressure, tyreTwoAge,
                    tyreThreePressure, tyreThreeAge, tyreFourPressure, tyreFourAge);

                cars.Add(car);
            }

            var command = Console.ReadLine();
            var result = new List<Car>();

            switch (command)
            {
                case "fragile":
                    result = cars
                        .Where(c => c.Cargo.Type == "fragile")
                        .Where(t => t.Tyres.Any(p => p.Pressure < 1))
                        .ToList();

                    result.ForEach(c => Console.WriteLine(c.Model));
                    break;

                case "flamable":
                    result = cars
                        .Where(c => c.Cargo.Type == "flamable")
                        .Where(e => e.Engine.Power > 250)
                        .ToList();

                    result.ForEach(c => Console.WriteLine(c.Model));
                    break;
                default:
                    break;;
            }
        }
    }
}
