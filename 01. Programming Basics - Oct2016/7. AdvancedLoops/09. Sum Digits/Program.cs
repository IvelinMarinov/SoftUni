using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            // for (int i = n; i >=0; i)
            //{
            //   sum += (n % 10);
            // n = n / 10;

            do
            {
                sum += (n % 10);
                n = n / 10;
            } while (n > 0);

            Console.WriteLine(sum);
        }
    }
}
