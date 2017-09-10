using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Basic_Queue_Operations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            var inputParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numsToEnqueue = inputParams[0];
            var numsToDequeue = inputParams[1];
            var numToLookup = inputParams[2];

            var inputNums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Queue<int>();

            for (int i = 0; i < numsToEnqueue; i++)
            {
                stack.Enqueue(inputNums[i]);
            }

            if (numsToDequeue > stack.Count)
            {
                numsToDequeue = stack.Count;
            }

            for (int i = 0; i < numsToDequeue; i++)
            {
                stack.Dequeue();
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