using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _23._10._2016___3.Nether_Realms
{
    public class NetherRealms
    {
        public static void Main()
        {
            var separators = new char[] { ',', ' ', '\t', '\n' }; ;
            var demons = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var numbersPattern = @"\-{0,1}\+{0,1}[0-9]+\.{0,1}[0-9]{0,}";
            Regex regex = new Regex(numbersPattern);
            var demonBook = new List<Demon>();

            foreach (var demon in demons)
            {
                var demonName = demon;
                var health = 0;
                var damage = 0.0;

                var numberMatches = regex.Matches(demon);

                foreach (Match numberMatch in numberMatches)
                {
                    string currentNumber = numberMatch.ToString();
                    damage += double.Parse(currentNumber);
                }

                foreach (var symbol in demon)
                {
                    if (symbol < 42 || symbol > 57 || symbol == 44)
                    {
                        health += symbol;                        
                    }
                    else if (symbol == 42)
                    {
                        damage = damage * 2;
                    }
                    else if (symbol == 47)
                    {
                        damage = damage / 2;
                    }
                }

                var currentDemon = new Demon()
                {
                    Name = demonName,
                    Health = health,
                    Damage = damage
                };

                demonBook.Add(currentDemon);
            }

            foreach (var demon in demonBook.OrderBy(d => d.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
}
