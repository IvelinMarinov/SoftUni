using System;

namespace _11.Threeuple
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            var name = string.Concat(input[0], " ", input[1]);
            var address = input[2];
            var town = input[3];
            var firstThreeuple = new Threeuple<string, string, string>(name, address, town);
            Console.WriteLine(firstThreeuple);

            input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            var litersOfBeer = int.Parse(input[1]);
            bool drunkOrNot = true;
            if (input[2].ToLower() == "not" )
            {
                drunkOrNot = false;
            }
            var secondThreeuple = new Threeuple<string, int, bool>(name, litersOfBeer, drunkOrNot);
            Console.WriteLine(secondThreeuple);

            input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            name = input[0];
            var accountbalance = double.Parse(input[1]);
            var bankName = input[2];
            var thirdThreeuple = new Threeuple<string, double, string>(name, accountbalance, bankName);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
