using System;
using System.Linq;
using System.Numerics;

namespace _05.Convert_from_base_N_to_base_10
{
    public class ConvertFromBaseNToBaseTen
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var oldBase = int.Parse(input[0]);
            var number = input[1].ToArray();

            BigInteger decimalNumber = 0;

            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber += (number[i] - 48) * BigInteger.Pow(oldBase, number.Length - 1 - i);
            }

            Console.WriteLine(decimalNumber);
        }
    }
}
