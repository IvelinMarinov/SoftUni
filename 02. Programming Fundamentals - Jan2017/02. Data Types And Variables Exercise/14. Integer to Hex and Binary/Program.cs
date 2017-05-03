using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());

            string nHex = Convert.ToString((int)n, 16);
            Console.WriteLine(nHex.ToUpper());

            string nBinary = Convert.ToString((int)n, 2);
            Console.WriteLine(nBinary);
        }
    }
}
