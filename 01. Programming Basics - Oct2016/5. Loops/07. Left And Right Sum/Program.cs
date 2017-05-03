using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());
            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());
                leftSum += num;
            }
            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());
                rightSum += num;
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = {0}", rightSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(leftSum - rightSum));
            }
        }
    }
}
