using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Mordor_s_Cruelty_Plan
{
    public class Startup
    {
        public static void Main()
        {
            var foodTokens = Console.ReadLine().Split();
            
            var foods = new List<Food>();
            var foodFactory = new FoodFactory();
            var moodFactory = new MoodFactory();

            foreach (var foodToken in foodTokens)
            {
                var currentFood = foodFactory.CreateFood(foodToken);
                foods.Add(currentFood);
            }

            Mood mood = moodFactory.CreateMood(foods);

            Console.WriteLine(foods.Sum(f => f.PointOfHappines));
            Console.WriteLine(mood);
        }
    }
}
