using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_mor__2.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());
            var foodLeft = int.Parse(Console.ReadLine());
            var foodDogPerDay = double.Parse(Console.ReadLine());
            var foodCatPerDay = double.Parse(Console.ReadLine());
            var foodTurtlePerDayG = double.Parse(Console.ReadLine());
            var foodTurtlePerDay = foodTurtlePerDayG / 1000;

            var FoodNeeded = days * (foodDogPerDay + foodCatPerDay + foodTurtlePerDay);
            var difference = Math.Abs(FoodNeeded - foodLeft);

            if (foodLeft >= FoodNeeded)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor(difference));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed." , Math.Ceiling(difference));
            }
        }
    }
}
