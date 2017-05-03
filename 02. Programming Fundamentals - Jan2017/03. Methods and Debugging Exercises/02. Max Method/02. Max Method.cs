using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Max_Method
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }

        static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            var Max = GetMax(firstNumber, secondNumber);

            Console.WriteLine(GetMax(Max, thirdNumber));

        }
    }
}
