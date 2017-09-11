using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            double fuelQuantity;
            double fuelConsumption;

            var carInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(carInfo[1]);
            fuelConsumption = double.Parse(carInfo[2]);
            var car = new Car(fuelQuantity, fuelConsumption);

            var truckInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(truckInfo[1]);
            fuelConsumption = double.Parse(truckInfo[2]);
            var truck = new Truck(fuelQuantity, fuelConsumption);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var command = commandArgs[0];
                var carOrTruck = commandArgs[1];
                var distanceOrFuel = double.Parse(commandArgs[2]);

                switch (command.ToLower())
                {
                    case "drive":
                        switch (carOrTruck.ToLower())
                        {
                            case "car":
                                Console.WriteLine(car.Drive(distanceOrFuel));
                                break;
                            case "truck":
                                Console.WriteLine(truck.Drive(distanceOrFuel));
                                break;
                        }
                        break;

                    case "refuel":
                        switch (carOrTruck.ToLower())
                        {
                            case "car":
                                car.Refuel(distanceOrFuel);
                                break;
                            case "truck":
                                truck.Refuel(distanceOrFuel);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
