using System;
using System.Collections.Generic;
using System.Numerics;

namespace _04.Convert_from_base_10_to_base_N
{
    public class ConvertFromBaseTenToBaseN
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var newBase = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            BigInteger remainder = 0;
            BigInteger currNumber = 0;

            var result = new List<BigInteger>();

            while (number > 0)
            {
                currNumber = number % newBase;
                remainder = number / newBase;
                number = remainder;
                result.Add(currNumber);
            }

            result.Reverse();

            Console.WriteLine(string.Join("", result));
        }
    }
}
