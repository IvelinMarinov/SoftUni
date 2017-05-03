using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Numbers_in_Reversed_Order
{
    class NumberinReversedOrder

    {
        static string ReverseDigits(string number)
        {
            string reversedNumber = new string(number.ToCharArray().Reverse().ToArray());

            return reversedNumber;
        }

        static void Main()
        {
            string number = Console.ReadLine();

            Console.WriteLine(ReverseDigits(number));
        }
    }
}
