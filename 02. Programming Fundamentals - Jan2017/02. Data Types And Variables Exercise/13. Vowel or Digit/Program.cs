using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbol = Console.ReadLine();

            switch (symbol)
            {
                case "a":
                case "e":
                case "o":
                case "u":
                case "i":
                case "y":
                    Console.WriteLine("vowel");
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Console.WriteLine("digit");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }

            //if (symbol == "a" || symbol == "e" || symbol == "o" || symbol == "u" || symbol == "i" || symbol == "y")
            //{
            //    Console.WriteLine("vowel");
            //}
            //else if (symbol == "0" || symbol == "1" || symbol == "2" || symbol == "3" || symbol == "4" || symbol == "5"
            //    || symbol == "6" || symbol == "7" || symbol == "8" || symbol == "9")
            //{
            //    Console.WriteLine("digit");
            //}
            //else
            //{
            //    Console.WriteLine("other");
            //}
        }
    }
}
