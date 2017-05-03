using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Population_Counter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split('|').ToList();

            var summary = new Dictionary<string, Dictionary<string, long>>();

            while (input[0] != "report")
            {
                var country = input[1];
                var city = input[0];
                var population = int.Parse(input[2]);

                if (!summary.ContainsKey(country))
                {
                    summary[country] = new Dictionary<string, long>();

                    if (!summary[country].ContainsKey(city))
                    {
                        summary[country][city] = population;
                    }
                }

                if (!summary[country].ContainsKey(city))
                {
                    summary[country][city] = population;
                }

                input = Console.ReadLine().Split('|').ToList();
            }

            var CountriesTotalPopulation = new Dictionary<string, long>();

            foreach (var countries in summary)
            {
                long totalPopulation = 0;

                foreach (var city in countries.Value)
                {
                    totalPopulation += city.Value;
                }
                CountriesTotalPopulation[countries.Key] = totalPopulation;
            }
            
            foreach (var country in CountriesTotalPopulation.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");


                foreach (KeyValuePair<string, Dictionary<string,long>> countries in summary)
                {
                    if (countries.Key == country.Key)
                    {
                        foreach (KeyValuePair<string, long> cities in countries.Value.OrderByDescending(x => x.Value))
                        {
                            Console.WriteLine($"=>{cities.Key}: {cities.Value}");
                        }
                    }                                       
                }
            }
        }
    }
}
