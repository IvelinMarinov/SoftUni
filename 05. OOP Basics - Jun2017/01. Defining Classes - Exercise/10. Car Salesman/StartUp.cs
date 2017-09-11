using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Car_Salesman
{
    public class StartUp
    {
        public static void Main()
        {
            var enginesNum = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < enginesNum; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var power = int.Parse(input[1]);
                var engine = new Engine(model, power);

                if (input.Length == 4)
                {
                    var displacement = input[2];
                    var efficiency = input[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                else if (input.Length == 3)
                {
                    var displacementOrEfficiency = input[2];
                    var displacement = 0;
                    var hasParse = int.TryParse(displacementOrEfficiency, out displacement);

                    if (hasParse)
                    {
                        engine.Displacement = displacementOrEfficiency;
                    }
                    else
                    {
                        engine.Efficiency = displacementOrEfficiency;
                    }
                }
                engines.Add(engine);
            }

            var carsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsNum; i++)
            {
                var input = Console.ReadLine().Split(new []{' ', '\t', '\n'},StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var engineModel = input[1];
                var engine = engines.FirstOrDefault(e => e.Model == engineModel);
                var car = new Car(model, engine);

                if (input.Length == 4)
                {
                    var weight = input[2];
                    var color = input[3];
                    car.Weight = weight;
                    car.Color = color;
                }

                else if (input.Length == 3)
                {
                    var weightOrColor = input[2];
                    var weight = 0;
                    var hasParse = int.TryParse(weightOrColor, out weight);

                    if (hasParse)
                    {
                        car.Weight = weightOrColor;
                    }
                    else
                    {
                        car.Color = weightOrColor;
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
;        }
    }
}
