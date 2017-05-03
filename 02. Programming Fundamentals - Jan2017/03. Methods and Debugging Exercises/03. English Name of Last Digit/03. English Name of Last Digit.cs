using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.English_Name_of_Last_Digit
{
    class EnglishNameofLastDigit
    {
        static string NameOfDigit(long digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }

        static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var lastDigit = Math.Abs(n % 10);

            var nameOfDigit = NameOfDigit(lastDigit);

            Console.WriteLine(nameOfDigit);

        }
    }
}
