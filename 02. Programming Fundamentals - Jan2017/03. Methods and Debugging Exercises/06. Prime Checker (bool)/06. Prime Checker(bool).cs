using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker__bool_
{
    class PrimeCheker
    {
        static bool IsPrime(long n)
        {
            var prime = true;

            if (n > 2)
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
                if (prime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            var prime = IsPrime(n);

            Console.WriteLine(prime);

        }
    }
}
