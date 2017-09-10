using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    public class BasicStackLOperations
    {
        public static void Main()
        {
            var inputParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numsToPush = inputParams[0];
            var numsToPop = inputParams[1];
            var numToLookup = inputParams[2];

            var inputNums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(inputNums[i]);
            }

            if (numsToPop > stack.Count)
            {
                numsToPop = stack.Count;
            }

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (stack.Contains(numToLookup))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
