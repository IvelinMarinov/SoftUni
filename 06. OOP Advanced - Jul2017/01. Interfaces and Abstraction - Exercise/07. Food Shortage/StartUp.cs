using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            var allBuyers = new Dictionary<string, IBuyer>();
            
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    allBuyers.Add(input[0], new Citizen(input[0], int.Parse(input[1]), input[2], DateTime.ParseExact(input[3], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                }
                else if (input.Length == 3)
                {
                    allBuyers.Add(input[0], new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }

            var buyerName = Console.ReadLine();

            while (buyerName != "End")
            {
                if (allBuyers.ContainsKey(buyerName))
                {
                    allBuyers[buyerName].BuyFood();
                }
                buyerName = Console.ReadLine();
            }

            Console.WriteLine(allBuyers.Select(x => x.Value.Food).Sum());
        }
    }
}
