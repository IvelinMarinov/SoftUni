using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Office_Stuff
{
    public class OfficeStuff
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var orders = new List<Order>();

            for (int i = 0; i < n; i++)
            {
                var order = new Order()
                {
                    CompanyName = input[0],
                    Quantity = int.Parse(input[1]),
                    Product = input[2]
                };

                orders.Add(order);

                input = Console.ReadLine().Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var groupedOrders = orders.GroupBy(x => x.CompanyName).ToDictionary(x => x.Key, x => x.ToList());

            foreach (var group in groupedOrders)
            {
                Console.Write($"{group.Key}: ");

                var entryValues = new Dictionary<string,int>();
                foreach (var entry in group.Value)
                {
                    if (!entryValues.ContainsKey(entry.Product))
                    {
                        entryValues.Add(entry.Product, entry.Quantity);
                    }
                    else
                    {
                        entryValues[entry.Product] += entry.Quantity;
                    }
                }

                var strings = new List<string>();
                foreach (var kvp in entryValues)
                {
                    strings.Add(string.Concat(kvp.Key, "-", kvp.Value));
                }

                Console.WriteLine(string.Join(", ", strings));
            }
        }
    }
}
