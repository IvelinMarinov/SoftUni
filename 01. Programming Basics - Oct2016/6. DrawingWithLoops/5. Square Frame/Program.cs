using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var upperRow = "+ ";
            var midRow = "| ";

            for (int i = 0; i < n-2; i++)
            {
                upperRow += "- ";                
            }
            upperRow += "+";
            Console.WriteLine(upperRow);

            for (int i = 0; i < n-2; i++)
            {
                midRow += "- ";
            }
            midRow += "|";
            for (int i = 0; i < n-2; i++)
            {
                Console.WriteLine(midRow);
            }
            Console.WriteLine(upperRow);

        }
    }
}
