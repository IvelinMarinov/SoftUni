using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Speed_Racing
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            var input = string.Empty;
            
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                var inputArgs = input.Split();
                var model = inputArgs[0];
                var fuelAmount = double.Parse(inputArgs[1]);
                var fuelConsumption = double.Parse(inputArgs[2]);

                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                var commandArgs = command.Split();
                var model = commandArgs[1];
                var distance = double.Parse(commandArgs[2]);
                var currCar = cars.Where(c => c.Model == model).FirstOrDefault();
                var hasEnoughFuel = currCar.Travel(distance);

                if (!hasEnoughFuel)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravelled}");
            }
        }
    }
}
