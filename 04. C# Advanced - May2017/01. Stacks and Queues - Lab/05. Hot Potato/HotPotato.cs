using System;
using System.Collections.Generic;

namespace _05.Hot_Potato
{
    public class HotPotato
    {
        public static void Main()
        {
            var children = Console.ReadLine().Split(' ');

            var number = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);

            while (queue.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
