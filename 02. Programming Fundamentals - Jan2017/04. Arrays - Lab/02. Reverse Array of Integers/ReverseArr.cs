using System;

namespace _02.Reverse_Array_of_Integers
{
    class ReverseArrayOfInts
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var integers = new int[n];
            var reversedIntegers = new int[n];

            for (int i = 0; i < integers.Length; i++)
            {
                integers[i] = int.Parse(Console.ReadLine());
                reversedIntegers[reversedIntegers.Length - 1 - i] = integers[i];
            }

            for (int i = 0; i < reversedIntegers.Length; i++)
            {
                Console.Write($"{reversedIntegers[i]} ");
            }
            Console.WriteLine();
        }
    }
}
