using System;

public class Engine
{
    public void Run()
    {
        CarManager manager = new CarManager();
        
        string type;
        string brand;
        string model;
        int year;
        int horsepower;
        int acceleration;
        int suspension;
        int durability;
        int length;
        string route;
        int prizePool;
        int carId;
        int raceId;
        int tuneIndex;
        string tuneAddon;

        var input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        while (input[0] != "Cops")
        {
            var command = input[0];

            switch (command.ToLower())
            {
                case "register":
                    carId = int.Parse(input[1]);
                    type = input[2];
                    brand = input[3];
                    model = input[4];
                    year = int.Parse(input[5]);
                    horsepower = int.Parse(input[6]);
                    acceleration = int.Parse(input[7]);
                    suspension = int.Parse(input[8]);
                    durability = int.Parse(input[9]);
                    manager.Register(carId, type, brand, model, year, horsepower, acceleration, suspension, durability);
                    break;

                case "check":
                    carId = int.Parse(input[1]);
                    Console.WriteLine(manager.Check(carId));
                    break;

                case "open":
                    raceId = int.Parse(input[1]);
                    type = input[2];
                    length = int.Parse(input[3]);
                    route = input[4];
                    prizePool = int.Parse(input[5]);
                    manager.Open(raceId, type, length, route, prizePool);
                    break;

                case "participate":
                    carId = int.Parse(input[1]);
                    raceId = int.Parse(input[2]);
                    manager.Participate(carId, raceId);
                    break;

                case "start":
                    raceId = int.Parse(input[1]);
                    Console.WriteLine(manager.Start(raceId));
                    break;

                case "park":
                    carId = int.Parse(input[1]);
                    manager.Park(carId);
                    break;

                case "unpark":
                    carId = int.Parse(input[1]);
                    manager.Unpark(carId);
                    break;

                case "tune":
                    tuneIndex = int.Parse(input[1]);
                    tuneAddon = input[2];
                    manager.Tune(tuneIndex, tuneAddon);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}