using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            bool isSbyte = (n >= sbyte.MinValue) && (n <= sbyte.MaxValue);
            bool isByte = (n >= byte.MinValue) && (n <= byte.MaxValue);
            bool isShort = (n >= short.MinValue) && (n <= short.MaxValue);
            bool isUshort = (n >= ushort.MinValue) && (n <= ushort.MaxValue);
            bool isInt = (n >= int.MinValue) && (n <= int.MaxValue);
            bool isUint = (n >= uint.MinValue) && (n <= uint.MaxValue);
            bool isLong = (n >= long.MinValue) && (n <= long.MaxValue);

            if (isSbyte || isByte || isShort || isUshort || isInt || isUint || isLong)
            {
                Console.WriteLine("{0} can fit in:", n);
                if (isSbyte)
                {
                    Console.WriteLine("* sbyte");
                }
                if (isByte)
                {
                    Console.WriteLine("* byte");
                }
                if (isShort)
                {
                    Console.WriteLine("* short");
                }
                if (isUshort)
                {
                    Console.WriteLine("* ushort");
                }
                if (isInt)
                {
                    Console.WriteLine("* int");
                }
                if (isUint)
                {
                    Console.WriteLine("* uint");
                }
                if (isLong)
                {
                    Console.WriteLine("* long");
                }
            }
            else
            {
                Console.WriteLine("{0} can't fit in any type", n);
            }
        }
    }
}
