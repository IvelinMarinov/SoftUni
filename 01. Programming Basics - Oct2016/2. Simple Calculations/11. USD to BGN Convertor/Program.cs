using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_To_BGN_Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter amount in USD: ");
            var USD = double.Parse(Console.ReadLine());
            var BGN = USD * 1.79549;
            var BGNRounded = Math.Round(BGN, 2);
            Console.WriteLine("amount in BGN: " + BGNRounded);
            
        }
    }
}
