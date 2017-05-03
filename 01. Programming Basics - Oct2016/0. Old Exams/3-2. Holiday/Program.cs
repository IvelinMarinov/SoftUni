using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2.Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var season = Console.ReadLine();

            var summerBulgaria = 0.3;
            var winterBulgaria = 0.7;
            var summerBalkans = 0.4;
            var winterBalkans = 0.8;
            var allSeasonEU = 0.9;

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                switch (season)
                {
                    case "summer":
                        Console.WriteLine("camp - {0:0.00}", budget * summerBulgaria);
                        break;
                    case "winter":
                        Console.WriteLine("hotel - {0:0.00}", budget * winterBulgaria);
                        break;
                    default:
                        break;
                }
            }            
            else if (budget >= 100 && budget < 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                switch (season)
                {
                    case "summer":
                        Console.WriteLine("camp - {0:0.00}", budget * summerBalkans);
                        break;
                    case "winter":
                        Console.WriteLine("hotel - {0:0.00}", budget * winterBalkans);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("hotel - {0:0.00}", budget * allSeasonEU);
            }
        }
    }
}
