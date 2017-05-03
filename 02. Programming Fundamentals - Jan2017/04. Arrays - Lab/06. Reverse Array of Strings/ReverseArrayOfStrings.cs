using System;
using System.Linq;

namespace _06.Reverse_Array_of_Strings
{
    class ReverseArrayOfStrings
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var reversedInput = input.Reverse().ToArray();

            var result = string.Join(" ", reversedInput);

            Console.WriteLine(result);
        }
    }
}
