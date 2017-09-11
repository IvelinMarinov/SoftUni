using System;

namespace _02.Vehicles_Extension
{
    public class StartUp
    {
        public static void Main()
        {
            double fuelQuantity;
            double fuelConsumption;
            double tankCapacity;

            var carInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(carInfo[1]);
            fuelConsumption = double.Parse(carInfo[2]);
            tankCapacity = double.Parse(carInfo[3]);
            var car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            var truckInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(truckInfo[1]);
            fuelConsumption = double.Parse(truckInfo[2]);
            tankCapacity = double.Parse(truckInfo[3]);
            var truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            var busInfo = Console.ReadLine().Split();
            fuelQuantity = double.Parse(busInfo[1]);
            fuelConsumption = double.Parse(busInfo[2]);
            tankCapacity = double.Parse(busInfo[3]);
            var bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var command = commandArgs[0];
                var vehicleType = commandArgs[1];
                var distanceOrFuel = double.Parse(commandArgs[2]);

                try
                {
                    switch (vehicleType.ToLower())
                    {
                        case "car":
                            switch (command.ToLower())
                            {
                                case "drive":
                                    Console.WriteLine(car.Drive(distanceOrFuel));
                                    break;
                                case "refuel":
                                    car.Refuel(distanceOrFuel);
                                    break;
                            }
                            break;

                        case "truck":
                            switch (command.ToLower())
                            {
                                case "drive":
                                    Console.WriteLine(truck.Drive(distanceOrFuel));
                                    break;
                                case "refuel":
                                    truck.Refuel(distanceOrFuel);
                                    break;
                            }
                            break;
                        case "bus":
                            switch (command.ToLower())
                            {
                                case "drive":
                                    Console.WriteLine(bus.Drive(distanceOrFuel));
                                    break;
                                case "driveempty":
                                    Console.WriteLine(bus.DriveEmpty(distanceOrFuel));
                                    break;
                                case "refuel":
                                    truck.Refuel(distanceOrFuel);
                                    break;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
