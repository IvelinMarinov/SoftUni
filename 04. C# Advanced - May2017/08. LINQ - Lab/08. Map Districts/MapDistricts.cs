using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Map_Districts
{
    public class MapDistricts
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new []{' ', '\t', '\n'},StringSplitOptions.RemoveEmptyEntries);
            var cities = new Dictionary<string, List<long>>();

            foreach (var element in elements)
            {
                var info = element.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var city = info[0];
                var population = long.Parse(info[1]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new List<long>());
                }

                cities[city].Add(population);
            }

            var bound = long.Parse(Console.ReadLine());

            cities = cities
                .Where(t => t.Value.Sum() > bound)
                .OrderByDescending(t => t.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var city in cities)
            {
                var districts = city
                    .Value.OrderByDescending(x => x)
                    .Take(5);

                Console.WriteLine($"{city.Key}: {string.Join(" ", districts)}");
            }
        }
    }
}
