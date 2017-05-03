using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 0; firstDigit < n; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit < n; secondDigit++)
                {
                    for (int thirdDigit = 0; thirdDigit < n; thirdDigit++)
                    {
                        char symbolFirstDigit = (char)('a' + firstDigit);
                        char symbolSecondDigit = (char)('a' + secondDigit);
                        char symbolThirdDigit = (char)('a' + thirdDigit);

                        Console.WriteLine("{0}{1}{2}", symbolFirstDigit, symbolSecondDigit, symbolThirdDigit);
                    }
                }
            }                   
           
        }
    }
}
