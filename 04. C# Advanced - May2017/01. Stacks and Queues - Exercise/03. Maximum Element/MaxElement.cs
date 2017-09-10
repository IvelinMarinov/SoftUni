using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    public class MaxElement
    {
        public static void Main()
        {
            var NumOfCommands = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxElements = new Stack<int>();
            maxElements.Push(0);

            for (int i = 0; i < NumOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (command[0] == 1)
                {
                    var numToPush = command[1];

                    stack.Push(numToPush);

                    if (numToPush > maxElements.Peek())
                    {
                        maxElements.Push(numToPush);
                    }
                }

                else if (command[0] == 2)
                {
                    var numToPop = stack.Pop();

                    if (maxElements.Peek() == numToPop)
                    {
                        maxElements.Pop();
                    }
                }

                else if (command[0] == 3)
                {
                    Console.WriteLine(maxElements.Peek());
                }
            }
        }
    }
}
